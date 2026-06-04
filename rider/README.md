# Rider IDE Configuration

This folder contains pruned JetBrains Rider IDE local settings and configuration files. These settings are captured from Rider 2026.1 and represent only the meaningful, project-relevant configurations—all telemetry, analytics, window state, and machine-specific data have been removed.

## Folder Structure

### `colors/` (2 files)
User-customized color themes for the Rider editor:
- `_@user_Rider Light.icls` — Custom light theme
- `_@user_Solarized Dark - Hard Gray _4lex4_.icls` — Custom Solarized dark theme

**Why kept**: These are custom color preferences that improve the development experience across team members.

### `keymaps/` (1 file)
- `IntelliJ IDEA Classic copy.xml` — Custom keyboard shortcuts based on IntelliJ IDEA Classic layout

**Why kept**: Custom keyboard shortcuts ensure consistent key bindings across developers.

### `options/` (33 files)
Core IDE configuration files grouped by function:

#### **Editor & Display Settings**
| File | Purpose |
|------|---------|
| `editor.xml` | Core editor behavior (line numbers, whitespace display, auto-complete) |
| `editor-font.xml` | Font configuration (Cascadia Code, ligatures, line spacing) |
| `editor.codeinsight.xml` | Code completion settings & behavior |
| `laf.xml` | Look & feel / UI theme settings |
| `gutter.xml` | Gutter markers, line numbers, and run/debug icons |
| `ui.lnf.xml` | UI look & feel preferences |

#### **Code Style & Formatting**
| File | Purpose |
|------|---------|
| `codeLens.xml` | Code lens visibility settings |
| `customization.xml` | Toolbar customization (e.g., VCS group layout) |
| `overrideFileTypes.xml` | File type associations |

#### **Search & Navigation**
| File | Purpose |
|------|---------|
| `find.xml` | Find/search settings & file masks |
| `filetypes.xml` | File type recognitions & ignore patterns |

#### **Development Tools**
| File | Purpose |
|------|---------|
| `debugger.xml` | Debugger configuration (exception handling, breakpoints) |
| `vcs.xml` | Version control system settings |
| `terminal.xml` | Terminal behavior & appearance |
| `profilerRunConfigurations.xml` | Profiler execution configurations |

#### **Language & Framework Support**
| File | Purpose |
|------|---------|
| `nodejs.xml` | Node.js runtime settings |
| `vim_settings.xml` | Vim keybindings plugin configuration |
| `vim_settings_local.xml` | Local Vim settings overrides |
| `vsts_settings.xml` | Azure DevOps / VSTS integration |
| `gitlab.xml` | GitLab integration settings |
| `mcpServer.xml` | Model Context Protocol server configuration |
| `web-types-npm-loader.xml` | Web types & npm loader configuration |

#### **Data & Database**
| File | Purpose |
|------|---------|
| `databaseDrivers.xml` | Database driver configurations (MySQL, Cassandra, Snowflake) |
| `databaseSettings.xml` | Database parameter patterns & query formatting |
| `csvSettings.xml` | CSV/TSV/Pipe-separated format definitions |

#### **Notifications & UI**
| File | Purpose |
|------|---------|
| `notifications.xml` | Notification preferences & popups |
| `advancedSettings.xml` | Advanced IDE options (native file chooser, terminal focus) |
| `ide.general.xml` | General IDE settings (startup, exit behavior) |

#### **Project & Workspace**
| File | Purpose |
|------|---------|
| `project.default.xml` | Default project settings |
| `colors.scheme.xml` | Active color scheme selection |
| `window.layouts.xml` | Window layout definitions |

#### **Other**
| File | Purpose |
|------|---------|
| `other.xml` | Miscellaneous IDE settings |

### `rider.vmoptions`
JVM virtual machine options for the Rider IDE process:
- Controls memory allocation, garbage collection, and JVM parameters
- Ensure adequate heap size for your system

## What Was Removed

To create a clean, team-friendly configuration, the following categories of files were **removed**:

### Telemetry & Analytics (10 files)
- `usage.statistics.xml` — Usage tracking
- `features.usage.statistics.xml` — Feature usage metrics
- `dailyLocalStatistics.xml` — Daily activity statistics
- `trace_license_storage.xml` — License telemetry
- `ml.completion.xml` — ML model analytics
- `llm.for.code.xml` — LLM telemetry
- `inline.factors.completion.xml` — Completion acceptance metrics
- `full.line.xml` — Full-line completion tracking
- `qodana.xml` — Code quality metrics
- `EventLogAllowedList.xml` — Telemetry configuration

### UI State & Window Layout (5 files)
- `window.state.xml` — Window position/size (machine-specific)
- `rider.perapp.window.state.v2.xml` — Per-app window state
- `runner.layout.xml` — Tool window layout state
- `RiderPerAppSettingsManager.xml` — Per-app UI state
- `usageView.xml` — Usage view state

