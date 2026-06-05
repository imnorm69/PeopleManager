# PeopleManager — Requirements

## Application Foundation

1. Windows Desktop application using WinForms, C#, .NET 9.
2. SQL Server database on `WIN1164`; database name `BAPeopleMgr`; login `BAPeopleDev` / `Developer`.
3. Single-user application — runs only on the developer's own PC; no login screen, no heavy security.
4. Database is created automatically on first launch via EF Core `EnsureCreated`; incremental schema updates are applied at startup without manual migration steps.

---

## People Module

5. A **Person** record stores: First Name (required), Last Name (required), Start Date (required).
6. People list supports search by name and a status filter: **Active Only** (default), **All**, **Separated**.
7. **Job Title** is stored in a related table with an effective date. The most recent entry by effective date is the current title. Full history is retained.
8. **Project / Team assignments** record the date the change was entered and the date it becomes effective. A person may be assigned to multiple teams simultaneously.
9. Removing a person from a team sets a removal date on that assignment; the full history of all assignments is retained.
10. **Separation**: choose a reason — End of Internship, Voluntary Resignation, Termination, or Other. When Other is selected, notes are required. A separation closes the active employment period and marks the person inactive.
11. **Re-hire**: sets a new hire date and new job title, opens a new employment period, and marks the person active again. All prior history (meetings, action items, glows/grows, team assignments) is preserved.
12. **Employment History** tab on the person detail screen shows every employment period with hire date, separation date, reason, and notes.

---

## Glows & Grows Module

13. Record **Glows** (praise) and **Grows** (constructive criticism) for any person.
14. Each entry stores: person, type (Glow / Grow), note text (VARCHAR MAX), and the date it was recorded.
15. Track when each item was **communicated** to the employee (optional date field; can be set later).
16. **Source** field (optional): free text describing the origin of the observation — e.g., *"Emailed from PO"*, *"Observed during shadow of refinement meeting"*.
17. List view supports filters: person, type (All / Glows / Grows), and a "Not Yet Communicated" toggle.
18. Single-click **Mark Communicated** button sets today's date on the selected item.

---

## 1:1 Meetings Module

### Meeting Initiation
19. Clicking **New Meeting** opens a small dialog: person selector (required — no default, cannot proceed without selection) and date picker (defaults to today).

### Meeting Window — Header
20. Person's name displayed **bold and left-justified**; meeting date displayed **bold and right-justified** across the top of the window.

### Right Panel — Glows & Grows Delivery
21. The right side of the meeting window shows uncommunicated Glows in a CheckedListBox above uncommunicated Grows in a separate CheckedListBox.
22. Each item displays the note text (truncated to fit); items may be cut off.
23. **Checking** an item in either list marks it as Communicated with the meeting date when the meeting is saved.
24. **Double-clicking** any item opens a read-only detail modal showing: person, type, source, full note text, date recorded, and communicated date (if any).

### Notes Section *(not yet implemented)*
25. Five note categories, each holding free-form text (VARCHAR MAX):
    - Glows / Grows *(used to document delivery of glows/grows discussed in this meeting)*
    - Project Notes
    - Career Updates
    - Training Updates
    - Action Items

### Bottom Panel — Action Items (Tab 1, default)
26. Lists **all action items** for this person. Columns: Date Added, Assigned To, Description, Due Date.
27. Filter defaults to **Open Only**; can be switched to **All**.
28. **Overdue items** (DueDate < today, not complete) are highlighted with a consistent background / foreground color. This same color scheme is used wherever overdue or attention-required items appear in the app.
29. **Add Action Item** button opens a modal with:
    - Description field (VARCHAR MAX) with **@-mention autocomplete** (see req. 30).
    - **Assigned To**: "Manager" or the person the meeting is with.
    - **Due Date**: defaults to meeting date + 14 days.
    - Date Added is set automatically to the meeting date.
30. **@-mention autocomplete**: typing `@` in the description field triggers a dropdown filtered by subsequent characters. Arrow keys navigate the list; Tab or click commits the selection. The tag is stored as plain text in the format `@FirstName LastName`. The person being met with is excluded from the suggestion list.
31. Action items for the person are visible even when created in prior meetings (i.e., the list is not limited to items from the current session).
32. Mark an action item **complete** with a completion date and optional completion notes. *(not yet implemented)*

### Bottom Panel — Mentions (Tab 2)
33. Shows open action items from **other people's** meetings where the current meeting person is tagged (`@FirstName LastName` appears in the description). Columns: Their Meeting Person, Description, Due Date. Same overdue highlighting applies.

### Checklist Items in Meetings *(not yet implemented — depends on Templates module)*
34. When opening a meeting for a person, show all template items assigned to that person (which may come from multiple templates).
35. For each item, show the date it was last evaluated and the calculated next due date (last evaluated + check frequency).
36. Items sorted by next due date ascending (soonest first). Overdue items highlighted with the same consistent color scheme.

