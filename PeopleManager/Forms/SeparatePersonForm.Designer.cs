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
        _layout = new TableLayoutPanel();
        _lblSepDate = new Label();
        _lblReason = new Label();
        _lblNotes = new Label();
        _btnPanel = new FlowLayoutPanel();
        _btnCancel = new Button();
        _layout.SuspendLayout();
        _btnPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _lblPersonName
        // 
        _layout.SetColumnSpan(_lblPersonName, 2);
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
        _layout.SetColumnSpan(_lblNotesRequired, 2);
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
        // _layout
        // 
        _layout.ColumnCount = 2;
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195F));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_lblPersonName, 0, 0);
        _layout.Controls.Add(_lblSepDate, 0, 1);
        _layout.Controls.Add(_dtpSeparation, 1, 1);
        _layout.Controls.Add(_lblReason, 0, 2);
        _layout.Controls.Add(_cboReason, 1, 2);
        _layout.Controls.Add(_lblNotesRequired, 0, 3);
        _layout.Controls.Add(_lblNotes, 0, 4);
        _layout.Controls.Add(_rtbNotes, 1, 4);
        _layout.Controls.Add(_btnPanel, 0, 5);
        _layout.Dock = DockStyle.Fill;
        _layout.Location = new Point(0, 0);
        _layout.Name = "_layout";
        _layout.Padding = new Padding(20);
        _layout.RowCount = 6;
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
        _layout.Size = new Size(664, 471);
        _layout.TabIndex = 0;
        // 
        // _lblSepDate
        // 
        _lblSepDate.Dock = DockStyle.Fill;
        _lblSepDate.Location = new Point(23, 74);
        _lblSepDate.Name = "_lblSepDate";
        _lblSepDate.Size = new Size(189, 51);
        _lblSepDate.TabIndex = 1;
        _lblSepDate.Text = "Separation Date *";
        _lblSepDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _lblReason
        // 
        _lblReason.Dock = DockStyle.Fill;
        _lblReason.Location = new Point(23, 125);
        _lblReason.Name = "_lblReason";
        _lblReason.Size = new Size(189, 51);
        _lblReason.TabIndex = 3;
        _lblReason.Text = "Reason *";
        _lblReason.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _lblNotes
        // 
        _lblNotes.Dock = DockStyle.Fill;
        _lblNotes.Location = new Point(23, 206);
        _lblNotes.Name = "_lblNotes";
        _lblNotes.Padding = new Padding(0, 4, 4, 0);
        _lblNotes.Size = new Size(189, 182);
        _lblNotes.TabIndex = 6;
        _lblNotes.Text = "Notes";
        _lblNotes.TextAlign = ContentAlignment.TopRight;
        // 
        // _btnPanel
        // 
        _layout.SetColumnSpan(_btnPanel, 2);
        _btnPanel.Controls.Add(_btnCancel);
        _btnPanel.Controls.Add(_btnSeparate);
        _btnPanel.Dock = DockStyle.Fill;
        _btnPanel.FlowDirection = FlowDirection.RightToLeft;
        _btnPanel.Location = new Point(23, 391);
        _btnPanel.Name = "_btnPanel";
        _btnPanel.Padding = new Padding(0, 6, 0, 0);
        _btnPanel.Size = new Size(618, 57);
        _btnPanel.TabIndex = 8;
        // 
        // _btnCancel
        // 
        _btnCancel.DialogResult = DialogResult.Cancel;
        _btnCancel.Location = new Point(495, 9);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new Size(120, 23);
        _btnCancel.TabIndex = 0;
        _btnCancel.Text = "Cancel";
        // 
        // SeparatePersonForm
        // 
        AcceptButton = _btnSeparate;
        BackColor = Color.White;
        CancelButton = _btnCancel;
        ClientSize = new Size(664, 471);
        Controls.Add(_layout);
        Font = new Font("Segoe UI", 14F);
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(600, 450);
        Name = "SeparatePersonForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Separate Employee";
        _layout.ResumeLayout(false);
        _layout.PerformLayout();
        _btnPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label _lblPersonName = null!;
    private System.Windows.Forms.DateTimePicker _dtpSeparation = null!;
    private System.Windows.Forms.ComboBox _cboReason = null!;
    private System.Windows.Forms.Label _lblNotesRequired = null!;
    private System.Windows.Forms.RichTextBox _rtbNotes = null!;
    private System.Windows.Forms.Button _btnSeparate = null!;
    private TableLayoutPanel _layout;
    private Label _lblSepDate;
    private Label _lblReason;
    private Label _lblNotes;
    private FlowLayoutPanel _btnPanel;
    private Button _btnCancel;
}
