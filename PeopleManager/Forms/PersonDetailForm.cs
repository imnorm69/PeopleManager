using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Detail form for a single person showing job title history, team assignments,
/// and employment history. Also provides Separate and Re-hire actions.
/// </summary>
public partial class PersonDetailForm : Form
{
    private readonly int _personId;

    /// <summary>Initialises the form for the specified person.</summary>
    /// <param name="personId">Primary key of the person to display.</param>
    public PersonDetailForm() : this(0) { }

    public PersonDetailForm(int personId)
    {
        _personId = personId;
        InitializeComponent();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadAsync();
    }

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
            var sepDate = lastPeriod?.SeparationDate?.ToString("MM/dd/yyyy") ?? "—";
            _lblStatus.Text      = $"Separated  |  {sepDate}  |  {FormatReason(lastPeriod?.SeparationReason)}";
            _lblStatus.ForeColor = Color.FromArgb(255, 180, 160);
            _btnSeparate.Visible = false;
            _btnReHire.Visible   = true;
        }

        _gridTitles.Rows.Clear();
        var titles = person.JobTitles.OrderByDescending(j => j.EffectiveDate).ToList();
        for (int i = 0; i < titles.Count; i++)
        {
            var jt = titles[i];
            _gridTitles.Rows.Add(jt.Title, jt.EffectiveDate.ToShortDateString(), i == 0 ? "✓" : "");
            _gridTitles.Rows[^1].Tag = jt.PersonJobTitleId;
        }

        _gridTeamsCurrent.Rows.Clear();
        foreach (var a in person.ProjectAssignments.Where(a => a.RemovedDate == null).OrderBy(a => a.EffectiveDate))
        {
            _gridTeamsCurrent.Rows.Add(a.ProjectTeam.Name, a.AssignedDate.ToShortDateString(), a.EffectiveDate.ToShortDateString());
            _gridTeamsCurrent.Rows[^1].Tag = a.AssignmentId;
        }

        _gridTeamsHistory.Rows.Clear();
        foreach (var a in person.ProjectAssignments.Where(a => a.RemovedDate != null).OrderByDescending(a => a.RemovedDate))
        {
            _gridTeamsHistory.Rows.Add(a.ProjectTeam.Name, a.AssignedDate.ToShortDateString(),
                a.EffectiveDate.ToShortDateString(), a.RemovedDate!.Value.ToShortDateString());
            _gridTeamsHistory.Rows[^1].Tag = a.AssignmentId;
        }

        _gridEmployment.Rows.Clear();
        foreach (var ep in person.EmploymentPeriods.OrderByDescending(p => p.HireDate))
        {
            var sepDate = ep.SeparationDate?.ToShortDateString() ?? "Active";
            var reason  = ep.SeparationReason.HasValue ? FormatReason(ep.SeparationReason) : "";
            var notes   = ep.SeparationNotes ?? "";
            var rowIdx  = _gridEmployment.Rows.Add(ep.HireDate.ToShortDateString(), sepDate, reason, notes);
            _gridEmployment.Rows[rowIdx].Tag = ep.PeriodId;
            if (!ep.SeparationDate.HasValue)
                _gridEmployment.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(235, 252, 240);
        }
    }

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

    /// <summary>Marks the selected current team assignment as removed as of today.</summary>
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

    /// <summary>Converts a <see cref="SeparationReason"/> enum value to a human-readable string.</summary>
    private static string FormatReason(SeparationReason? reason) => reason switch
    {
        SeparationReason.EndOfInternship      => "End of Internship",
        SeparationReason.VoluntaryResignation => "Voluntary Resignation",
        SeparationReason.Termination          => "Termination",
        SeparationReason.Other                => "Other",
        _                                     => ""
    };

    private async void BtnSeparate_Click(object? sender, EventArgs e) { await SeparateAsync(); }
    private async void BtnReHire_Click(object? sender, EventArgs e) { await ReHireAsync(); }
    private async void BtnEdit_Click(object? sender, EventArgs e) { await EditBasicInfoAsync(); }
    private async void BtnAddTitle_Click(object? sender, EventArgs e) { await AddJobTitleAsync(); }
    private async void BtnAddTeam_Click(object? sender, EventArgs e) { await AddTeamAssignmentAsync(); }
    private async void BtnRemoveTeam_Click(object? sender, EventArgs e) { await RemoveTeamAssignmentAsync(); }
}