---

## Dashboard

37. The **Dashboard** is the default view when the app opens.
38. Displays all open action items across all people.
39. Items assigned to **Manager** appear at the top; remaining items sorted by date created.
40. Filter: All Open (default), Assigned to Me, Assigned to Person.

---

## Checklist Questions Module *(not yet implemented)*

> **Design revision:** The original template-based approach (templates → items → assign template to person) was replaced with a simpler direct-assignment model. There are no templates. Instead, individual questions are created and assigned directly to each person, with the review frequency set per person at assignment time.

41. Create and manage a list of **checklist questions**. Each question has:
    - **Description** (text, up to 500 characters)
    - **Value Type**: the type of response expected when the question is evaluated (e.g., Yes/No, Integer, Text, Percentage — full set subject to review).
42. A question can be **assigned to one or more people**. The assignment specifies the **review frequency** for that person (Weekly, Bi-Weekly, Monthly, Quarterly, Semi-Annual, Annual). The same question may have different frequencies for different people.
43. Checklist item **evaluation history** is stored per person per question, recording the date evaluated, the value entered, and any notes.
44. In 1:1 meetings, the questions assigned to the person appear (see req. 34–36).

---

## Completed Items

| # | Requirement | Status |
|---|-------------|--------|
| 1 | WinForms, C#, .NET 9 | ✅ Complete |
| 2 | SQL Server — WIN1164, BAPeopleMgr, BAPeopleDev | ✅ Complete |
| 3 | Single-user, no login | ✅ Complete |
| 4 | Auto-create DB + incremental schema migrations at startup | ✅ Complete |
| 5 | Person record: First Name, Last Name, Start Date | ✅ Complete |
| 6 | People list with search and Active/All/Separated filter | ✅ Complete |
| 7 | Job Title history with effective dates; current title displayed | ✅ Complete |
| 8 | Team/Project assignments with dates; multiple simultaneous | ✅ Complete |
| 9 | Remove from team preserves history | ✅ Complete |
| 10 | Separation with reason; Other requires notes | ✅ Complete |
| 11 | Re-hire with new start date and job title | ✅ Complete |
| 12 | Employment History tab on person detail | ✅ Complete |
| 13 | Glows & Grows recording | ✅ Complete |
| 14 | Entry fields: person, type, note, date recorded | ✅ Complete |
| 15 | Communicated date tracking | ✅ Complete |
| 16 | Source field | ✅ Complete |
| 17 | Glows & Grows list with filters | ✅ Complete |
| 18 | Mark Communicated button | ✅ Complete |
| 19 | New Meeting dialog — person required, date defaults today | ✅ Complete |
| 20 | Meeting window header — name left, date right, both bold | ✅ Complete |
| 21 | Right panel CheckedListBoxes — Glows above Grows | ✅ Complete |
| 22 | Note text displayed (truncated) in list | ✅ Complete |
| 23 | Checking marks Communicated on Save | ✅ Complete |
| 24 | Double-click opens Glow/Grow detail modal | ✅ Complete |
| 25 | Notes section — five categories, VARCHAR MAX | ⬜ Not yet implemented |
| 26 | Action Items tab — columns, Open Only / All filter | ✅ Complete |
| 27 | Overdue item highlighting (consistent color scheme) | ✅ Complete |
| 28 | Add Action Item modal — description, assigned to, due date | ✅ Complete |
| 29 | @-mention autocomplete in action item description | ✅ Complete |
| 30 | Action items from prior meetings shown | ✅ Complete |
| 31 | @-mention excludes meeting person from suggestions | ✅ Complete |
| 32 | Mark action item complete with date and notes | ⬜ Not yet implemented |
| 33 | Mentions tab — other people's items tagging this person | ✅ Complete |
| 34 | Checklist items in meetings | ⬜ Not yet implemented |
| 35 | Last evaluated date and next due date per item | ⬜ Not yet implemented |
| 36 | Checklist items sorted by next due, overdue highlighted | ⬜ Not yet implemented |
| 37 | Dashboard is default view | ✅ Complete |
| 38 | Dashboard shows all open action items | ✅ Complete |
| 39 | Dashboard — Manager items first, then by date created | ✅ Complete |
| 40 | Dashboard filter: All Open / Assigned to Me / Assigned to Person | ✅ Complete |
| 41 | Checklist question: description + value type | ✅ Complete (UI — data entry only) |
| 42 | Assign question to people with per-person frequency | ✅ Complete (UI — assignment grid) |
| 43 | Evaluation history per person per question | ⬜ Not yet implemented |
| 44 | Checklist questions shown in 1:1 meetings | ⬜ Not yet implemented |
