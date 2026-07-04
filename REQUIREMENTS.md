# PeopleManager — Requirements

## Overview
A Blazor Server web application (.NET 9, MudBlazor) for managers to track their direct reports, 1:1 meetings, action items, feedback, team assignments, shadowing/mentoring quotas, and checklist-based reviews. Hosted via Kestrel (e.g. in a private-LAN LXC container, no reverse proxy required). Data is stored in a SQLite file (`%LOCALAPPDATA%\PeopleManager\people.db` locally, or a path set via the `DatabasePath` config key in deployment).

---

## Implemented

### People Management
- View a list of all active and inactive direct reports
- Add a new person with first name, last name, start date, and initial job title
- Edit a person's basic info (name, start date)
- View a person's detail page, including:
  - Job titles history (title, effective date, Previous Department yes/no flag — defaults to No)
  - Team / project assignments (current and history)
  - Employment history (hire date, separation date, reason, notes)
  - Shadowing history (see below)
- Separate a person (record separation date, reason, and optional notes)
- Re-hire a previously separated person (new start date and job title)
- People are marked active/inactive rather than deleted

### Team / Project Assignments
- View a person's current and historical team assignments
- Add a team assignment — free-type a new team name or select an existing one from all distinct teams in the system
- Click an assignment to edit its team, effective date, or removed date, or delete it

### 1:1 Meetings
- List all 1:1 meetings for a person, sorted by date
- Create a new meeting (select person, select date)
- Open an existing meeting to view or edit
- Meeting form includes:
  - Categorised notes tabs: Project Notes, Career Updates, Training Updates, General Notes
  - Checklist tab — shows assigned questions for the person; answers recorded per meeting, with a comment field and history view per answer
  - Action items panel — add, complete, delete; filter open/all; @-mention tagging in descriptions
  - Mentions panel — shows open action items from other meetings that tag this person
  - Glows & Grows panel — check off glows and grows linked to this person

### Action Items
- Create action items within a meeting with a description, assignee (manager or person), and due date
- Descriptions support @-mention autocomplete to tag other people
- Mark an action item complete (with optional completion notes)
- Delete an action item
- Action items have overdue highlighting when past their due date

### Glows & Grows
- View all glow/grow feedback across all people, with filters
- Add a new glow or grow (person, type, source, note, optional communicated date)
- Edit an existing glow/grow
- Mark a glow/grow as communicated (record the date)

### Checklist Items
- Manage a library of checklist items (description, answer value type: yes/no, integer, text, percentage, date)
- Assign items to specific people with a review frequency (weekly / bi-weekly / monthly / quarterly / semi-annual / annual)
- Answers are recorded per person per meeting, with an optional comment and a history view of past answers

### Shadowing
- Log shadow sessions on a person's Shadowing tab: date, shadower (must be a person tracked in the system — they earn the quota points), observed person (free text; doesn't have to be someone tracked in the system), team observed, and event type
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

### Dashboard
- Shows all open action items across all direct reports
- Filter by assignee: All Open, Assigned to Me, Assigned to Person
- Mark complete or delete from the dashboard
- Refresh on demand

---

## Planned / In Progress

### Dashboard — Overdue and Due This Week sections
- Add an **Overdue** section to the dashboard showing all incomplete action items past their due date, grouped or sorted by person
- Add a **Due This Week** section showing incomplete action items due within the next 7 days
- Both sections should support Mark Complete and Delete inline

### Person Detail — Overdue and Due This Week
- Add an **Action Items** view to the Person Detail form showing:
  - All overdue (incomplete, past due date) action items for that person
  - All action items due within the next 7 days for that person

### Meeting Form — Overdue and Due This Week
- Within the Meeting form's action items panel, visually distinguish or surface:
  - Items that are overdue (past due date, not complete)
  - Items due within the next 7 days

### Generate Report — Individual
- Generate a formatted report for a single person covering a specified date range, including:
  - Meeting summaries (notes per category)
  - Action items (open and completed)
  - Glows and grows
  - Checklist responses
- Report format TBD (PDF / RTF / HTML)

### Generate Report — Weekly
- Generate a weekly summary report across all direct reports, including:
  - Meetings held that week
  - Action items created, completed, and overdue as of end of week
  - Any new glows/grows recorded
- Report format TBD (PDF / RTF / HTML)
