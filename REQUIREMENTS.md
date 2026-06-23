# PeopleManager — Requirements

## Overview
A Windows desktop application (WinForms / .NET 9) for managers to track their direct reports, 1:1 meetings, action items, feedback, and checklist-based reviews. Data is stored locally in a SQLite file (`%LOCALAPPDATA%\PeopleManager\people.db`).

---

## Implemented

### People Management
- View a list of all active and inactive direct reports
- Add a new person with first name, last name, start date, and initial job title
- Edit a person's basic info (name, start date)
- View a person's detail page, including:
  - Job titles history (title, effective date, current flag)
  - Team / project assignments (current and history)
  - Employment history (hire date, separation date, reason, notes)
- Separate a person (record separation date, reason, and optional notes)
- Re-hire a previously separated person (new start date and job title)
- People are marked active/inactive rather than deleted

### 1:1 Meetings
- List all 1:1 meetings for a person, sorted by date
- Create a new meeting (select person, select date)
- Open an existing meeting to view or edit
- Meeting form includes:
  - Categorised notes tabs: Project Notes, Career Updates, Training Updates, General Notes
  - Checklist tab — shows assigned questions for the person; answers recorded per meeting
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

### Checklist Questions
- Manage a library of checklist questions (description, answer value type: text / yes-no / rating)
- Assign questions to specific people with a review frequency (daily / weekly / monthly / quarterly / annually)
- Answers are recorded per person per meeting

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
