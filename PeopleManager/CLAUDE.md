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
  - `Layout/` — `MainLayout.razor`, `NavMenu.razor` (Admin link pinned to bottom via a flex spacer)
  - `Pages/` — Dashboard, People/, Meetings/, GlowsGrows/, ChecklistItems/, Admin/
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
- People: list, add/edit, PersonDetail with Employment History (periods + job titles, incl. Previous Department flag) / Teams (add/edit/delete assignments) / Meetings / Checklist History / Shadowing tabs
- 1:1 Meetings: list, MeetingDetail with notes tabs (Project/Career/Training/General/Checklist) + action items + glows/grows communicate panel
- Glows & Grows: filterable list, add/edit/delete
- Checklist Items: item list, add item, assign to person with frequency
- Shadowing: log/edit/delete shadow sessions (shadower must be a tracked person; observed person is free text, not linked); Shadowing tab shows one flat newest-first list with Year-Quarter separators (only for 2026+ quarters during employment, shown even with zero sessions) each carrying a met/not-met indicator
- Shadow requirements are entirely optional (Admin > Shadowing Settings global toggle) — when off, no points/quota UI renders anywhere outside Admin; each person has their own default required points/quarter, and first-use-per-quarter prompts to confirm/override it (`PersonShadowRequirement` table)
- Admin (`/admin`, linked from the bottom of the nav): Shadowing Event Types (name + 0.5/1.0 points, active/inactive) and Shadowing Settings (enable toggle + default point requirement)
