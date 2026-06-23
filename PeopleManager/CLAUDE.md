# Project: PeopleManager

## Project Type
winforms

## Target Framework
net9.0

## Project Structure
- `PeopleManager/` - main project

## Tech Stack
- Language: C#
- Framework: Windows Forms (.NET 9)
- Database: SQL Server (Server=WIN1164, DB=BAPeopleMgr, User=BAPeopleDev)
- ORM: Entity Framework Core 9 (EnsureCreated on startup — no migrations yet)

## Key Conventions
- Use async/await throughout (async void event handlers, async Task for logic)
- DbFactory.Create() returns a fresh DbContext per operation — dispose with `await using`
- All Forms use the standard WinForms partial-class pattern: FormName.cs (business logic) + FormName.Designer.cs (InitializeComponent)
- All layout belongs in InitializeComponent() in Designer.cs — never in a BuildUI() method
- DataGridView rows store their entity PK in row.Tag

## Project Structure
- Models/ — entity POCOs
- Data/ — AppDbContext + DbFactory (connection string lives in DbFactory.cs)
- Forms/ — dialog and full-page forms
- Controls/ — UserControls swapped into MainForm's content panel

## Build and Run
- Build: `dotnet build` or Ctrl+Shift+B in VS 2022
- Run: F5 or Ctrl+F5
- DB is auto-created on first run via EnsureCreated

## Modules Implemented
- Dashboard: open action items list (assignee + date sort)
- People: list, add/edit, PersonDetailForm with Job Titles + Teams tabs
- 1:1 Meetings: list, MeetingForm with notes tabs + action items + checklist review
- Glows & Grows: list with filters, add/edit, mark communicated
- Templates: list, ChecklistTemplateForm (label/category/items), AssignTemplateForm
