namespace PeopleManager.Forms;

partial class ReHirePersonForm
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

        var layout = new System.Windows.Forms.TableLayoutPanel
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            Padding = new System.Windows.Forms.Padding(20),
            ColumnCount = 2,
            RowCount = 4
        };
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180));
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63));

        this._lblPersonName = new System.Windows.Forms.Label
        {
            Text = "",
            Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold),
            ForeColor = System.Drawing.Color.FromArgb(30, 58, 95),
            Dock = System.Windows.Forms.DockStyle.Fill,
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        };
        layout.SetColumnSpan(this._lblPersonName, 2);
        layout.Controls.Add(this._lblPersonName, 0, 0);

        this._dtpHireDate = new System.Windows.Forms.DateTimePicker
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            Format = System.Windows.Forms.DateTimePickerFormat.Short,
            Value = System.DateTime.Today
        };
        layout.Controls.Add(MakeLabel("New Start Date *"), 0, 1);
        layout.Controls.Add(this._dtpHireDate, 1, 1);

        this._txtJobTitle = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill };
        layout.Controls.Add(MakeLabel("Job Title *"), 0, 2);
        layout.Controls.Add(this._txtJobTitle, 1, 2);

        var btnPanel = new System.Windows.Forms.FlowLayoutPanel
        {
            FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
            Dock = System.Windows.Forms.DockStyle.Fill,
            Padding = new System.Windows.Forms.Padding(0, 6, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        var btnReHire = new System.Windows.Forms.Button
        {
            Text = "Re-hire",
            Width = 120,
            DialogResult = System.Windows.Forms.DialogResult.OK,
            BackColor = System.Drawing.Color.FromArgb(39, 174, 96),
            ForeColor = System.Drawing.Color.White,
            FlatStyle = System.Windows.Forms.FlatStyle.Flat
        };
        btnReHire.FlatAppearance.BorderSize = 0;
        btnReHire.Click += BtnReHire_Click;

        var btnCancel = new System.Windows.Forms.Button
        {
            Text = "Cancel",
            Width = 120,
            DialogResult = System.Windows.Forms.DialogResult.Cancel
        };
        btnPanel.Controls.AddRange(new System.Windows.Forms.Control[] { btnCancel, btnReHire });
        layout.Controls.Add(btnPanel, 0, 3);

        this.AcceptButton = btnReHire;
        this.CancelButton = btnCancel;
        this.Controls.Add(layout);

        this.Text = "Re-hire Employee";
        this.Size = new System.Drawing.Size(620, 330);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.BackColor = System.Drawing.Color.White;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private static System.Windows.Forms.Label MakeLabel(string text) => new()
    {
        Text = text,
        TextAlign = System.Drawing.ContentAlignment.MiddleRight,
        Dock = System.Windows.Forms.DockStyle.Fill
    };

    private System.Windows.Forms.Label _lblPersonName = null!;
    private System.Windows.Forms.DateTimePicker _dtpHireDate = null!;
    private System.Windows.Forms.TextBox _txtJobTitle = null!;
}
