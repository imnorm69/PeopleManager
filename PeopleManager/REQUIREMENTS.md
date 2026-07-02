# PeopleManager — Requirements

## Overview
A Blazor Server web app (.NET 9 + MudBlazor 8.x) for managers to track their direct reports, 1:1 meetings, action items, feedback, and checklist-based reviews. Accessed via browser (Kestrel-hosted). Data is stored in a SQLite file — defaults to `%LOCALAPPDATA%\PeopleManager\people.db` locally, overridable via the `DatabasePath` config key (used in production, deployed via systemd/LXC).

---

## Implemented

### People Management
- View a list of all active and inactive direct reports, with a "Show Inactive" toggle, sortable by name
- Add a new person (first name, last name, start date) — an initial employment period is created automatically
- Edit a person's basic info (name, start date)
- View a person's detail page, including:
  - Employment History tab — hire/separation/reason table, plus job title history below it (newest first, current title bolded)
  - Teams tab — current and historical team/project assignments
  - Meetings tab — list of 1:1 meetings for the person
- Separate a person (separation date, reason, notes — notes required when reason is "Other")
- Re-hire a previously separated person (new start date and new job title, both required)
- People are marked active/inactive rather than deleted

### 1:1 Meetings
- List all meetings, filterable by person, sortable by person/date
- Create a new meeting (select person, select date)
- Open an existing meeting to view or edit
- Meeting form includes:
  - Categorised notes tabs: Project Notes, Career Updates, Training Updates, General Notes
  - Checklist tab — shows assigned checklist items and frequency for the person; answers recorded per meeting
  - Action Items tab — add, complete, delete; toggle to show/hide completed; overdue items shown in red
  - Mentions tab — other people's open action items whose description text contains this person's first name (plain text match)
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
- Answers are recorded per person per meeting

### Dashboard
- Shows all open (incomplete) action items across all direct reports, sorted by assignee, then due date, then person
- Overdue items highlighted in red/bold

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
