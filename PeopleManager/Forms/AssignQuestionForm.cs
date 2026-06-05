using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Models;

namespace PeopleManager.Forms;

public class AssignQuestionForm : Form
{
    private readonly int _questionId;
    private DataGridView _grid = null!;

    // Row data: PersonId, PersonName, currently assigned?, current Frequency
    private record PersonRow(int PersonId, string Name, bool WasAssigned, int ExistingAssignmentId);
    private List<PersonRow> _rows = new();

    public AssignQuestionForm(int questionId)
    {
        _questionId = questionId;
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        Text = "Assign Question to People";
        Size = new Size(560, 440);
        MinimumSize = new Size(460, 340);
        FormBorderStyle = FormBorderStyle.Sizable;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 9f);
        BackColor = Color.White;

        var infoLabel = new Label
        {
            Text = "Check each person to assign this question. Set the review frequency per person.",
            Dock = DockStyle.Top,
            Height = 28,
            Padding = new Padding(8, 6, 0, 0),
            ForeColor = Color.FromArgb(80, 80, 80),
            Font = new Font("Segoe UI", 8.5f, FontStyle.Italic)
        };

        // Grid with checkbox + name + frequency columns
        _grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            RowHeadersVisible = false,
            MultiSelect = false,
            BorderStyle = BorderStyle.None,
            BackgroundColor = Color.White,
            GridColor = Color.FromArgb(220, 230, 240)
        };
        _grid.EnableHeadersVisualStyles = false;
        _grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        _grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        _grid.ColumnHeadersHeight = 30;
        _grid.RowTemplate.Height  = 28;
        _grid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;

        var colAssigned = new DataGridViewCheckBoxColumn
        {
            HeaderText = "Assign",
            Width = 60,
            Name = "Assigned",
            TrueValue = true,
            FalseValue = false
        };
        var colName = new DataGridViewTextBoxColumn
        {
            HeaderText = "Person",
            Width = 200,
            Name = "PersonName",
            ReadOnly = true,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        var colFreq = new DataGridViewComboBoxColumn
        {
            HeaderText = "Frequency",
            Width = 140,
            Name = "Frequency",
            DataSource = Enum.GetValues<CheckFrequency>().Select(f => f.ToString()).ToArray(),
            DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        };
        _grid.Columns.AddRange(colAssigned, colName, colFreq);

        // When a checkbox changes, enable/disable the frequency cell
        _grid.CellValueChanged += OnCellValueChanged;
        _grid.CurrentCellDirtyStateChanged += (_, _) =>
        {
            if (_grid.IsCurrentCellDirty) _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        };

        var btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 46, BackColor = Color.White, Padding = new Padding(8, 8, 8, 8) };
        var btnSave   = new Button { Text = "Save",   Width = 90, Height = 30, Dock = DockStyle.Right, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(41, 128, 185), ForeColor = Color.White, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Cancel", Width = 80, Height = 30, Dock = DockStyle.Right, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(127, 140, 141), ForeColor = Color.White, DialogResult = DialogResult.Cancel };
        btnSave.FlatAppearance.BorderSize = 0; btnCancel.FlatAppearance.BorderSize = 0;
        btnSave.Click += async (_, _) => await SaveAsync();
        btnPanel.Controls.Add(btnSave);
        btnPanel.Controls.Add(btnCancel);

        Controls.Add(_grid);
        Controls.Add(infoLabel);
        Controls.Add(btnPanel);
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
                existing.Frequency = freq;   // update frequency if changed
            }
            else if (!assign && existing != null)
            {
                ctx.PersonQuestionAssignments.Remove(existing);
            }
        }

        await ctx.SaveChangesAsync();
    }
}
