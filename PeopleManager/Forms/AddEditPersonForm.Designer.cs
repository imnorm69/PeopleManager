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
        _layout = new TableLayoutPanel();
        _lblLast = new Label();
        _lblFirst = new Label();
        _lblStart = new Label();
        _btnPanel = new FlowLayoutPanel();
        _btnCancel = new Button();
        _btnSave = new Button();
        _layout.SuspendLayout();
        _btnPanel.SuspendLayout();
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
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_lblLast, 0, 0);
        _layout.Controls.Add(_txtLast, 1, 0);
        _layout.Controls.Add(_lblFirst, 0, 1);
        _layout.Controls.Add(_txtFirst, 1, 1);
        _layout.Controls.Add(_lblStart, 0, 2);
        _layout.Controls.Add(_dtpStart, 1, 2);
        _layout.Controls.Add(_lblTitle, 0, 3);
        _layout.Controls.Add(_txtTitle, 1, 3);
        _layout.Controls.Add(_btnPanel, 0, 4);
        _layout.Dock = DockStyle.Fill;
        _layout.Location = new Point(0, 0);
        _layout.Name = "_layout";
        _layout.Padding = new Padding(20);
        _layout.RowCount = 6;
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
        _layout.Size = new Size(604, 421);
        _layout.TabIndex = 0;
        // 
        // _lblLast
        // 
        _lblLast.Dock = DockStyle.Fill;
        _lblLast.Location = new Point(23, 20);
        _lblLast.Name = "_lblLast";
        _lblLast.Size = new Size(174, 51);
        _lblLast.TabIndex = 0;
        _lblLast.Text = "Last Name *";
        _lblLast.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _lblFirst
        // 
        _lblFirst.Dock = DockStyle.Fill;
        _lblFirst.Location = new Point(23, 71);
        _lblFirst.Name = "_lblFirst";
        _lblFirst.Size = new Size(174, 51);
        _lblFirst.TabIndex = 2;
        _lblFirst.Text = "First Name *";
        _lblFirst.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _lblStart
        // 
        _lblStart.Dock = DockStyle.Fill;
        _lblStart.Location = new Point(23, 122);
        _lblStart.Name = "_lblStart";
        _lblStart.Size = new Size(174, 51);
        _lblStart.TabIndex = 4;
        _lblStart.Text = "Start Date *";
        _lblStart.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _btnPanel
        // 
        _layout.SetColumnSpan(_btnPanel, 2);
        _btnPanel.Controls.Add(_btnCancel);
        _btnPanel.Controls.Add(_btnSave);
        _btnPanel.Dock = DockStyle.Fill;
        _btnPanel.FlowDirection = FlowDirection.RightToLeft;
        _btnPanel.Location = new Point(23, 227);
        _btnPanel.Name = "_btnPanel";
        _btnPanel.Padding = new Padding(0, 8, 0, 0);
        _btnPanel.Size = new Size(558, 54);
        _btnPanel.TabIndex = 8;
        // 
        // _btnCancel
        // 
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(435, 11);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(120, 33);
        _btnCancel.TabIndex = 0;
        _btnCancel.Text = "Cancel";
        // 
        // _btnSave
        // 
        _btnSave.DialogResult = DialogResult.OK;
        _btnSave.Location = new Point(309, 11);
        _btnSave.Name = "_btnSave";
        _btnSave.Size = new Size(120, 33);
        _btnSave.TabIndex = 1;
        _btnSave.Text = "Save";
        _btnSave.Click += BtnSave_Click;
        // 
        // AddEditPersonForm
        // 
        AcceptButton = _btnSave;
        BackColor = Color.White;
        CancelButton = _btnCancel;
        ClientSize = new Size(604, 421);
        Controls.Add(_layout);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddEditPersonForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add New Person";
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        _btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox _txtFirst = null!;
    private System.Windows.Forms.TextBox _txtLast = null!;
    private System.Windows.Forms.DateTimePicker _dtpStart = null!;
    private System.Windows.Forms.TextBox _txtTitle = null!;
    private System.Windows.Forms.Label _lblTitle = null!;
    private TableLayoutPanel _layout;
    private Label _lblLast;
    private Label _lblFirst;
    private Label _lblStart;
    private FlowLayoutPanel _btnPanel;
    private Button _btnCancel;
    private Button _btnSave;
}
