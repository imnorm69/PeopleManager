using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for assigning a person to an existing or newly created project team,
/// capturing assigned and effective dates.
/// </summary>
public class AddTeamAssignmentForm : Form
{
    private readonly int _personId;
    private ComboBox _cboTeam = null!;
    private TextBox _txtNewTeam = null!;
    private DateTimePicker _dtpAssigned = null!;
    private DateTimePicker _dtpEffective = null!;
    private RadioButton _rbExisting = null!;
    private RadioButton _rbNew = null!;

    /// <summary>Initialises the form for the specified person.</summary>
    /// <param name="personId">The person being assigned to a team.</param>
    public AddTeamAssignmentForm(int personId)
    {
        _personId = personId;
        BuildUI();
        _ = LoadTeamsAsync();
    }

    private void BuildUI()
    {
        Text = "Assign to Team / Project";
        Size = new Size(620, 420);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.White;

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(16), ColumnCount = 2, RowCount = 6 };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        _rbExisting = new RadioButton { Text = "Existing team:", Dock = DockStyle.Fill, Checked = true };
        _rbNew      = new RadioButton { Text = "New team:",      Dock = DockStyle.Fill };

        _cboTeam    = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        _txtNewTeam = new TextBox  { Dock = DockStyle.Fill, Enabled = false };

        _rbExisting.CheckedChanged += (_, _) => { _cboTeam.Enabled = _rbExisting.Checked; _txtNewTeam.Enabled = _rbNew.Checked; };
        _rbNew.CheckedChanged      += (_, _) => { _cboTeam.Enabled = _rbExisting.Checked; _txtNewTeam.Enabled = _rbNew.Checked; };

        _dtpAssigned  = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
        _dtpEffective = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

        layout.Controls.Add(_rbExisting, 0, 0); layout.Controls.Add(_cboTeam,    1, 0);
        layout.Controls.Add(_rbNew,      0, 1); layout.Controls.Add(_txtNewTeam, 1, 1);
        layout.Controls.Add(new Label { Text = "Assigned Date *",  TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 2);
        layout.Controls.Add(_dtpAssigned,  1, 2);
        layout.Controls.Add(new Label { Text = "Effective Date *", TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill }, 0, 3);
        layout.Controls.Add(_dtpEffective, 1, 3);

        var btnPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, Padding = new Padding(0, 6, 0, 0) };
        layout.SetColumnSpan(btnPanel, 2);
        var btnSave   = new Button { Text = "Save",   DialogResult = DialogResult.OK,     Width = 120 };
        var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 120 };
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, 4);

        AcceptButton = btnSave; CancelButton = btnCancel;
        Controls.Add(layout);
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
}
