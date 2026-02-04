# Repository Guidelines

## Project Structure & Module Organization
The solution entry point is `ValToCsv.sln`. The WinForms application lives in `WindowsFormsApplication1/`, with UI logic in `FormMain.cs`, `FormSQL.cs`, and `FormTest.cs`, plus their paired `.Designer.cs` and `.resx` files. Shared assembly metadata and resources are in `WindowsFormsApplication1/Properties/`. Configuration and dependencies are tracked in `WindowsFormsApplication1/app.config` and `WindowsFormsApplication1/packages.config`. Build outputs are generated under `WindowsFormsApplication1/bin/` and `WindowsFormsApplication1/obj/`.

## Build, Test, and Development Commands
Run these from the repo root:

```powershell
nuget restore ValToCsv.sln
msbuild ValToCsv.sln /p:Configuration=Debug /p:Platform=x86
msbuild ValToCsv.sln /p:Configuration=Release /p:Platform=x86
```

After a successful build, launch `WindowsFormsApplication1\bin\Debug\ValToCSV.exe` (or `Release`) or run the solution in Visual Studio.

## Coding Style & Naming Conventions
This is a .NET Framework 4.8 WinForms app. Use 4-space indentation and place braces on their own line. Use `PascalCase` for types, methods, and enums; `camelCase` for locals and parameters. Keep WinForms file triads aligned by name (`FormName.cs`, `FormName.Designer.cs`, `FormName.resx`). Event handlers follow the existing pattern, e.g., `btnGenerate_Click`.

## Testing Guidelines
There are no automated tests or test projects. Validate changes by manually exercising the UI workflows in `FormMain` and `FormSQL`. If you add tests, create a dedicated test project (for example, `WindowsFormsApplication1.Tests`) and document how to run it.

## Commit & Pull Request Guidelines
Commit history uses short, lowercase, imperative messages (for example, `fix excel to sql`, `format`). Keep commits focused on a single behavior change. PRs should include a brief summary, manual test steps, and screenshots for UI changes. Call out any dependency changes (such as updates to `packages.config`).
