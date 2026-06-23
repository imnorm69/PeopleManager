using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for assigning a person to an existing or newly created project team,
/// capturing assigned and effective dates.
/// </summary>
public partial class AddTeamAssignmentForm : Form
{
    private readonly int _personId;

    /// <summary>Initialises the form for the specified person.</summary>
    /// <param name="personId">The person being assigned to a team.</param>
    public AddTeamAssignmentForm() : this(0) { }

    public AddTeamAssignmentForm(int personId)
    {
        _personId = personId;
        InitializeComponent();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadTeamsAsync();
    }

    private async Task LoadTeamsAsync()
    {
        await using var ctx = DbFactory.Create();
        var teams = await ctx.ProjectTeams.OrderBy(t => t.Name).ToListAsync();
        foreach (var t in teams)
            _cboTeam.Items.Add(new TeamItem(t.ProjectTeamId, t.Name));
        if (_cboTeam.Items.Count > 0) _cboTeam.SelectedIndex = 0;
    }

    private async Task SaveAsync()
    {
        await using var ctx = DbFactory.Create();

        int teamId;
        if (_rbNew.Checked)
        {
            if (string.IsNullOrWhiteSpace(_txtNewTeam.Text))
            {
                MessageBox.Show("Enter a team/project name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None; return;
            }
            var team = new ProjectTeam { Name = _txtNewTeam.Text.Trim() };
            ctx.ProjectTeams.Add(team);
            await ctx.SaveChangesAsync();
            teamId = team.ProjectTeamId;
        }
        else
        {
            if (_cboTeam.SelectedItem is not TeamItem ti)
            {
                MessageBox.Show("Select a team.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None; return;
            }
            teamId = ti.Id;
        }

        ctx.PersonProjectAssignments.Add(new PersonProjectAssignment
        {
            PersonId      = _personId,
            ProjectTeamId = teamId,
            AssignedDate  = _dtpAssigned.Value.Date,
            EffectiveDate = _dtpEffective.Value.Date
        });
        await ctx.SaveChangesAsync();
    }

    private record TeamItem(int Id, string Name) { public override string ToString() => Name; }

    private void RbExisting_CheckedChanged(object? sender, EventArgs e) { _cboTeam.Enabled = _rbExisting.Checked; _txtNewTeam.Enabled = _rbNew.Checked; }
    private void RbNew_CheckedChanged(object? sender, EventArgs e) { _cboTeam.Enabled = _rbExisting.Checked; _txtNewTeam.Enabled = _rbNew.Checked; }
    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
