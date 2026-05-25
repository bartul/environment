#!/usr/bin/env -S dotnet fsi --exec --

open System
open System.ComponentModel
open System.Diagnostics
open System.IO

type Options =
    {
        CodeCommand: string
        DryRun: bool
        ExtensionsFile: string
        ShowHelp: bool
    }

let scriptName =
    Path.GetFileName(fsi.CommandLineArgs[0])

let scriptDir =
    __SOURCE_DIRECTORY__

let defaultCodeCommand =
    match Environment.GetEnvironmentVariable("VSCODE_CLI") with
    | null
    | "" -> "code"
    | value -> value

let defaultOptions =
    {
        CodeCommand = defaultCodeCommand
        DryRun = false
        ExtensionsFile = Path.Combine(scriptDir, "extensions.txt")
        ShowHelp = false
    }

let usage =
    $"""Usage:
  dotnet fsi --exec -- {scriptName} [options]
  ./{scriptName} [options]

Installs VS Code extensions listed in an extension manifest.

The manifest format is one extension ID per line. Blank lines are ignored.
Inline comments start with '#', for example:

  Ionide.Ionide-fsharp # F# language support.

Options:
  --dry-run                  Print install commands without running them.
  --extensions-file <path>   Read extensions from <path>. Defaults to ./extensions.txt.
  --code <command>           VS Code CLI command to run. Defaults to $VSCODE_CLI or 'code'.
  -h, --help                 Show this help text.
"""

let printUsage () =
    printf "%s" usage

let failWithUsage message =
    eprintfn "Error: %s" message
    eprintfn ""
    eprintf "%s" usage
    exit 2

let requireValue optionName (remaining: string list) =
    match remaining with
    | value :: tail when not (value.StartsWith("-", StringComparison.Ordinal)) -> value, tail
    | _ -> failWithUsage $"{optionName} requires a value."

let rec parseArgs options args =
    match args with
    | [] -> options
    | "--dry-run" :: tail ->
        parseArgs { options with DryRun = true } tail
    | "--extensions-file" :: tail ->
        let value, rest = requireValue "--extensions-file" tail
        parseArgs { options with ExtensionsFile = Path.GetFullPath(value) } rest
    | "--code" :: tail ->
        let value, rest = requireValue "--code" tail
        parseArgs { options with CodeCommand = value } rest
    | ("-h" | "--help") :: tail ->
        parseArgs { options with ShowHelp = true } tail
    | unknown :: _ ->
        failWithUsage $"Unknown argument '{unknown}'."

let parseExtensionLine (line: string) =
    let content =
        match line.IndexOf("#", StringComparison.Ordinal) with
        | -1 -> line
        | index -> line.Substring(0, index)

    content.Trim()

let loadExtensions path =
    if not (File.Exists(path)) then
        failWithUsage $"Extension manifest not found: {path}"

    File.ReadLines(path)
    |> Seq.map parseExtensionLine
    |> Seq.filter (String.IsNullOrWhiteSpace >> not)
    |> Seq.toList

let installExtension options extensionId =
    if options.DryRun then
        printfn "%s --install-extension %s" options.CodeCommand extensionId
        Ok()
    else
        let startInfo = ProcessStartInfo()
        startInfo.FileName <- options.CodeCommand
        startInfo.ArgumentList.Add("--install-extension")
        startInfo.ArgumentList.Add(extensionId)
        startInfo.UseShellExecute <- false

        try
            use proc = Process.Start(startInfo)

            if isNull proc then
                Error "Process did not start."
            else
                proc.WaitForExit()

                if proc.ExitCode = 0 then
                    Ok()
                else
                    Error $"Exited with code {proc.ExitCode}."
        with
        | :? Win32Exception as ex ->
            Error $"Unable to start '{options.CodeCommand}': {ex.Message}"

let args =
    fsi.CommandLineArgs
    |> Array.skip 1
    |> Array.toList

let options =
    parseArgs defaultOptions args

if options.ShowHelp then
    printUsage ()
    exit 0

let extensions =
    loadExtensions options.ExtensionsFile

if extensions.IsEmpty then
    failWithUsage $"Extension manifest contains no extension IDs: {options.ExtensionsFile}"

let failures =
    extensions
    |> List.choose (fun extensionId ->
        printfn "Installing %s" extensionId

        match installExtension options extensionId with
        | Ok() -> None
        | Error message -> Some(extensionId, message))

if failures.Length > 0 then
    eprintfn ""
    eprintfn "Failed to install %d extension(s):" failures.Length

    for extensionId, message in failures do
        eprintfn "- %s: %s" extensionId message

    exit 1
