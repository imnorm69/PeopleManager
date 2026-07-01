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
        _tableLayout = new TableLayoutPanel();
        _lblTitle = new Label();
        _txtTitle = new TextBox();
        _lblDate = new Label();
        _dtpDate = new DateTimePicker();
        _btnPanel = new FlowLayoutPanel();
        _btnCancel = new Button();
        _btnSave = new Button();
        _tableLayout.SuspendLayout();
        _btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _tableLayout
        // 
        _tableLayout.ColumnCount = 2;
        _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
        _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tableLayout.Controls.Add(_lblTitle, 0, 0);
        _tableLayout.Controls.Add(_txtTitle, 1, 0);
        _tableLayout.Controls.Add(_lblDate, 0, 1);
        _tableLayout.Controls.Add(_dtpDate, 1, 1);
        _tableLayout.Controls.Add(_btnPanel, 0, 2);
        _tableLayout.Dock = DockStyle.Fill;
        _tableLayout.Location = new Point(0, 0);
        _tableLayout.Name = "_tableLayout";
        _tableLayout.Padding = new Padding(16);
        _tableLayout.RowCount = 3;
        _tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        _tableLayout.Size = new Size(544, 231);
        _tableLayout.TabIndex = 0;
        // 
        // _lblTitle
        // 
        _lblTitle.Dock = DockStyle.Fill;
        _lblTitle.Location = new Point(19, 16);
        _lblTitle.Name = "_lblTitle";
        _lblTitle.Size = new Size(159, 51);
        _lblTitle.TabIndex = 0;
        _lblTitle.Text = "Title *";
        _lblTitle.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _txtTitle
        // 
        _txtTitle.Dock = DockStyle.Fill;
        _txtTitle.Location = new Point(184, 19);
        _txtTitle.Name = "_txtTitle";
        _txtTitle.Size = new Size(341, 32);
        _txtTitle.TabIndex = 1;
        // 
        // _lblDate
        // 
        _lblDate.Dock = DockStyle.Fill;
        _lblDate.Location = new Point(19, 67);
        _lblDate.Name = "_lblDate";
        _lblDate.Size = new Size(159, 51);
        _lblDate.TabIndex = 2;
        _lblDate.Text = "Effective Date *";
        _lblDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _dtpDate
        // 
        _dtpDate.Dock = DockStyle.Fill;
        _dtpDate.Format = DateTimePickerFormat.Short;
        _dtpDate.Location = new Point(184, 70);
        _dtpDate.Name = "_dtpDate";
        _dtpDate.Size = new Size(341, 32);
        _dtpDate.TabIndex = 3;
        _dtpDate.Value = new DateTime(2026, 6, 23, 0, 0, 0, 0);
        // 
        // _btnPanel
        // 
        _tableLayout.SetColumnSpan(_btnPanel, 2);
        _btnPanel.Controls.Add(_btnCancel);
        _btnPanel.Controls.Add(_btnSave);
        _btnPanel.Dock = DockStyle.Fill;
        _btnPanel.FlowDirection = FlowDirection.RightToLeft;
        _btnPanel.Location = new Point(19, 121);
        _btnPanel.Name = "_btnPanel";
        _btnPanel.Padding = new Padding(0, 6, 0, 0);
        _btnPanel.Size = new Size(506, 91);
        _btnPanel.TabIndex = 4;
        // 
        // _btnCancel
        // 
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(383, 9);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(120, 38);
        _btnCancel.TabIndex = 0;
        _btnCancel.Text = "Cancel";
        // 
        // _btnSave
        // 
        _btnSave.DialogResult = DialogResult.OK;
        _btnSave.Location = new Point(257, 9);
        _btnSave.Name = "_btnSave";
        _btnSave.Size = new Size(120, 38);
        _btnSave.TabIndex = 1;
        _btnSave.Text = "Save";
        _btnSave.Click += BtnSave_Click;
        // 
        // AddJobTitleForm
        // 
        AcceptButton = _btnSave;
        BackColor = Color.White;
        CancelButton = _btnCancel;
        ClientSize = new Size(544, 231);
        Controls.Add(_tableLayout);
        Font = new Font("Segoe UI", 14F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddJobTitleForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Job Title";
        _tableLayout.ResumeLayout(false);
        _tableLayout.PerformLayout();
        _btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel _tableLayout;
    private System.Windows.Forms.Label _lblTitle;
    private System.Windows.Forms.TextBox _txtTitle;
    private System.Windows.Forms.Label _lblDate;
    private System.Windows.Forms.DateTimePicker _dtpDate;
    private System.Windows.Forms.FlowLayoutPanel _btnPanel;
    private System.Windows.Forms.Button _btnSave;
    private System.Windows.Forms.Button _btnCancel;
}
