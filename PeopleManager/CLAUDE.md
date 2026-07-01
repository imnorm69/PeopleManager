# Project: PeopleManager

## Project Type
Blazor Server (branch `blazor`); WinForms legacy on `main`

## Target Framework
net9.0

## Tech Stack
- Language: C#
- Framework: Blazor Server (.NET 9) + MudBlazor 8.x
- Database: SQLite
- ORM: Entity Framework Core 9 (migrations in `PeopleManager/Migrations/`)

## Key Conventions
- Use async/await throughout
- `IDbContextFactory<AppDbContext>` injected via DI — each operation does `await using var db = await DbFactory.CreateDbContextAsync()`
- MudBlazor dialog instance: `[CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = null!;`
- All pages use `@inject IDbContextFactory<AppDbContext> DbFactory`
- Dialogs use typed `DialogParameters<TDialog>` for parameters

## Project Structure
- `Models/` — entity POCOs
- `Data/` — `AppDbContext`, `AppDbContextFactory` (design-time migrations)
- `Migrations/` — EF Core migration files
- `Components/` — all Blazor components
  - `App.razor`, `Routes.razor`, `_Imports.razor`
  - `Layout/` — `MainLayout.razor`, `NavMenu.razor`
  - `Pages/` — Dashboard, People/, Meetings/, GlowsGrows/, Questions/
  - `Dialogs/` — all MudBlazor dialog components
- `wwwroot/` — `app.css`
- `appsettings.json` — `DatabasePath` key for SQLite file location

## Build and Run
- Build: `dotnet build`
- Run: `dotnet run` — starts Kestrel on http://localhost:5000
- Prod DB path: set `DatabasePath=/var/lib/peoplemanager/people.db` env var in systemd unit
- Deploy: `dotnet publish -c Release -o ./publish` then rsync to LXC

## Modules Implemented
- Dashboard: open action items list (assignee + due date sort)
- People: list, add/edit, PersonDetail with Job Titles / Teams / Employment History / Meetings tabs
- 1:1 Meetings: list, MeetingDetail with notes tabs (Project/Career/Training/General/Checklist) + action items + glows/grows communicate panel
- Glows & Grows: filterable list, add/edit/delete
- Questions: checklist question list, add question, assign to person with frequency
