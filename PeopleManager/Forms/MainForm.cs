using Microsoft.EntityFrameworkCore;
using PeopleManager.Controls;
using PeopleManager.Data;

namespace PeopleManager.Forms;

public partial class MainForm : Form
{
    private UserControl? _activeControl;

    private static readonly Color NavNormal   = Color.Transparent;
    private static readonly Color NavSelected = Color.FromArgb(41, 128, 185);

    public MainForm()
    {
        InitializeComponent();
        if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
        {
            Navigate(_btnDashboard, new DashboardControl());
            _ = RefreshNavStateAsync();
        }
    }

    private async Task RefreshNavStateAsync()
    {
        await using var ctx = DbFactory.Create();
        bool hasPeople = await ctx.People.AnyAsync();
        _btnMeetings.Enabled   = hasPeople;
        _btnGlowsGrows.Enabled = hasPeople;
    }

    private void Navigate(Button sender, UserControl control)
    {
        // Re-check nav state whenever leaving the People screen — that's where
        // people are added or removed.
        if (_activeControl is PeopleControl)
            _ = RefreshNavStateAsync();

        foreach (Control c in _sidebar.Controls.OfType<FlowLayoutPanel>().First().Controls)
        {
            if (c is Button b) b.BackColor = NavNormal;
        }
        sender.BackColor = NavSelected;

        _activeControl?.Dispose();
        control.Dock = DockStyle.Fill;
        _contentPanel.Controls.Clear();
        _contentPanel.Controls.Add(control);
        _activeControl = control;
    }

    private void BtnDashboard_Click(object? sender, EventArgs e)  => Navigate(_btnDashboard,  new DashboardControl());
    private void BtnPeople_Click(object? sender, EventArgs e)      => Navigate(_btnPeople,     new PeopleControl());
    private void BtnMeetings_Click(object? sender, EventArgs e)    => Navigate(_btnMeetings,   new MeetingsControl());
    private void BtnGlowsGrows_Click(object? sender, EventArgs e)  => Navigate(_btnGlowsGrows, new GlowsGrowsControl());
    private void BtnTemplates_Click(object? sender, EventArgs e)   => Navigate(_btnTemplates,  new TemplatesControl());
}