### AI/Copilot/Onboarding (8 files)
- `AINaturalLanguagePromotionState.xml` — AI promotion popups
- `AIOnboardingPromoWindowAdvisor.xml` — AI onboarding state
- `github-copilot.local.xml` — Copilot machine-specific state
- `github-copilot.xml` — Copilot notification state
- `ide-features-trainer.xml` — IDE tutorial progress
- `InstallJunieHubActionManager.xml` — Hub installation state
- `llm.mcpServers.xml` — MCP server state
- `llm.nextEdits.xml` — Next edits feature state

### Machine-Specific & Project References (13 files)
- `recentSolutions.xml` — Recent projects list
- `recentSolutionsConfiguration.xml` — Recent projects config
- `sshRecentConnections.v2.xml` — SSH connection history
- `sshRecentConnectionsHost.xml` — SSH host configurations
- `trusted-paths.xml` — Trusted directory paths
- `trustedSolutions.xml` — Trusted project paths
- `remote-servers.xml` — Remote server credentials
- `proxy.settings.xml` — Network proxy settings
- `riderVersions.xml` — Version tracking
- `path.macros.xml` — Path macros (often machine-specific)
- `ignored-suggested-plugins.xml` — Plugin suggestions
- `settingsSync.xml` — Settings sync state
- `embeddings-activation.xml` — AI embeddings timestamp

### Empty/Default/Minimal (13 files)
- `console-font.xml` — Default console font
- `dataViewsSettings.xml` — Empty data grid settings
- `diff.xml` — Migration flag only
- `DontShowAgainFeedbackService.xml` — Empty feedback state
- `CommonFeedbackSurveyService.xml` — Empty survey state
- `contributorSummary.xml` — Search contributor stats
- `ide.general.local.xml` — Default project directory (empty)
- `images.support.xml` — Default image editor settings
- `keymapFlags.xml` — Keymap migration flags
- `log-categories.xml` — Logging categories
- `terminal-font.xml` — Terminal font (default)
- `updates.xml` — Update checking state
- `textmate.xml` — TextMate support (unused)

**Total removed: 49 files**

## How to Use These Settings

### Option 1: Manual Import (Recommended for Teams)
1. Open Rider IDE
2. Go to **Rider > Preferences** (macOS) or **File > Settings** (Linux/Windows)
3. Use **Import** or drag files into settings
4. Restart Rider for changes to take effect

### Option 2: Direct Filesystem Copy (Advanced)
1. Close Rider IDE completely
2. Copy the folders from this directory to your local Rider settings directory:
   - **macOS**: `~/Library/Application Support/JetBrains/Rider<version>/`
   - **Linux**: `~/.config/JetBrains/Rider<version>/`
   - **Windows**: `%APPDATA%\JetBrains\Rider<version>\`
3. Restart Rider

### Option 3: Integrate into Setup Procedure
Include references to this folder in your project's development environment setup documentation to ensure all developers use consistent:
- Code formatting and style rules
- Keyboard shortcuts
- Color themes and IDE appearance
- Debugger and profiler settings
- Database and version control integration

## Critical Settings by Use Case

### For C# Development
- `debugger.xml` — Exception handling configuration
- `editor.xml` — Code completion behavior
- `vcs.xml` — Git integration
- `databaseDrivers.xml` — If working with databases

### For Full-Line Code Completion
- `editor.codeinsight.xml` — Completion settings
- Note: Full-line AI completion telemetry has been removed

### For Terminal Work
- `terminal.xml` — Terminal appearance & behavior
- `vim_settings.xml` & `vim_settings_local.xml` — If using Vim keybindings

### For Multi-Language Development
- `nodejs.xml` — JavaScript/Node.js support
- `vsts_settings.xml` — Azure DevOps integration
- `gitlab.xml` — GitLab integration
- `mcpServer.xml` — LLM context protocol setup

## Maintenance & Updates

To keep these settings current:

1. **After making significant IDE changes locally:**
   - Copy the updated configuration folders back to this directory
   - Document what changed and why in a commit message

2. **Recommended update frequency:**
   - After installing IDE plugins
   - After adjusting code style or editor preferences
   - After configuring new integrations

3. **Before committing:**
   - Verify no machine-specific paths are included
   - Ensure no sensitive credentials in any XML files
   - Test settings on a fresh Rider installation if possible

## Notes

- **Version Compatibility**: Settings may vary between Rider versions. Rider often auto-migrates settings, but test on your target version.
- **Additive Configuration**: These settings enhance IDE defaults. Your IDE will still function with just the defaults.
- **Plugin Settings**: Some plugin configurations are included. Team members must have the same plugins installed.
- **Language-Specific**: Some settings (Vim, Node.js, GitLab) only apply if those tools/integrations are enabled.

---

**Last Updated**: June 4, 2026 (Rider 2026.1)  
**Files Included**: 39 configuration files  
**Telemetry/Superficial Removed**: 50 files  
**Reduction**: ~56% of original size while retaining 100% of project-relevant settings
