using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class PersonDetailForm : Form
{
    private readonly int _personId;
    private Label _lblName = null!;
    private Label _lblStatus = null!;
    private Button _btnSeparate = null!;
    private Button _btnReHire = null!;
    private TabControl _tabs = null!;

    // Job Titles tab
    private DataGridView _gridTitles = null!;
    // Teams tab
    private DataGridView _gridTeamsCurrent = null!;
    private DataGridView _gridTeamsHistory = null!;
    // Employment History tab
    private DataGridView _gridEmployment = null!;

    public PersonDetailForm(int personId)
    {
        _personId = personId;
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        Text = "Person Details";
        Size = new Size(820, 620);
        FormBorderStyle = FormBorderStyle.Sizable;
        MinimumSize = new Size(660, 500);
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        BackColor = Color.White;

        // ── Header ───────────────────────────────────────────────
        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 66,
            BackColor = Color.FromArgb(30, 58, 95),
            Padding = new Padding(16, 0, 8, 0)
        };

        var nameStack = new Panel { Dock = DockStyle.Left, Width = 460, BackColor = Color.Transparent };
        _lblName = new Label
        {
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 13f, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 36,
            TextAlign = ContentAlignment.BottomLeft
        };
        _lblStatus = new Label
        {
            ForeColor = Color.FromArgb(200, 220, 240),
            Font = new Font("Segoe UI", 8.5f, FontStyle.Italic),
            Dock = DockStyle.Top,
            Height = 22,
            TextAlign = ContentAlignment.TopLeft
        };
        nameStack.Controls.Add(_lblStatus);
        nameStack.Controls.Add(_lblName);

        var btnPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 290,
            FlowDirection = FlowDirection.RightToLeft,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 17, 0, 0)
        };

        _btnSeparate = MakeHeaderButton("Separate", Color.FromArgb(192, 57, 43));
        _btnReHire   = MakeHeaderButton("Re-hire",  Color.FromArgb(39, 174, 96));
        var btnEdit  = MakeHeaderButton("Edit Info", Color.FromArgb(41, 128, 185));

        _btnSeparate.Click += async (_, _) => await SeparateAsync();
        _btnReHire.Click   += async (_, _) => await ReHireAsync();
        btnEdit.Click      += async (_, _) => await EditBasicInfoAsync();

        btnPanel.Controls.AddRange(new Control[] { _btnSeparate, _btnReHire, btnEdit });
        header.Controls.Add(btnPanel);
        header.Controls.Add(nameStack);

        // ── Tabs ─────────────────────────────────────────────────
        _tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9f) };
        _tabs.TabPages.Add(BuildJobTitlesTab());
        _tabs.TabPages.Add(BuildTeamsTab());
        _tabs.TabPages.Add(BuildEmploymentHistoryTab());

        // ── Close button ─────────────────────────────────────────
        var btnClose = new Button
        {
            Text = "Close",
            DialogResult = DialogResult.OK,
            Dock = DockStyle.Bottom,
            Height = 36,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(52, 73, 94),
            ForeColor = Color.White
        };
        btnClose.FlatAppearance.BorderSize = 0;

        Controls.Add(_tabs);
        Controls.Add(header);
        Controls.Add(btnClose);
    }

    // ── Tab builders ─────────────────────────────────────────────

    private TabPage BuildJobTitlesTab()
    {
        var page = new TabPage("Job Titles");
        var toolbar = new FlowLayoutPanel
        {
            Dock = DockStyle.Top, Height = 40,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(8, 6, 0, 0)
        };
        var btnAdd = MakeSmallButton("+ Add Title", Color.FromArgb(39, 174, 96));
        btnAdd.Click += async (_, _) => await AddJobTitleAsync();
        toolbar.Controls.Add(btnAdd);
        _gridTitles = BuildSmallGrid(("Title", 260), ("Effective Date", 130), ("Current?", 80));
        page.Controls.Add(_gridTitles);
        page.Controls.Add(toolbar);
        return page;
    }

    private TabPage BuildTeamsTab()
    {
        var page = new TabPage("Teams / Projects");
        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            SplitterDistance = 200,
            Panel1MinSize = 120,
            Panel2MinSize = 80
        };

        var lblCurrent = new Label { Text = "Current Assignments", Font = new Font("Segoe UI", 9f, FontStyle.Bold), Dock = DockStyle.Top, Height = 22 };
        var btnToolbar = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 36, FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(4, 4, 0, 0) };
        var btnAdd    = MakeSmallButton("+ Assign Team", Color.FromArgb(39, 174, 96));
        var btnRemove = MakeSmallButton("Remove",        Color.FromArgb(192, 57, 43));
        btnAdd.Click    += async (_, _) => await AddTeamAssignmentAsync();
        btnRemove.Click += async (_, _) => await RemoveTeamAssignmentAsync();
        btnToolbar.Controls.AddRange(new Control[] { btnAdd, btnRemove });
        _gridTeamsCurrent = BuildSmallGrid(("Team/Project", 200), ("Assigned Date", 120), ("Effective Date", 120));
        split.Panel1.Controls.Add(_gridTeamsCurrent);
        split.Panel1.Controls.Add(btnToolbar);
        split.Panel1.Controls.Add(lblCurrent);

        var lblHistory = new Label { Text = "History", Font = new Font("Segoe UI", 9f, FontStyle.Bold), Dock = DockStyle.Top, Height = 22 };
        _gridTeamsHistory = BuildSmallGrid(("Team/Project", 200), ("Assigned", 110), ("Effective", 110), ("Removed", 110));
        split.Panel2.Controls.Add(_gridTeamsHistory);
        split.Panel2.Controls.Add(lblHistory);

        page.Controls.Add(split);
        return page;
    }

    private TabPage BuildEmploymentHistoryTab()
    {
        var page = new TabPage("Employment History");
        _gridEmployment = BuildSmallGrid(
            ("Hire Date", 110), ("Separation Date", 120),
            ("Reason", 170), ("Notes", 260));
        _gridEmployment.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        page.Controls.Add(_gridEmployment);
        return page;
    }

    // ── Data loading ─────────────────────────────────────────────

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var person = await ctx.People
            .Include(p => p.JobTitles)
            .Include(p => p.ProjectAssignments).ThenInclude(a => a.ProjectTeam)
            .Include(p => p.EmploymentPeriods)
            .FirstOrDefaultAsync(p => p.PersonId == _personId);

        if (person == null) return;

        _lblName.Text = person.FullName;

        // Active status label + button visibility
        if (person.IsActive)
        {
            var activePeriod = person.EmploymentPeriods
                .Where(p => p.SeparationDate == null)
                .OrderByDescending(p => p.HireDate)
                .FirstOrDefault();
            var hireDate = activePeriod?.HireDate ?? person.StartDate;
            _lblStatus.Text = $"Active  |  Hired: {hireDate:MM/dd/yyyy}";
            _btnSeparate.Visible = true;
            _btnReHire.Visible   = false;
        }
        else
        {
            var lastPeriod = person.EmploymentPeriods
                .Where(p => p.SeparationDate != null)
                .OrderByDescending(p => p.SeparationDate)
                .FirstOrDefault();
            var sepDate   = lastPeriod?.SeparationDate?.ToString("MM/dd/yyyy") ?? "—";
            var sepReason = lastPeriod?.SeparationReason?.ToString() ?? "";
            _lblStatus.Text      = $"Separated  |  {sepDate}  |  {FormatReason(lastPeriod?.SeparationReason)}";
            _lblStatus.ForeColor = Color.FromArgb(255, 180, 160);
            _btnSeparate.Visible = false;
            _btnReHire.Visible   = true;
        }

        // Job titles
        _gridTitles.Rows.Clear();
        var titles = person.JobTitles.OrderByDescending(j => j.EffectiveDate).ToList();
        for (int i = 0; i < titles.Count; i++)
        {
            var jt = titles[i];
            _gridTitles.Rows.Add(jt.Title, jt.EffectiveDate.ToShortDateString(), i == 0 ? "✓" : "");
            _gridTitles.Rows[^1].Tag = jt.PersonJobTitleId;
        }

        // Teams – current
        _gridTeamsCurrent.Rows.Clear();
        foreach (var a in person.ProjectAssignments.Where(a => a.RemovedDate == null).OrderBy(a => a.EffectiveDate))
        {
            _gridTeamsCurrent.Rows.Add(a.ProjectTeam.Name, a.AssignedDate.ToShortDateString(), a.EffectiveDate.ToShortDateString());
            _gridTeamsCurrent.Rows[^1].Tag = a.AssignmentId;
        }

        // Teams – history
        _gridTeamsHistory.Rows.Clear();
        foreach (var a in person.ProjectAssignments.Where(a => a.RemovedDate != null).OrderByDescending(a => a.RemovedDate))
        {
            _gridTeamsHistory.Rows.Add(a.ProjectTeam.Name, a.AssignedDate.ToShortDateString(),
                a.EffectiveDate.ToShortDateString(), a.RemovedDate!.Value.ToShortDateString());
            _gridTeamsHistory.Rows[^1].Tag = a.AssignmentId;
        }

        // Employment history
        _gridEmployment.Rows.Clear();
        foreach (var ep in person.EmploymentPeriods.OrderByDescending(p => p.HireDate))
        {
            var sepDate  = ep.SeparationDate?.ToShortDateString() ?? "Active";
            var reason   = ep.SeparationReason.HasValue ? FormatReason(ep.SeparationReason) : "";
            var notes    = ep.SeparationNotes ?? "";
            var rowIdx   = _gridEmployment.Rows.Add(ep.HireDate.ToShortDateString(), sepDate, reason, notes);
            _gridEmployment.Rows[rowIdx].Tag = ep.PeriodId;
            if (!ep.SeparationDate.HasValue)
                _gridEmployment.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(235, 252, 240);
        }
    }

    // ── Actions ──────────────────────────────────────────────────

    private async Task EditBasicInfoAsync()
    {
        using var form = new AddEditPersonForm(_personId);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private async Task AddJobTitleAsync()
    {
        using var form = new AddJobTitleForm(_personId);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private async Task AddTeamAssignmentAsync()
    {
        using var form = new AddTeamAssignmentForm(_personId);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private async Task RemoveTeamAssignmentAsync()
    {
        if (_gridTeamsCurrent.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select a current assignment to remove.", "No Selection");
            return;
        }
        if (MessageBox.Show("Mark this assignment as removed today?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        await using var ctx = DbFactory.Create();
        var a = await ctx.PersonProjectAssignments.FindAsync(id);
        if (a == null) return;
        a.RemovedDate = DateTime.Today;
        await ctx.SaveChangesAsync();
        await LoadAsync();
    }

    private async Task SeparateAsync()
    {
        await using var ctx = DbFactory.Create();
        var person = await ctx.People.FindAsync(_personId);
        if (person == null) return;

        using var form = new SeparatePersonForm(_personId, person.FullName);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private async Task ReHireAsync()
    {
        await using var ctx = DbFactory.Create();
        var person = await ctx.People.FindAsync(_personId);
        if (person == null) return;

        using var form = new ReHirePersonForm(_personId, person.FullName);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    // ── Helpers ──────────────────────────────────────────────────

    private static string FormatReason(SeparationReason? reason) => reason switch
    {
        SeparationReason.EndOfInternship    => "End of Internship",
        SeparationReason.VoluntaryResignation => "Voluntary Resignation",
        SeparationReason.Termination        => "Termination",
        SeparationReason.Other              => "Other",
        _                                   => ""
    };

    private static Button MakeHeaderButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text, Height = 30, AutoSize = true,
            FlatStyle = FlatStyle.Flat, BackColor = back, ForeColor = Color.White,
            Cursor = Cursors.Hand, Margin = new Padding(6, 0, 0, 0), Padding = new Padding(10, 0, 10, 0)
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private static Button MakeSmallButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text, Height = 26, AutoSize = true,
            FlatStyle = FlatStyle.Flat, BackColor = back, ForeColor = Color.White,
            Cursor = Cursors.Hand, Margin = new Padding(0, 0, 6, 0), Padding = new Padding(6, 0, 6, 0)
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private static DataGridView BuildSmallGrid(params (string header, int width)[] columns)
    {
        var dgv = new DataGridView { Dock = DockStyle.Fill };
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 28;
        dgv.RowTemplate.Height = 26;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
        dgv.GridColor = Color.FromArgb(220, 230, 240);
        dgv.BorderStyle = BorderStyle.None;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.BackgroundColor = Color.White;
        foreach (var (h, w) in columns)
            dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = h, Width = w });
        return dgv;
    }
}
