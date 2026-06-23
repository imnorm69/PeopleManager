namespace PeopleManager.Forms;

partial class AddJobTitleForm
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
            Padding = new System.Windows.Forms.Padding(16),
            ColumnCount = 2,
            RowCount = 3
        };
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165));
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63));

        this._txtTitle = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill };
        this._dtpDate = new System.Windows.Forms.DateTimePicker
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            Format = System.Windows.Forms.DateTimePickerFormat.Short,
            Value = System.DateTime.Today
        };

        var btnPanel = new System.Windows.Forms.FlowLayoutPanel
        {
            FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
            Dock = System.Windows.Forms.DockStyle.Fill,
            Padding = new System.Windows.Forms.Padding(0, 6, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        var btnSave = new System.Windows.Forms.Button
        {
            Text = "Save",
            DialogResult = System.Windows.Forms.DialogResult.OK,
            Width = 120
        };
        var btnCancel = new System.Windows.Forms.Button
        {
            Text = "Cancel",
            DialogResult = System.Windows.Forms.DialogResult.Cancel,
            Width = 120
        };
        btnSave.Click += BtnSave_Click;
        btnPanel.Controls.AddRange(new System.Windows.Forms.Control[] { btnCancel, btnSave });

        layout.Controls.Add(new System.Windows.Forms.Label { Text = "Title *",          TextAlign = System.Drawing.ContentAlignment.MiddleRight, Dock = System.Windows.Forms.DockStyle.Fill }, 0, 0);
        layout.Controls.Add(this._txtTitle, 1, 0);
        layout.Controls.Add(new System.Windows.Forms.Label { Text = "Effective Date *", TextAlign = System.Drawing.ContentAlignment.MiddleRight, Dock = System.Windows.Forms.DockStyle.Fill }, 0, 1);
        layout.Controls.Add(this._dtpDate, 1, 1);
        layout.Controls.Add(btnPanel, 0, 2);

        this.AcceptButton = btnSave;
        this.CancelButton = btnCancel;
        this.Controls.Add(layout);

        this.Text = "Add Job Title";
        this.Size = new System.Drawing.Size(560, 270);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.BackColor = System.Drawing.Color.White;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.TextBox _txtTitle = null!;
    private System.Windows.Forms.DateTimePicker _dtpDate = null!;
}
