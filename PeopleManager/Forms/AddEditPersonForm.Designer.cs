namespace PeopleManager.Forms;

partial class AddEditPersonForm
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
        _txtLast = new TextBox();
        _txtFirst = new TextBox();
        _dtpStart = new DateTimePicker();
        _txtTitle = new TextBox();
        _lblTitle = new Label();
        layout = new TableLayoutPanel();
        lblLast = new Label();
        lblFirst = new Label();
        lblStart = new Label();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        btnSave = new Button();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _txtLast
        // 
        _txtLast.Dock = DockStyle.Fill;
        _txtLast.Location = new Point(203, 23);
        _txtLast.Name = "_txtLast";
        _txtLast.Size = new Size(378, 32);
        _txtLast.TabIndex = 1;
        // 
        // _txtFirst
        // 
        _txtFirst.Dock = DockStyle.Fill;
        _txtFirst.Location = new Point(203, 74);
        _txtFirst.Name = "_txtFirst";
        _txtFirst.Size = new Size(378, 32);
        _txtFirst.TabIndex = 3;
        // 
        // _dtpStart
        // 
        _dtpStart.Dock = DockStyle.Fill;
        _dtpStart.Format = DateTimePickerFormat.Short;
        _dtpStart.Location = new Point(203, 125);
        _dtpStart.Name = "_dtpStart";
        _dtpStart.Size = new Size(378, 32);
        _dtpStart.TabIndex = 5;
        _dtpStart.Value = new DateTime(2026, 6, 23, 0, 0, 0, 0);
        // 
        // _txtTitle
        // 
        _txtTitle.Dock = DockStyle.Fill;
        _txtTitle.Location = new Point(203, 176);
        _txtTitle.Name = "_txtTitle";
        _txtTitle.Size = new Size(378, 32);
        _txtTitle.TabIndex = 7;
        // 
        // _lblTitle
        // 
        _lblTitle.Dock = DockStyle.Fill;
        _lblTitle.Location = new Point(23, 173);
        _lblTitle.Name = "_lblTitle";
        _lblTitle.Size = new Size(174, 51);
        _lblTitle.TabIndex = 6;
        _lblTitle.Text = "Job Title *";
        _lblTitle.TextAlign = ContentAlignment.MiddleRight;
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(lblLast, 0, 0);
        layout.Controls.Add(_txtLast, 1, 0);
        layout.Controls.Add(lblFirst, 0, 1);
        layout.Controls.Add(_txtFirst, 1, 1);
        layout.Controls.Add(lblStart, 0, 2);
        layout.Controls.Add(_dtpStart, 1, 2);
        layout.Controls.Add(_lblTitle, 0, 3);
        layout.Controls.Add(_txtTitle, 1, 3);
        layout.Controls.Add(btnPanel, 0, 4);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(20);
        layout.RowCount = 6;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
        layout.Size = new Size(604, 421);
        layout.TabIndex = 0;
        // 
        // lblLast
        // 
        lblLast.Dock = DockStyle.Fill;
        lblLast.Location = new Point(23, 20);
        lblLast.Name = "lblLast";
        lblLast.Size = new Size(174, 51);
        lblLast.TabIndex = 0;
        lblLast.Text = "Last Name *";
        lblLast.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblFirst
        // 
        lblFirst.Dock = DockStyle.Fill;
        lblFirst.Location = new Point(23, 71);
        lblFirst.Name = "lblFirst";
        lblFirst.Size = new Size(174, 51);
        lblFirst.TabIndex = 2;
        lblFirst.Text = "First Name *";
        lblFirst.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblStart
        // 
        lblStart.Dock = DockStyle.Fill;
        lblStart.Location = new Point(23, 122);
        lblStart.Name = "lblStart";
        lblStart.Size = new Size(174, 51);
        lblStart.TabIndex = 4;
        lblStart.Text = "Start Date *";
        lblStart.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(btnSave);
        btnPanel.Dock = DockStyle.Fill;
        btnPanel.FlowDirection = FlowDirection.RightToLeft;
        btnPanel.Location = new Point(23, 227);
        btnPanel.Name = "btnPanel";
        btnPanel.Padding = new Padding(0, 8, 0, 0);
        btnPanel.Size = new Size(558, 54);
        btnPanel.TabIndex = 8;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(435, 11);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 33);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        // 
        // btnSave
        // 
        btnSave.DialogResult = DialogResult.OK;
        btnSave.Location = new Point(309, 11);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(120, 33);
        btnSave.TabIndex = 1;
        btnSave.Text = "Save";
        btnSave.Click += BtnSave_Click;
        // 
        // AddEditPersonForm
        // 
        AcceptButton = btnSave;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(604, 421);
        Controls.Add(layout);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddEditPersonForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add New Person";
        layout.ResumeLayout(false);
        layout.PerformLayout();
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox _txtFirst = null!;
    private System.Windows.Forms.TextBox _txtLast = null!;
    private System.Windows.Forms.DateTimePicker _dtpStart = null!;
    private System.Windows.Forms.TextBox _txtTitle = null!;
    private System.Windows.Forms.Label _lblTitle = null!;
    private TableLayoutPanel layout;
    private Label lblLast;
    private Label lblFirst;
    private Label lblStart;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
    private Button btnSave;
}
