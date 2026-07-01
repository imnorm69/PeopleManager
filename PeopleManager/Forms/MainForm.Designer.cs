using PeopleManager.Controls;

namespace PeopleManager.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();

        // ── Sidebar ──────────────────────────────────────────────────────────────
        this._sidebar = new Panel();
        this._sidebar.Width     = 280;
        this._sidebar.Dock      = DockStyle.Left;
        this._sidebar.BackColor = Color.FromArgb(30, 58, 95);

        _titleLabel = new Label();
        _titleLabel.Text      = "People Manager";
        _titleLabel.ForeColor = Color.White;
        _titleLabel.Font      = new Font("Segoe UI", 18f, FontStyle.Bold);
        _titleLabel.Dock      = DockStyle.Top;
        _titleLabel.Height    = 86;
        _titleLabel.TextAlign = ContentAlignment.MiddleCenter;
        _titleLabel.Padding   = new Padding(8);

        _navPanel = new FlowLayoutPanel();
        _navPanel.Dock          = DockStyle.Fill;
        _navPanel.FlowDirection = FlowDirection.TopDown;
        _navPanel.WrapContents  = false;
        _navPanel.AutoScroll    = false;
        _navPanel.Padding       = new Padding(0, 8, 0, 0);

        this._btnDashboard = new Button();
        this._btnDashboard.Text      = "  Dashboard";
        this._btnDashboard.Width     = 280;
        this._btnDashboard.Height    = 68;
        this._btnDashboard.FlatStyle = FlatStyle.Flat;
        this._btnDashboard.ForeColor = Color.White;
        this._btnDashboard.Font      = new Font("Segoe UI", 15f);
        this._btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
        this._btnDashboard.Padding   = new Padding(16, 0, 0, 0);
        this._btnDashboard.Cursor    = Cursors.Hand;
        this._btnDashboard.BackColor = Color.Transparent;
        this._btnDashboard.FlatAppearance.BorderSize         = 0;
        this._btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 110);
        this._btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);

        this._btnPeople = new Button();
        this._btnPeople.Text      = "  People";
        this._btnPeople.Width     = 280;
        this._btnPeople.Height    = 68;
        this._btnPeople.FlatStyle = FlatStyle.Flat;
        this._btnPeople.ForeColor = Color.White;
        this._btnPeople.Font      = new Font("Segoe UI", 15f);
        this._btnPeople.TextAlign = ContentAlignment.MiddleLeft;
        this._btnPeople.Padding   = new Padding(16, 0, 0, 0);
        this._btnPeople.Cursor    = Cursors.Hand;
        this._btnPeople.BackColor = Color.Transparent;
        this._btnPeople.FlatAppearance.BorderSize         = 0;
        this._btnPeople.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 110);
        this._btnPeople.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);

        this._btnMeetings = new Button();
        this._btnMeetings.Text      = "  1:1 Meetings";
        this._btnMeetings.Width     = 280;
        this._btnMeetings.Height    = 68;
        this._btnMeetings.FlatStyle = FlatStyle.Flat;
        this._btnMeetings.ForeColor = Color.White;
        this._btnMeetings.Font      = new Font("Segoe UI", 15f);
        this._btnMeetings.TextAlign = ContentAlignment.MiddleLeft;
        this._btnMeetings.Padding   = new Padding(16, 0, 0, 0);
        this._btnMeetings.Cursor    = Cursors.Hand;
        this._btnMeetings.BackColor = Color.Transparent;
        this._btnMeetings.FlatAppearance.BorderSize         = 0;
        this._btnMeetings.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 110);
        this._btnMeetings.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);

        this._btnGlowsGrows = new Button();
        this._btnGlowsGrows.Text      = "  Glows & Grows";
        this._btnGlowsGrows.Width     = 280;
        this._btnGlowsGrows.Height    = 68;
        this._btnGlowsGrows.FlatStyle = FlatStyle.Flat;
        this._btnGlowsGrows.ForeColor = Color.White;
        this._btnGlowsGrows.Font      = new Font("Segoe UI", 15f);
        this._btnGlowsGrows.TextAlign = ContentAlignment.MiddleLeft;
        this._btnGlowsGrows.Padding   = new Padding(16, 0, 0, 0);
        this._btnGlowsGrows.Cursor    = Cursors.Hand;
        this._btnGlowsGrows.BackColor = Color.Transparent;
        this._btnGlowsGrows.FlatAppearance.BorderSize         = 0;
        this._btnGlowsGrows.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 110);
        this._btnGlowsGrows.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);

        this._btnTemplates = new Button();
        this._btnTemplates.Text      = "  Questions";
        this._btnTemplates.Width     = 280;
        this._btnTemplates.Height    = 68;
        this._btnTemplates.FlatStyle = FlatStyle.Flat;
        this._btnTemplates.ForeColor = Color.White;
        this._btnTemplates.Font      = new Font("Segoe UI", 15f);
        this._btnTemplates.TextAlign = ContentAlignment.MiddleLeft;
        this._btnTemplates.Padding   = new Padding(16, 0, 0, 0);
        this._btnTemplates.Cursor    = Cursors.Hand;
        this._btnTemplates.BackColor = Color.Transparent;
        this._btnTemplates.FlatAppearance.BorderSize         = 0;
        this._btnTemplates.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 73, 110);
        this._btnTemplates.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);

        _navPanel.Controls.AddRange(new Control[]
        {
            this._btnDashboard, this._btnPeople, this._btnMeetings,
            this._btnGlowsGrows, this._btnTemplates
        });

        this._btnDashboard.Click  += BtnDashboard_Click;
        this._btnPeople.Click     += BtnPeople_Click;
        this._btnMeetings.Click   += BtnMeetings_Click;
        this._btnGlowsGrows.Click += BtnGlowsGrows_Click;
        this._btnTemplates.Click  += BtnTemplates_Click;

        this._sidebar.Controls.Add(_navPanel);
        this._sidebar.Controls.Add(_titleLabel);

        // ── Content area ─────────────────────────────────────────────────────────
        this._contentPanel = new Panel
        {
            Dock    = DockStyle.Fill,
            Padding = new Padding(0)
        };

        this.Controls.Add(this._contentPanel);
        this.Controls.Add(this._sidebar);

        // ── Form properties ───────────────────────────────────────────────────────
        this.Text           = "People Manager";
        this.Size           = new Size(1900, 1170);
        this.MinimumSize    = new Size(1400, 900);
        this.StartPosition  = FormStartPosition.CenterScreen;
        this.BackColor      = Color.FromArgb(240, 242, 245);
        this.Font           = new Font("Segoe UI", 14f);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Panel            _sidebar        = null!;
    private Panel            _contentPanel   = null!;
    private Label            _titleLabel     = null!;
    private FlowLayoutPanel  _navPanel       = null!;
    private Button           _btnDashboard   = null!;
    private Button           _btnPeople      = null!;
    private Button           _btnMeetings    = null!;
    private Button           _btnGlowsGrows  = null!;
    private Button           _btnTemplates   = null!;
}
