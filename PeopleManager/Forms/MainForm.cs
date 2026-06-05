using PeopleManager.Controls;

namespace PeopleManager.Forms;

public class MainForm : Form
{
    private Panel _sidebar = null!;
    private Panel _contentPanel = null!;
    private UserControl? _activeControl;

    private Button _btnDashboard = null!;
    private Button _btnPeople = null!;
    private Button _btnMeetings = null!;
    private Button _btnGlowsGrows = null!;
    private Button _btnTemplates = null!;

    private static readonly Color SidebarColor = Color.FromArgb(30, 58, 95);
    private static readonly Color NavNormal = Color.Transparent;
    private static readonly Color NavSelected = Color.FromArgb(41, 128, 185);
    private static readonly Color NavHover = Color.FromArgb(52, 73, 110);

    public MainForm()
    {
        InitializeLayout();
        Navigate(_btnDashboard, new DashboardControl());
    }

    private void InitializeLayout()
    {
        Text = "People Manager";
        Size = new Size(1280, 780);
        MinimumSize = new Size(960, 620);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(240, 242, 245);
        Font = new Font("Segoe UI", 9f);

        // ── Sidebar ──────────────────────────────────────────────
        _sidebar = new Panel
        {
            Width = 200,
            Dock = DockStyle.Left,
            BackColor = SidebarColor
        };

        var titleLabel = new Label
        {
            Text = "People Manager",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 12f, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 60,
            TextAlign = ContentAlignment.MiddleCenter,
            Padding = new Padding(8)
        };

        var navPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = false,
            Padding = new Padding(0, 8, 0, 0)
        };

        _btnDashboard   = MakeNavButton("  Dashboard",   "📊");
        _btnPeople      = MakeNavButton("  People",      "👥");
        _btnMeetings    = MakeNavButton("  1:1 Meetings","📝");
        _btnGlowsGrows  = MakeNavButton("  Glows & Grows","⭐");
        _btnTemplates   = MakeNavButton("  Questions",    "☑");

        navPanel.Controls.AddRange(new Control[]
        {
            _btnDashboard, _btnPeople, _btnMeetings, _btnGlowsGrows, _btnTemplates
        });

        _btnDashboard.Click  += (_, _) => Navigate(_btnDashboard,  new DashboardControl());
        _btnPeople.Click     += (_, _) => Navigate(_btnPeople,     new PeopleControl());
        _btnMeetings.Click   += (_, _) => Navigate(_btnMeetings,   new MeetingsControl());
        _btnGlowsGrows.Click += (_, _) => Navigate(_btnGlowsGrows, new GlowsGrowsControl());
        _btnTemplates.Click  += (_, _) => Navigate(_btnTemplates,  new TemplatesControl());

        _sidebar.Controls.Add(navPanel);
        _sidebar.Controls.Add(titleLabel);

        // ── Content area ─────────────────────────────────────────
        _contentPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0)
        };

        Controls.Add(_contentPanel);
        Controls.Add(_sidebar);
    }

    private Button MakeNavButton(string text, string _)
    {
        var btn = new Button
        {
            Text = text,
            Width = 200,
            Height = 46,
            FlatStyle = FlatStyle.Flat,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10f),
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(16, 0, 0, 0),
            Cursor = Cursors.Hand,
            BackColor = NavNormal
        };
        btn.FlatAppearance.BorderSize = 0;
        btn.FlatAppearance.MouseOverBackColor = NavHover;
        btn.FlatAppearance.MouseDownBackColor = NavSelected;
        return btn;
    }

    private void Navigate(Button sender, UserControl control)
    {
        // Reset all nav buttons
        foreach (Control c in _sidebar.Controls.OfType<FlowLayoutPanel>().First().Controls)
        {
            if (c is Button b) b.BackColor = NavNormal;
        }
        sender.BackColor = NavSelected;

        // Swap content
        _activeControl?.Dispose();
        control.Dock = DockStyle.Fill;
        _contentPanel.Controls.Clear();
        _contentPanel.Controls.Add(control);
        _activeControl = control;
    }
}
