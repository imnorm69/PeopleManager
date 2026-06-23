namespace PeopleManager.Forms;

partial class CompleteActionItemForm
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
            Padding = new System.Windows.Forms.Padding(14),
            ColumnCount = 2,
            RowCount = 4
        };
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165));
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60));

        this._lblDescription = new System.Windows.Forms.Label
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            AutoSize = false,
            TextAlign = System.Drawing.ContentAlignment.TopLeft,
            Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Italic),
            ForeColor = System.Drawing.Color.FromArgb(60, 60, 60),
            Padding = new System.Windows.Forms.Padding(2)
        };
        layout.Controls.Add(new System.Windows.Forms.Label { Text = "Action Item", TextAlign = System.Drawing.ContentAlignment.TopRight, Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(0, 3, 4, 0) }, 0, 0);
        layout.Controls.Add(this._lblDescription, 1, 0);

        this._dtpCompleted = new System.Windows.Forms.DateTimePicker
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            Format = System.Windows.Forms.DateTimePickerFormat.Short,
            Value = System.DateTime.Today
        };
        layout.Controls.Add(new System.Windows.Forms.Label { Text = "Completed", TextAlign = System.Drawing.ContentAlignment.MiddleRight, Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(0, 0, 4, 0) }, 0, 1);
        layout.Controls.Add(this._dtpCompleted, 1, 1);

        this._rtbNotes = new System.Windows.Forms.RichTextBox
        {
            Dock = System.Windows.Forms.DockStyle.Fill,
            ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical,
            Font = new System.Drawing.Font("Segoe UI", 14f)
        };
        layout.Controls.Add(new System.Windows.Forms.Label { Text = "Notes\n(optional)", TextAlign = System.Drawing.ContentAlignment.TopRight, Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(0, 3, 4, 0) }, 0, 2);
        layout.Controls.Add(this._rtbNotes, 1, 2);

        var btnPanel = new System.Windows.Forms.FlowLayoutPanel
        {
            FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft,
            Dock = System.Windows.Forms.DockStyle.Fill,
            Padding = new System.Windows.Forms.Padding(0, 6, 0, 0)
        };
        layout.SetColumnSpan(btnPanel, 2);

        var btnSave   = new System.Windows.Forms.Button { Text = "Mark Complete", Width = 165, DialogResult = System.Windows.Forms.DialogResult.OK };
        var btnCancel = new System.Windows.Forms.Button { Text = "Cancel",        Width = 120, DialogResult = System.Windows.Forms.DialogResult.Cancel };
        btnSave.Click += BtnSave_Click;
        btnPanel.Controls.AddRange(new System.Windows.Forms.Control[] { btnCancel, btnSave });
        layout.Controls.Add(btnPanel, 0, 3);

        this.AcceptButton = btnSave;
        this.CancelButton = btnCancel;
        this.Controls.Add(layout);

        this.Text = "Mark Action Item Complete";
        this.Size = new System.Drawing.Size(700, 450);
        this.MinimumSize = new System.Drawing.Size(600, 390);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.BackColor = System.Drawing.Color.White;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label _lblDescription = null!;
    private System.Windows.Forms.DateTimePicker _dtpCompleted = null!;
    private System.Windows.Forms.RichTextBox _rtbNotes = null!;
}
