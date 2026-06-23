using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;

namespace PeopleManager.Forms;

/// <summary>
/// Small dialog for picking a person and date before opening a new 1:1 meeting.
/// Exposes the selected values via <see cref="SelectedPersonId"/> and <see cref="MeetingDate"/>.
/// </summary>
public partial class NewMeetingDialog : Form
{
    public int      SelectedPersonId   { get; private set; }
    public string   SelectedPersonName { get; private set; } = "";
    public DateTime MeetingDate        { get; private set; } = DateTime.Today;

    public NewMeetingDialog()
    {
        InitializeComponent();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadPeopleAsync();
    }

    private async Task LoadPeopleAsync()
    {
        await using var ctx = DbFactory.Create();
        var people = await ctx.People
            .Where(p => p.IsActive)
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .ToListAsync();
        foreach (var p in people)
            _cboPerson.Items.Add(new PersonItem(p.PersonId, p.DisplayName));
    }

    /// <summary>Validates that a person is selected before accepting the dialog.</summary>
    private void ValidateAndAccept()
    {
        if (_cboPerson.SelectedItem is not PersonItem pi)
        {
            MessageBox.Show("Please select a person before continuing.",
                "Person Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }
        SelectedPersonId   = pi.Id;
        SelectedPersonName = pi.Name;
        MeetingDate        = _dtp.Value.Date;
    }

    private record PersonItem(int Id, string Name) { public override string ToString() => Name; }

    private void BtnOK_Click(object? sender, EventArgs e) => ValidateAndAccept();
}
