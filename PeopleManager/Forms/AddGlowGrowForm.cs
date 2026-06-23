using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog for adding a new glow/grow feedback item or editing an existing one.
/// </summary>
public partial class AddGlowGrowForm : Form
{
    private readonly int? _glowGrowId;
    private readonly int? _preselectedPersonId;

    /// <summary>Initialises the form.</summary>
    /// <param name="glowGrowId">The existing item to edit, or null to create a new one.</param>
    /// <param name="preselectedPersonId">Pre-selects a person in the dropdown when creating a new item.</param>
    public AddGlowGrowForm() : this(null, null) { }

    public AddGlowGrowForm(int? glowGrowId, int? preselectedPersonId)
    {
        _glowGrowId = glowGrowId;
        _preselectedPersonId = preselectedPersonId;
        InitializeComponent();
        if (_glowGrowId.HasValue) Text = "Edit Glow/Grow";
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadAsync();
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var people = await ctx.People
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .ToListAsync();
        foreach (var p in people)
            _cboPerson.Items.Add(new PersonItem(p.PersonId, p.DisplayName));

        if (_glowGrowId.HasValue)
        {
            var item = await ctx.GlowsGrows.FindAsync(_glowGrowId.Value);
            if (item == null) return;
            _cboPerson.SelectedItem = _cboPerson.Items.OfType<PersonItem>().FirstOrDefault(p => p.Id == item.PersonId);
            _cboType.SelectedIndex  = (int)item.Type;
            _txtSource.Text         = item.Source ?? "";
            _txtNote.Text           = item.Note;
            if (item.CommunicatedDate.HasValue)
            {
                _chkCommunicated.Checked = true;
                _dtpCommunicated.Value   = item.CommunicatedDate.Value;
            }
        }
        else if (_preselectedPersonId.HasValue)
        {
            _cboPerson.SelectedItem = _cboPerson.Items.OfType<PersonItem>()
                .FirstOrDefault(p => p.Id == _preselectedPersonId.Value);
        }
        else if (_cboPerson.Items.Count > 0)
        {
            _cboPerson.SelectedIndex = 0;
        }
    }

    private async Task SaveAsync()
    {
        if (_cboPerson.SelectedItem is not PersonItem pi)
        {
            MessageBox.Show("Select a person.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None; return;
        }
        if (string.IsNullOrWhiteSpace(_txtNote.Text))
        {
            MessageBox.Show("Note is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None; return;
        }

        var source = string.IsNullOrWhiteSpace(_txtSource.Text) ? null : _txtSource.Text.Trim();

        await using var ctx = DbFactory.Create();
        if (_glowGrowId.HasValue)
        {
            var item = await ctx.GlowsGrows.FindAsync(_glowGrowId.Value);
            if (item == null) return;
            item.PersonId         = pi.Id;
            item.Type             = (GlowGrowType)_cboType.SelectedIndex;
            item.Source           = source;
            item.Note             = _txtNote.Text.Trim();
            item.CommunicatedDate = _chkCommunicated.Checked ? _dtpCommunicated.Value.Date : null;
        }
        else
        {
            ctx.GlowsGrows.Add(new GlowGrow
            {
                PersonId         = pi.Id,
                Type             = (GlowGrowType)_cboType.SelectedIndex,
                Source           = source,
                Note             = _txtNote.Text.Trim(),
                CreatedDate      = DateTime.Today,
                CommunicatedDate = _chkCommunicated.Checked ? _dtpCommunicated.Value.Date : null
            });
        }
        await ctx.SaveChangesAsync();
    }

    private record PersonItem(int Id, string Name) { public override string ToString() => Name; }

    private void ChkCommunicated_CheckedChanged(object? sender, EventArgs e) { _dtpCommunicated.Enabled = _chkCommunicated.Checked; }
    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
