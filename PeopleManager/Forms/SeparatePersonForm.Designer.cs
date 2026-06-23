namespace PeopleManager.Forms;

partial class SeparatePersonForm
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
        _lblPersonName = new Label();
        _dtpSeparation = new DateTimePicker();
        _cboReason = new ComboBox();
        _lblNotesRequired = new Label();
        _rtbNotes = new RichTextBox();
        _btnSeparate = new Button();
        layout = new TableLayoutPanel();
        lblSepDate = new Label();
        lblReason = new Label();
        lblNotes = new Label();
        btnPanel = new FlowLayoutPanel();
        btnCancel = new Button();
        layout.SuspendLayout();
        btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _lblPersonName
        // 
        layout.SetColumnSpan(_lblPersonName, 2);
        _lblPersonName.Dock = DockStyle.Fill;
        _lblPersonName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        _lblPersonName.ForeColor = Color.FromArgb(30, 58, 95);
        _lblPersonName.Location = new Point(23, 20);
        _lblPersonName.Name = "_lblPersonName";
        _lblPersonName.Size = new Size(618, 54);
        _lblPersonName.TabIndex = 0;
        _lblPersonName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _dtpSeparation
        // 
        _dtpSeparation.Dock = DockStyle.Fill;
        _dtpSeparation.Format = DateTimePickerFormat.Short;
        _dtpSeparation.Location = new Point(218, 77);
        _dtpSeparation.Name = "_dtpSeparation";
        _dtpSeparation.Size = new Size(423, 32);
        _dtpSeparation.TabIndex = 2;
        _dtpSeparation.Value = new DateTime(2026, 6, 23, 0, 0, 0, 0);
        // 
        // _cboReason
        // 
        _cboReason.Dock = DockStyle.Fill;
        _cboReason.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboReason.Items.AddRange(new object[] { "End of Internship", "Voluntary Resignation", "Termination", "Other" });
        _cboReason.Location = new Point(218, 128);
        _cboReason.Name = "_cboReason";
        _cboReason.Size = new Size(423, 33);
        _cboReason.TabIndex = 4;
        _cboReason.SelectedIndexChanged += CboReason_SelectedIndexChanged;
        // 
        // _lblNotesRequired
        // 
        layout.SetColumnSpan(_lblNotesRequired, 2);
        _lblNotesRequired.Dock = DockStyle.Fill;
        _lblNotesRequired.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
        _lblNotesRequired.ForeColor = Color.FromArgb(192, 57, 43);
        _lblNotesRequired.Location = new Point(23, 176);
        _lblNotesRequired.Name = "_lblNotesRequired";
        _lblNotesRequired.Size = new Size(618, 30);
        _lblNotesRequired.TabIndex = 5;
        // 
        // _rtbNotes
        // 
        _rtbNotes.Dock = DockStyle.Fill;
        _rtbNotes.Font = new Font("Segoe UI", 14F);
        _rtbNotes.Location = new Point(218, 209);
        _rtbNotes.Name = "_rtbNotes";
        _rtbNotes.ScrollBars = RichTextBoxScrollBars.Vertical;
        _rtbNotes.Size = new Size(423, 176);
        _rtbNotes.TabIndex = 7;
        _rtbNotes.Text = "";
        // 
        // _btnSeparate
        // 
        _btnSeparate.BackColor = Color.FromArgb(192, 57, 43);
        _btnSeparate.DialogResult = DialogResult.OK;
        _btnSeparate.FlatAppearance.BorderSize = 0;
        _btnSeparate.FlatStyle = FlatStyle.Flat;
        _btnSeparate.ForeColor = Color.White;
        _btnSeparate.Location = new Point(354, 9);
        _btnSeparate.Name = "_btnSeparate";
        _btnSeparate.Size = new Size(135, 23);
        _btnSeparate.TabIndex = 1;
        _btnSeparate.Text = "Separate";
        _btnSeparate.UseVisualStyleBackColor = false;
        _btnSeparate.Click += BtnSeparate_Click;
        // 
        // layout
        // 
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(_lblPersonName, 0, 0);
        layout.Controls.Add(lblSepDate, 0, 1);
        layout.Controls.Add(_dtpSeparation, 1, 1);
        layout.Controls.Add(lblReason, 0, 2);
        layout.Controls.Add(_cboReason, 1, 2);
        layout.Controls.Add(_lblNotesRequired, 0, 3);
        layout.Controls.Add(lblNotes, 0, 4);
        layout.Controls.Add(_rtbNotes, 1, 4);
        layout.Controls.Add(btnPanel, 0, 5);
        layout.Dock = DockStyle.Fill;
        layout.Location = new Point(0, 0);
        layout.Name = "layout";
        layout.Padding = new Padding(20);
        layout.RowCount = 6;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        layout.Size = new Size(664, 471);
        layout.TabIndex = 0;
        // 
        // lblSepDate
        // 
        lblSepDate.Dock = DockStyle.Fill;
        lblSepDate.Location = new Point(23, 74);
        lblSepDate.Name = "lblSepDate";
        lblSepDate.Size = new Size(189, 51);
        lblSepDate.TabIndex = 1;
        lblSepDate.Text = "Separation Date *";
        lblSepDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblReason
        // 
        lblReason.Dock = DockStyle.Fill;
        lblReason.Location = new Point(23, 125);
        lblReason.Name = "lblReason";
        lblReason.Size = new Size(189, 51);
        lblReason.TabIndex = 3;
        lblReason.Text = "Reason *";
        lblReason.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblNotes
        // 
        lblNotes.Dock = DockStyle.Fill;
        lblNotes.Location = new Point(23, 206);
        lblNotes.Name = "lblNotes";
        lblNotes.Padding = new Padding(0, 4, 4, 0);
        lblNotes.Size = new Size(189, 182);
        lblNotes.TabIndex = 6;
        lblNotes.Text = "Notes";
        lblNotes.TextAlign = ContentAlignment.TopRight;
        // 
        // btnPanel
        // 
        layout.SetColumnSpan(btnPanel, 2);
        btnPanel.Controls.Add(btnCancel);
        btnPanel.Controls.Add(_btnSeparate);
        btnPanel.Dock = DockStyle.Fill;
        btnPanel.FlowDirection = FlowDirection.RightToLeft;
        btnPanel.Location = new Point(23, 391);
        btnPanel.Name = "btnPanel";
        btnPanel.Padding = new Padding(0, 6, 0, 0);
        btnPanel.Size = new Size(618, 57);
        btnPanel.TabIndex = 8;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(495, 9);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(120, 23);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        // 
        // SeparatePersonForm
        // 
        AcceptButton = _btnSeparate;
        BackColor = Color.White;
        CancelButton = btnCancel;
        ClientSize = new Size(664, 471);
        Controls.Add(layout);
        Font = new Font("Segoe UI", 14F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(600, 450);
        Name = "SeparatePersonForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Separate Employee";
        layout.ResumeLayout(false);
        btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label _lblPersonName = null!;
    private System.Windows.Forms.DateTimePicker _dtpSeparation = null!;
    private System.Windows.Forms.ComboBox _cboReason = null!;
    private System.Windows.Forms.Label _lblNotesRequired = null!;
    private System.Windows.Forms.RichTextBox _rtbNotes = null!;
    private System.Windows.Forms.Button _btnSeparate = null!;
    private TableLayoutPanel layout;
    private Label lblSepDate;
    private Label lblReason;
    private Label lblNotes;
    private FlowLayoutPanel btnPanel;
    private Button btnCancel;
}
