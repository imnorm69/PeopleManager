using PeopleManager.Models;

namespace PeopleManager.Forms;

public class GlowGrowDetailForm : Form
{
    public GlowGrowDetailForm(GlowGrow item)
    {
        BuildUI(item);
    }

    private void BuildUI(GlowGrow item)
    {
        Text = item.Type == GlowGrowType.Glow ? "Glow Detail" : "Grow Detail";
        Size = new Size(760, 570);
        MinimumSize = new Size(620, 450);
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Font = new Font("Segoe UI", 14f);
        BackColor = Color.White;

        var typeColor = item.Type == GlowGrowType.Glow
            ? Color.FromArgb(39, 174, 96)
            : Color.FromArgb(192, 57, 43);

        var banner = new Panel
        {
            Dock = DockStyle.Top,
            Height = 54,
            BackColor = typeColor
        };
        var lblType = new Label
        {
            Text = item.Type == GlowGrowType.Glow ? "GLOW" : "GROW",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        banner.Controls.Add(lblType);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(16),
            ColumnCount = 2,
            RowCount = 6
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42)); // Person
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42)); // Recorded
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42)); // Source
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42)); // Communicated
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Note
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // Close button

        AddReadOnlyRow(layout, "Person:",       item.Person?.FullName ?? "", 0);
        AddReadOnlyRow(layout, "Recorded:",     item.CreatedDate.ToLongDateString(), 1);
        AddReadOnlyRow(layout, "Source:",        item.Source ?? "—", 2);
        AddReadOnlyRow(layout, "Communicated:", item.CommunicatedDate.HasValue
            ? item.CommunicatedDate.Value.ToLongDateString() : "Not yet communicated", 3);

        layout.Controls.Add(new Label
        {
            Text = "Note:",
            TextAlign = ContentAlignment.TopRight,
            Dock = DockStyle.Fill,
            Padding = new Padding(0, 4, 4, 0)
        }, 0, 4);

        var rtb = new RichTextBox
        {
            Text = item.Note,
            Dock = DockStyle.Fill,
            ReadOnly = true,
            BackColor = Color.FromArgb(250, 250, 250),
            BorderStyle = BorderStyle.FixedSingle,
            ScrollBars = RichTextBoxScrollBars.Vertical,
            Font = new Font("Segoe UI", 14f)
        };
        layout.Controls.Add(rtb, 1, 4);

        var btnClose = new Button
        {
            Text = "Close",
            DialogResult = DialogResult.OK,
            Width = 120,
            Dock = DockStyle.Right
        };
        var btnRow = new Panel { Dock = DockStyle.Fill };
        btnRow.Controls.Add(btnClose);
        layout.SetColumnSpan(btnRow, 2);
        layout.Controls.Add(btnRow, 0, 5);

        AcceptButton = btnClose;
        Controls.Add(layout);
        Controls.Add(banner);
    }

    private static void AddReadOnlyRow(TableLayoutPanel layout, string label, string value, int row)
    {
        layout.Controls.Add(new Label
        {
            Text = label,
            TextAlign = ContentAlignment.MiddleRight,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 14f, FontStyle.Bold)
        }, 0, row);

        layout.Controls.Add(new Label
        {
            Text = value,
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            AutoEllipsis = true
        }, 1, row);
    }
}
