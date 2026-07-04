# PeopleManager — Requirements

## Overview
A Blazor Server web app (.NET 9 + MudBlazor 8.x) for managers to track their direct reports, 1:1 meetings, action items, feedback, team/project assignments, shadowing/mentoring quotas, and checklist-based reviews. Accessed via browser (Kestrel-hosted); deployed via Docker Compose (see `INSTALL.md`) or run locally with `dotnet run`. Data is stored in a SQLite file — defaults to `%LOCALAPPDATA%\PeopleManager\people.db` locally, or `/data/people.db` in the Docker deployment (overridable via the `DatabasePath` config key).

---

## Implemented

### People Management
- View a list of all active and inactive direct reports, with a "Show Inactive" toggle, sortable by name
- Add a new person (first name, last name, start date) — an initial employment period is created automatically
- Edit a person's basic info (name, start date)
- View a person's detail page, including:
  - Employment History tab — hire/separation/reason table, plus job title history below it (newest first, current title bolded, each with a Previous Department yes/no flag defaulting to No)
  - Teams tab — current and historical team/project assignments
  - Meetings tab — list of 1:1 meetings for the person
  - Checklist History tab — all recorded checklist answers for the person
  - Shadowing tab — see Shadowing below
- Separate a person (separation date, reason, notes — notes required when reason is "Other")
- Re-hire a previously separated person (new start date and new job title, both required)
- People are marked active/inactive rather than deleted

### Team / Project Assignments
- View a person's current and historical team assignments
- Add a team assignment — free-type a new team name or select an existing one from all distinct teams in the system
- Click an assignment to edit its team, effective date, or removed date, or delete it

### 1:1 Meetings
- List all meetings, filterable by person, sortable by person/date
- Create a new meeting (select person, select date)
- Open an existing meeting to view or edit
- Meeting form includes:
  - Categorised notes tabs: Project Notes, Career Updates, Training Updates, General Notes
  - Checklist tab — shows assigned checklist items and frequency for the person; answers recorded per meeting with an optional comment and a history view of past answers
  - Action Items tab — add, complete, delete; toggle to show/hide completed; overdue items shown in red
  - Mentions tab — other people's open action items whose description text contains this person's first name (plain substring match, not true @-mention autocomplete — see Remaining)
  - Glows & Grows panel — shows this person's uncommunicated glows/grows; check items off to mark as communicated when the meeting is saved; click an item to open its detail

### Action Items
- Create action items within a meeting: description, assignee (Me or the person), due date
- Mark an action item complete (with optional completion notes and completed date)
- Delete an action item
- Overdue items (incomplete, past due date) are highlighted in red on the Dashboard and Meeting form

### Glows & Grows
- View all glow/grow feedback across all people, with filters (person, type, hide communicated)
- Add a new glow or grow (person, type, note, optional source, date)
- Edit an existing glow/grow (note, source, date)
- Delete a glow/grow
- Mark glows/grows as communicated (via the Meeting form's Glows & Grows panel)

### Checklist Items
- Manage a library of checklist items (description, answer value type: yes/no, integer, percentage, text, or date; sort order)
- Assign items to specific people with a review frequency (weekly / bi-weekly / monthly / quarterly / semi-annual / annual)
- Answers are recorded per person per meeting, with an optional comment and a history view of past answers

### Dashboard
- Shows all open (incomplete) action items across all direct reports, sorted by assignee, then due date, then person
- Overdue items highlighted in red/bold
- Click a person's name to go to their detail page
- (No assignee filter, inline complete/delete, or manual refresh yet — see Remaining)

### Shadowing
- Log a shadow session on a person's Shadowing tab: date, shadower (must be a person tracked in the system — they earn the quota points), observed person (free text; doesn't have to be someone tracked in the system), team observed, and event type
- Click a logged session to edit or delete it
- Shadowing tab lists all sessions newest-first in one flat list, with a Year-Quarter separator inserted above each quarter's sessions
- Separators only appear for quarters in 2026 or later, during which the person was actually employed (based on hire/separation dates); a qualifying quarter still gets a separator even if zero sessions were logged in it
- Each separator shows whether the shadowing point requirement was met for that quarter (points earned vs. required)
- Shadow point requirements are entirely optional, controlled by the global "Enable Shadow Requirements" admin setting — when off, no point values, requirement separators, or point-related fields appear anywhere outside Admin, but session logging itself still works
- Each person has their own default required points per quarter (editable on their Shadowing tab), seeded from the admin-configured global default when the person is created
- The first time a shadow session is logged for a person in a quarter with no recorded requirement yet, a dialog prompts to confirm or adjust that quarter's required points before saving

### Admin
- `/admin` — landing page linking to admin tools (accessible via an Admin link pinned to the bottom of the left nav)
- **Shadowing Event Types** (`/admin/event-types`) — add, edit, and activate/deactivate the ceremony/event types available when logging shadow sessions, each with a quota point value (0.5 or 1.0)
- **Shadowing Settings** (`/admin/shadow-settings`) — enable/disable shadow point requirements globally, and set the default per-quarter point requirement (used to seed new people and pre-fill the quarter-requirement confirmation dialog)

---

## Remaining

### Dashboard
- Filter by assignee: All Open, Assigned to Me, Assigned to Person
- Mark complete or delete an action item directly from the dashboard
- Manual refresh button
- Add an **Overdue** section (grouped/sorted by person), separate from the flat list
- Add a **Due This Week** section (incomplete items due within the next 7 days)

### Person Detail
- Add an Action Items view showing overdue and due-this-week items for that person

### Meeting Form
- Surface items due within the next 7 days in the Action Items panel (overdue is already highlighted; due-this-week is not yet distinguished)

### Action Items
- True @-mention autocomplete when typing a description (currently the Mentions tab does a plain substring match against the person's first name — no autocomplete UI)

### People Management
- Option to set an initial job title when adding a new person (currently it must be added afterward via the Employment History tab)

### Reporting
- Generate a report for a single person over a date range — meeting summaries, action items, glows/grows, checklist responses (format TBD: PDF / RTF / HTML)
- Generate a weekly summary report across all direct reports — meetings held, action items created/completed/overdue, new glows/grows (format TBD: PDF / RTF / HTML)

### Shadowing
- Dashboard flag for people falling behind on their quarterly shadowing quota — timing TBD (likely ~2 weeks before quarter end)
