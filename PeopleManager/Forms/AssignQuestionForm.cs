using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Dialog showing all active people in a grid, allowing the manager to check or uncheck
/// each person to assign/unassign the selected checklist question and set its frequency.
/// </summary>
public partial class AssignQuestionForm : Form
{
    private readonly int _questionId;

    private record PersonRow(int PersonId, string Name, bool WasAssigned, int ExistingAssignmentId);
    private List<PersonRow> _rows = new();

    /// <summary>Initialises the assignment dialog for the specified question.</summary>
    /// <param name="questionId">The checklist question being assigned.</param>
    public AssignQuestionForm() : this(0) { }

    public AssignQuestionForm(int questionId)
    {
        _questionId = questionId;
        InitializeComponent();
        if (_grid.Columns["Frequency"] is DataGridViewComboBoxColumn colFreq)
            colFreq.DataSource = Enum.GetValues<CheckFrequency>().Select(f => f.ToString()).ToArray();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            _ = LoadAsync();
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();

        var people = await ctx.People
            .Where(p => p.IsActive)
            .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
            .ToListAsync();

        var existing = await ctx.PersonQuestionAssignments
            .Where(a => a.QuestionId == _questionId)
            .ToListAsync();

        var existingMap = existing.ToDictionary(a => a.PersonId);

        _rows = people.Select(p =>
        {
            existingMap.TryGetValue(p.PersonId, out var ea);
            return new PersonRow(p.PersonId, p.DisplayName, ea != null, ea?.AssignmentId ?? 0);
        }).ToList();

        _grid.Rows.Clear();
        foreach (var r in _rows)
        {
            var freq = existingMap.TryGetValue(r.PersonId, out var ea)
                ? ea.Frequency.ToString()
                : CheckFrequency.Monthly.ToString();

            _grid.Rows.Add(r.WasAssigned, r.Name, freq);
            _grid.Rows[^1].Tag = r.PersonId;
            UpdateFrequencyCell(_grid.Rows[^1]);
        }
    }

    private void OnCellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != _grid.Columns["Assigned"]!.Index || e.RowIndex < 0) return;
        UpdateFrequencyCell(_grid.Rows[e.RowIndex]);
    }

    /// <summary>Greys out the frequency cell when the row's Assign checkbox is unchecked.</summary>
    private static void UpdateFrequencyCell(DataGridViewRow row)
    {
        bool assigned = row.Cells["Assigned"].Value is true;
        row.Cells["Frequency"].ReadOnly = !assigned;
        row.Cells["Frequency"].Style.ForeColor = assigned ? Color.Black : Color.LightGray;
    }

    private async Task SaveAsync()
    {
        await using var ctx = DbFactory.Create();

        foreach (DataGridViewRow row in _grid.Rows)
        {
            if (row.Tag is not int personId) continue;
            bool assign = row.Cells["Assigned"].Value is true;
            var freqStr = row.Cells["Frequency"].Value?.ToString() ?? CheckFrequency.Monthly.ToString();
            var freq = Enum.Parse<CheckFrequency>(freqStr);

            var existing = await ctx.PersonQuestionAssignments
                .FirstOrDefaultAsync(a => a.PersonId == personId && a.QuestionId == _questionId);

            if (assign && existing == null)
            {
                ctx.PersonQuestionAssignments.Add(new PersonQuestionAssignment
                {
                    PersonId     = personId,
                    QuestionId   = _questionId,
                    Frequency    = freq,
                    AssignedDate = DateTime.Today
                });
            }
            else if (assign && existing != null)
            {
                existing.Frequency = freq;
            }
            else if (!assign && existing != null)
            {
                ctx.PersonQuestionAssignments.Remove(existing);
            }
        }

        await ctx.SaveChangesAsync();
    }

    private void Grid_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        if (_grid.IsCurrentCellDirty) _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
    private async void BtnSave_Click(object? sender, EventArgs e) { await SaveAsync(); }
}
