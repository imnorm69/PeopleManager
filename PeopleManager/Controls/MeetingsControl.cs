using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;
using PeopleManager.Forms;

namespace PeopleManager.Controls;

public class MeetingsControl : UserControl
{
    private DataGridView _grid = null!;
    private ComboBox _cboPerson = null!;

    public MeetingsControl()
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
            Text = "1:1 Meetings",
            Font = new Font("Segoe UI", 21f, FontStyle.Bold),
            ForeColor = Color.FromArgb(30, 58, 95),
            Dock = DockStyle.Left,
            AutoSize = false,
            Width = 270,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var toolBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 750,
            FlowDirection = FlowDirection.LeftToRight
        };

        _cboPerson = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Width = 300,
            Margin = new Padding(0, 24, 12, 0)
        };
        _cboPerson.SelectedIndexChanged += async (_, _) => await LoadAsync();

        var btnNew  = MakeButton("+ New Meeting", Color.FromArgb(39, 174, 96));
        var btnOpen = MakeButton("Open",          Color.FromArgb(41, 128, 185));

        btnNew.Click  += async (_, _) =>
        {
            using var dlg = new NewMeetingDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            using var form = new MeetingForm(dlg.SelectedPersonId, dlg.MeetingDate);
            form.ShowDialog();
            await LoadAsync();
        };
        btnOpen.Click += async (_, _) => await OpenSelectedMeetingAsync();

        toolBar.Controls.AddRange(new Control[] { _cboPerson, btnNew, btnOpen });
        header.Controls.Add(toolBar);
        header.Controls.Add(lblTitle);

        _grid = BuildGrid();
        _grid.CellDoubleClick += async (_, _) => await OpenSelectedMeetingAsync();

        var wrapper = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
        wrapper.Controls.Add(_grid);

        Controls.Add(wrapper);
        Controls.Add(header);
    }

    private async Task LoadAsync()
    {
        await using var ctx = DbFactory.Create();

        if (_cboPerson.Items.Count == 0)
        {
            var people = await ctx.People
                .Where(p => p.IsActive)
                .OrderBy(p => p.LastName).ThenBy(p => p.FirstName)
                .ToListAsync();
            _cboPerson.Items.Add("All People");
            foreach (var p in people)
                _cboPerson.Items.Add(new PersonItem(p.PersonId, p.DisplayName));
            _cboPerson.SelectedIndex = 0;
        }

        var query = ctx.Meetings
            .Include(m => m.Person)
            .Include(m => m.Notes)
            .Include(m => m.CreatedActionItems)
            .AsQueryable();

        if (_cboPerson.SelectedItem is PersonItem pi)
            query = query.Where(m => m.PersonId == pi.Id);

        var meetings = await query.OrderByDescending(m => m.MeetingDate).ToListAsync();

        _grid.Rows.Clear();
        foreach (var m in meetings)
        {
            _grid.Rows.Add(
                m.MeetingDate.ToShortDateString(),
                m.Person.DisplayName,
                m.Notes.Count,
                m.CreatedActionItems.Count(a => !a.IsComplete)
            );
            _grid.Rows[^1].Tag = m.MeetingId;
        }
    }

    private async Task OpenSelectedMeetingAsync()
    {
        if (_grid.CurrentRow?.Tag is not int meetingId) return;
        await using var ctx = DbFactory.Create();
        var meeting = await ctx.Meetings.FindAsync(meetingId);
        if (meeting == null) return;
        using var form = new MeetingForm(meeting.PersonId, meeting.MeetingDate, meetingId);
        form.ShowDialog();
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
            Cursor = Cursors.Default,
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
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
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

        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date",         Width = 150 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Person",        Width = 270, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Note Sections", Width = 165 });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Open Items",    Width = 150 });
        return dgv;
    }

    private record PersonItem(int Id, string Name)
    {
        public override string ToString() => Name;
    }
}
