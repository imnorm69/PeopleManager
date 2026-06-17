using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Forms;

namespace PeopleManager.Controls;

/// <summary>
/// Checklist Questions screen for managing reusable questions and assigning them to people.
/// Supports create, edit, delete, and assign-to-people actions.
/// </summary>
public class TemplatesControl : UserControl
{
    private DataGridView _grid = null!;

    /// <summary>Initialises the control, builds the UI, and starts an async data load.</summary>
    public TemplatesControl()
    {
        BuildUI();
        _ = LoadAsync();
    }

    private void BuildUI()
    {
        BackColor = Color.FromArgb(240, 242, 245);

        var header = new Panel
        {
            Dock = DockStyle.Top,
            Height = 90,
            BackColor = Color.White,
            Padding = new Padding(16, 0, 16, 0)
        };

        var lblTitle = new Label
        {
            Text = "Checklist Questions",
            Font = new Font("Segoe UI", 21f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 390,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var toolBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 630,
            FlowDirection = FlowDirection.LeftToRight
        };

        var btnNew    = MakeButton("+ New Question",    Color.FromArgb(39, 174, 96));
        var btnEdit   = MakeButton("Edit",              Color.FromArgb(41, 128, 185));
        var btnDelete = MakeButton("Delete",            Color.FromArgb(192, 57, 43));
        var btnAssign = MakeButton("Assign to People",  Color.FromArgb(142, 68, 173));

        btnNew.Click    += async (_, _) => await NewQuestionAsync();
        btnEdit.Click   += async (_, _) => await EditQuestionAsync();
        btnDelete.Click += async (_, _) => await DeleteQuestionAsync();
        btnAssign.Click += async (_, _) => await AssignQuestionAsync();

        toolBar.Controls.AddRange(new Control[] { btnNew, btnEdit, btnDelete, btnAssign });
        header.Controls.Add(toolBar);
        header.Controls.Add(lblTitle);

        _grid = BuildGrid();
        _grid.CellDoubleClick += async (_, _) => await EditQuestionAsync();

        var wrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
        wrapper.Controls.Add(_grid);

        Controls.Add(wrapper);
        Controls.Add(header);
    }

    /// <summary>Loads all checklist questions and their assignment counts into the grid.</summary>
    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();
        var questions = await ctx.ChecklistQuestions
            .Include(q => q.Assignments)
            .OrderBy(q => q.SortOrder)
            .ThenBy(q => q.Description)
            .ToListAsync();

        _grid.Rows.Clear();
        foreach (var q in questions)
        {
            _grid.Rows.Add(q.Description, q.ValueType.ToString(), q.Assignments.Count);
            _grid.Rows[^1].Tag = q.QuestionId;
        }
    }

    /// <summary>Opens the question form to create a new checklist question.</summary>
    private async Task NewQuestionAsync()
    {
        using var form = new ChecklistQuestionForm(null);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    /// <summary>Opens the question form to edit the selected checklist question.</summary>
    private async Task EditQuestionAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select a question first.", "No Selection");
            return;
        }
        using var form = new ChecklistQuestionForm(id);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    /// <summary>Prompts for confirmation and deletes the selected question and all its assignments.</summary>
    private async Task DeleteQuestionAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select a question first.", "No Selection");
            return;
        }
        if (MessageBox.Show(
                "Delete this question? All person assignments will also be removed.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            != DialogResult.Yes) return;

        await using var ctx = DbFactory.Create();
        var q = await ctx.ChecklistQuestions.FindAsync(id);
        if (q == null) return;
        ctx.ChecklistQuestions.Remove(q);
        await ctx.SaveChangesAsync();
        await LoadAsync();
    }

    /// <summary>Opens the assignment dialog to assign or unassign the selected question to people.</summary>
    private async Task AssignQuestionAsync()
    {
        if (_grid.CurrentRow?.Tag is not int id)
        {
            MessageBox.Show("Select a question first.", "No Selection");
            return;
        }
        using var form = new AssignQuestionForm(id);
        if (form.ShowDialog() == DialogResult.OK)
            await LoadAsync();
    }

    private static Button MakeButton(string text, Color back)
    {
        var btn = new Button
        {
            Text = text,
            Height = 42,
            AutoSize = true,
            FlatStyle = FlatStyle.Flat,
            BackColor = back,
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            Margin = new Padding(6, 24, 0, 0),
            Padding = new Padding(12, 0, 12, 0)
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private static DataGridView BuildGrid()
    {
        var dgv = new DataGridView { Dock = DockStyle.Fill };
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 51;
        dgv.RowTemplate.Height = 45;
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 14f);
        dgv.GridColor = Color.FromArgb(220, 230, 240);
        dgv.BorderStyle = BorderStyle.None;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.BackgroundColor = Color.White;

        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", Width = 600, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Value Type",  Width = 165 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Assigned To", Width = 135 });
        return dgv;
    }
}
