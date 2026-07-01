using PeopleManager.Models;

namespace PeopleManager.Forms;

partial class MeetingForm
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
        _lblName = new Label();
        _lblDate = new Label();
        _pnlHeader = new Panel();
        _btnSave = new Button();
        _btnClose = new Button();
        _pnlFooter = new Panel();
        _pnlRightSep = new Panel();
        _lblGlowsHeader = new Label();
        _lblGrowsHeader = new Label();
        _clbGlows = new CheckedListBox();
        _clbGrows = new CheckedListBox();
        _tblRight = new TableLayoutPanel();
        _pnlRight = new Panel();
        _pnlBottomSep = new Panel();
        _btnAddAI = new Button();
        _btnComplete = new Button();
        _btnDeleteAI = new Button();
        _cboAiFilter = new ComboBox();
        _lblAiCount = new Label();
        _flowAI = new FlowLayoutPanel();
        _toolbarAI = new Panel();
        _gridActionItems = new DataGridView();
        _gaiCol0 = new DataGridViewTextBoxColumn();
        _gaiCol1 = new DataGridViewTextBoxColumn();
        _gaiCol2 = new DataGridViewTextBoxColumn();
        _gaiCol3 = new DataGridViewTextBoxColumn();
        _pageAI = new TabPage();
        _infoLbl = new Label();
        _gridMentions = new DataGridView();
        _gmCol0 = new DataGridViewTextBoxColumn();
        _gmCol1 = new DataGridViewTextBoxColumn();
        _gmCol2 = new DataGridViewTextBoxColumn();
        _pageMentions = new TabPage();
        _tabsBottom = new TabControl();
        _pnlBottom = new Panel();
        _tabsMain = new TabControl();
        _pageProjectNotes = new TabPage();
        _rtbProjectNotes = new RichTextBox();
        _pageCareerUpdates = new TabPage();
        _rtbCareerUpdates = new RichTextBox();
        _pageTrainingUpdates = new TabPage();
        _rtbTrainingUpdates = new RichTextBox();
        _pageGeneralNotes = new TabPage();
        _rtbGeneralNotes = new RichTextBox();
        _pageChecklist = new TabPage();
        _pnlChecklistOuter = new Panel();
        _checklistContainer = new Panel();
        _pnlChecklistHdr = new Panel();
        _tblChecklistHdr = new TableLayoutPanel();
        _lblHdrQuestion = new Label();
        _lblHdrFrequency = new Label();
        _lblHdrAnswer = new Label();
        _pnlHeader.SuspendLayout();
        _pnlFooter.SuspendLayout();
        _tblRight.SuspendLayout();
        _pnlRight.SuspendLayout();
        _flowAI.SuspendLayout();
        _toolbarAI.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridActionItems).BeginInit();
        _pageAI.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridMentions).BeginInit();
        _pageMentions.SuspendLayout();
        _tabsBottom.SuspendLayout();
        _pnlBottom.SuspendLayout();
        _tabsMain.SuspendLayout();
        _pageProjectNotes.SuspendLayout();
        _pageCareerUpdates.SuspendLayout();
        _pageTrainingUpdates.SuspendLayout();
        _pageGeneralNotes.SuspendLayout();
        _pageChecklist.SuspendLayout();
        _pnlChecklistOuter.SuspendLayout();
        _pnlChecklistHdr.SuspendLayout();
        _tblChecklistHdr.SuspendLayout();
        SuspendLayout();
        // 
        // _lblName
        // 
        _lblName.Dock = DockStyle.Left;
        _lblName.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        _lblName.ForeColor = Color.White;
        _lblName.Location = new Point(16, 0);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(720, 78);
        _lblName.TabIndex = 1;
        _lblName.Text = "Loading…";
        _lblName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _lblDate
        // 
        _lblDate.Dock = DockStyle.Right;
        _lblDate.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        _lblDate.ForeColor = Color.White;
        _lblDate.Location = new Point(1438, 0);
        _lblDate.Name = "_lblDate";
        _lblDate.Size = new Size(330, 78);
        _lblDate.TabIndex = 0;
        _lblDate.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _pnlHeader
        // 
        _pnlHeader.BackColor = Color.FromArgb(30, 58, 95);
        _pnlHeader.Controls.Add(_lblDate);
        _pnlHeader.Controls.Add(_lblName);
        _pnlHeader.Dock = DockStyle.Top;
        _pnlHeader.Location = new Point(0, 0);
        _pnlHeader.Name = "_pnlHeader";
        _pnlHeader.Padding = new Padding(16, 0, 16, 0);
        _pnlHeader.Size = new Size(1784, 78);
        _pnlHeader.TabIndex = 6;
        // 
        // _btnSave
        // 
        _btnSave.BackColor = Color.FromArgb(41, 128, 185);
        _btnSave.Cursor = Cursors.Hand;
        _btnSave.Dock = DockStyle.Right;
        _btnSave.FlatAppearance.BorderSize = 0;
        _btnSave.FlatStyle = FlatStyle.Flat;
        _btnSave.ForeColor = Color.White;
        _btnSave.Location = new Point(1412, 12);
        _btnSave.Name = "_btnSave";
        _btnSave.Size = new Size(180, 48);
        _btnSave.TabIndex = 0;
        _btnSave.Text = "Save Meeting";
        _btnSave.UseVisualStyleBackColor = false;
        _btnSave.Click += BtnSave_Click;
        // 
        // _btnClose
        // 
        _btnClose.BackColor = Color.FromArgb(127, 140, 141);
        _btnClose.Cursor = Cursors.Hand;
        _btnClose.DialogResult = DialogResult.OK;
        _btnClose.Dock = DockStyle.Right;
        _btnClose.FlatAppearance.BorderSize = 0;
        _btnClose.FlatStyle = FlatStyle.Flat;
        _btnClose.ForeColor = Color.White;
        _btnClose.Location = new Point(1592, 12);
        _btnClose.Name = "_btnClose";
        _btnClose.Size = new Size(180, 48);
        _btnClose.TabIndex = 1;
        _btnClose.Text = "Close";
        _btnClose.UseVisualStyleBackColor = false;
        // 
        // _pnlFooter
        // 
        _pnlFooter.BackColor = Color.White;
        _pnlFooter.Controls.Add(_btnSave);
        _pnlFooter.Controls.Add(_btnClose);
        _pnlFooter.Dock = DockStyle.Bottom;
        _pnlFooter.Location = new Point(0, 749);
        _pnlFooter.Name = "_pnlFooter";
        _pnlFooter.Padding = new Padding(12);
        _pnlFooter.Size = new Size(1784, 72);
        _pnlFooter.TabIndex = 5;
        // 
        // _pnlRightSep
        // 
        _pnlRightSep.BackColor = Color.FromArgb(210, 215, 220);
        _pnlRightSep.Dock = DockStyle.Right;
        _pnlRightSep.Location = new Point(1343, 78);
        _pnlRightSep.Name = "_pnlRightSep";
        _pnlRightSep.Size = new Size(1, 671);
        _pnlRightSep.TabIndex = 3;
        // 
        // _lblGlowsHeader
        // 
        _lblGlowsHeader.Dock = DockStyle.Fill;
        _lblGlowsHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        _lblGlowsHeader.ForeColor = Color.FromArgb(39, 174, 96);
        _lblGlowsHeader.Location = new Point(3, 0);
        _lblGlowsHeader.Name = "_lblGlowsHeader";
        _lblGlowsHeader.Padding = new Padding(2, 0, 0, 2);
        _lblGlowsHeader.Size = new Size(422, 39);
        _lblGlowsHeader.TabIndex = 0;
        _lblGlowsHeader.Text = "Glows";
        _lblGlowsHeader.TextAlign = ContentAlignment.BottomLeft;
        // 
        // _lblGrowsHeader
        // 
        _lblGrowsHeader.Dock = DockStyle.Fill;
        _lblGrowsHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        _lblGrowsHeader.ForeColor = Color.FromArgb(192, 57, 43);
        _lblGrowsHeader.Location = new Point(3, 329);
        _lblGrowsHeader.Name = "_lblGrowsHeader";
        _lblGrowsHeader.Padding = new Padding(2, 0, 0, 2);
        _lblGrowsHeader.Size = new Size(422, 39);
        _lblGrowsHeader.TabIndex = 2;
        _lblGrowsHeader.Text = "Grows";
        _lblGrowsHeader.TextAlign = ContentAlignment.BottomLeft;
        // 
        // _clbGlows
        // 
        _clbGlows.BorderStyle = BorderStyle.FixedSingle;
        _clbGlows.CheckOnClick = true;
        _clbGlows.Dock = DockStyle.Fill;
        _clbGlows.Font = new Font("Segoe UI", 14F);
        _clbGlows.Location = new Point(3, 42);
        _clbGlows.Name = "_clbGlows";
        _clbGlows.Size = new Size(422, 284);
        _clbGlows.TabIndex = 1;
        _clbGlows.MouseDoubleClick += ClbGlows_MouseDoubleClick;
        // 
        // _clbGrows
        // 
        _clbGrows.BorderStyle = BorderStyle.FixedSingle;
        _clbGrows.CheckOnClick = true;
        _clbGrows.Dock = DockStyle.Fill;
        _clbGrows.Font = new Font("Segoe UI", 14F);
        _clbGrows.Location = new Point(3, 371);
        _clbGrows.Name = "_clbGrows";
        _clbGrows.Size = new Size(422, 285);
        _clbGrows.TabIndex = 3;
        _clbGrows.MouseDoubleClick += ClbGrows_MouseDoubleClick;
        // 
        // _tblRight
        // 
        _tblRight.ColumnCount = 1;
        _tblRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tblRight.Controls.Add(_lblGlowsHeader, 0, 0);
        _tblRight.Controls.Add(_clbGlows, 0, 1);
        _tblRight.Controls.Add(_lblGrowsHeader, 0, 2);
        _tblRight.Controls.Add(_clbGrows, 0, 3);
        _tblRight.Dock = DockStyle.Fill;
        _tblRight.Location = new Point(6, 6);
        _tblRight.Name = "_tblRight";
        _tblRight.RowCount = 4;
        _tblRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        _tblRight.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _tblRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        _tblRight.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _tblRight.Size = new Size(428, 659);
        _tblRight.TabIndex = 0;
        // 
        // _pnlRight
        // 
        _pnlRight.BackColor = Color.White;
        _pnlRight.Controls.Add(_tblRight);
        _pnlRight.Dock = DockStyle.Right;
        _pnlRight.Location = new Point(1344, 78);
        _pnlRight.Name = "_pnlRight";
        _pnlRight.Padding = new Padding(6);
        _pnlRight.Size = new Size(440, 671);
        _pnlRight.TabIndex = 4;
        // 
        // _pnlBottomSep
        // 
        _pnlBottomSep.BackColor = Color.FromArgb(210, 215, 220);
        _pnlBottomSep.Dock = DockStyle.Bottom;
        _pnlBottomSep.Location = new Point(0, 428);
        _pnlBottomSep.Name = "_pnlBottomSep";
        _pnlBottomSep.Size = new Size(1343, 1);
        _pnlBottomSep.TabIndex = 1;
        // 
        // _btnAddAI
        // 
        _btnAddAI.AutoSize = true;
        _btnAddAI.BackColor = Color.FromArgb(39, 174, 96);
        _btnAddAI.Cursor = Cursors.Hand;
        _btnAddAI.FlatAppearance.BorderSize = 0;
        _btnAddAI.FlatStyle = FlatStyle.Flat;
        _btnAddAI.ForeColor = Color.White;
        _btnAddAI.Location = new Point(3, 3);
        _btnAddAI.Name = "_btnAddAI";
        _btnAddAI.Padding = new Padding(12, 0, 12, 0);
        _btnAddAI.Size = new Size(199, 40);
        _btnAddAI.TabIndex = 0;
        _btnAddAI.Text = "+ Add Action Item";
        _btnAddAI.UseVisualStyleBackColor = false;
        _btnAddAI.Click += BtnAddAI_Click;
        // 
        // _btnComplete
        // 
        _btnComplete.AutoSize = true;
        _btnComplete.BackColor = Color.FromArgb(41, 128, 185);
        _btnComplete.Cursor = Cursors.Hand;
        _btnComplete.FlatAppearance.BorderSize = 0;
        _btnComplete.FlatStyle = FlatStyle.Flat;
        _btnComplete.ForeColor = Color.White;
        _btnComplete.Location = new Point(211, 0);
        _btnComplete.Margin = new Padding(6, 0, 0, 0);
        _btnComplete.Name = "_btnComplete";
        _btnComplete.Padding = new Padding(12, 0, 12, 0);
        _btnComplete.Size = new Size(175, 40);
        _btnComplete.TabIndex = 1;
        _btnComplete.Text = "Mark Complete";
        _btnComplete.UseVisualStyleBackColor = false;
        _btnComplete.Click += BtnComplete_Click;
        // 
        // _btnDeleteAI
        // 
        _btnDeleteAI.AutoSize = true;
        _btnDeleteAI.BackColor = Color.FromArgb(192, 57, 43);
        _btnDeleteAI.Cursor = Cursors.Hand;
        _btnDeleteAI.FlatAppearance.BorderSize = 0;
        _btnDeleteAI.FlatStyle = FlatStyle.Flat;
        _btnDeleteAI.ForeColor = Color.White;
        _btnDeleteAI.Location = new Point(392, 0);
        _btnDeleteAI.Margin = new Padding(6, 0, 0, 0);
        _btnDeleteAI.Name = "_btnDeleteAI";
        _btnDeleteAI.Padding = new Padding(12, 0, 12, 0);
        _btnDeleteAI.Size = new Size(100, 40);
        _btnDeleteAI.TabIndex = 2;
        _btnDeleteAI.Text = "Delete";
        _btnDeleteAI.UseVisualStyleBackColor = false;
        _btnDeleteAI.Click += BtnDeleteAI_Click;
        // 
        // _cboAiFilter
        // 
        _cboAiFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        _cboAiFilter.Items.AddRange(new object[] { "Open Only", "All" });
        _cboAiFilter.Location = new Point(504, 1);
        _cboAiFilter.Margin = new Padding(12, 1, 0, 0);
        _cboAiFilter.Name = "_cboAiFilter";
        _cboAiFilter.Size = new Size(150, 33);
        _cboAiFilter.TabIndex = 3;
        _cboAiFilter.SelectedIndexChanged += CboAiFilter_SelectedIndexChanged;
        // 
        // _lblAiCount
        // 
        _lblAiCount.AutoSize = true;
        _lblAiCount.ForeColor = Color.FromArgb(100, 100, 100);
        _lblAiCount.Location = new Point(666, 6);
        _lblAiCount.Margin = new Padding(12, 6, 0, 0);
        _lblAiCount.Name = "_lblAiCount";
        _lblAiCount.Size = new Size(0, 25);
        _lblAiCount.TabIndex = 4;
        _lblAiCount.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _flowAI
        // 
        _flowAI.Controls.Add(_btnAddAI);
        _flowAI.Controls.Add(_btnComplete);
        _flowAI.Controls.Add(_btnDeleteAI);
        _flowAI.Controls.Add(_cboAiFilter);
        _flowAI.Controls.Add(_lblAiCount);
        _flowAI.Dock = DockStyle.Fill;
        _flowAI.Location = new Point(6, 6);
        _flowAI.Name = "_flowAI";
        _flowAI.Size = new Size(1323, 42);
        _flowAI.TabIndex = 0;
        // 
        // _toolbarAI
        // 
        _toolbarAI.BackColor = Color.FromArgb(248, 249, 250);
        _toolbarAI.Controls.Add(_flowAI);
        _toolbarAI.Dock = DockStyle.Top;
        _toolbarAI.Location = new Point(0, 0);
        _toolbarAI.Name = "_toolbarAI";
        _toolbarAI.Padding = new Padding(6);
        _toolbarAI.Size = new Size(1335, 54);
        _toolbarAI.TabIndex = 1;
        // 
        // _gridActionItems
        // 
        _gridActionItems.AllowUserToAddRows = false;
        _gridActionItems.AllowUserToDeleteRows = false;
        _gridActionItems.BackgroundColor = Color.White;
        _gridActionItems.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 73, 94);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        _gridActionItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        _gridActionItems.ColumnHeadersHeight = 39;
        _gridActionItems.Columns.AddRange(new DataGridViewColumn[] { _gaiCol0, _gaiCol1, _gaiCol2, _gaiCol3 });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 13F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        _gridActionItems.DefaultCellStyle = dataGridViewCellStyle2;
        _gridActionItems.Dock = DockStyle.Fill;
        _gridActionItems.EnableHeadersVisualStyles = false;
        _gridActionItems.GridColor = Color.FromArgb(220, 230, 240);
        _gridActionItems.Location = new Point(0, 54);
        _gridActionItems.MultiSelect = false;
        _gridActionItems.Name = "_gridActionItems";
        _gridActionItems.ReadOnly = true;
        _gridActionItems.RowHeadersVisible = false;
        _gridActionItems.RowTemplate.Height = 36;
        _gridActionItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _gridActionItems.Size = new Size(1335, 228);
        _gridActionItems.TabIndex = 0;
        // 
        // _gaiCol0
        // 
        _gaiCol0.HeaderText = "Added";
        _gaiCol0.Name = "_gaiCol0";
        _gaiCol0.ReadOnly = true;
        _gaiCol0.Width = 120;
        // 
        // _gaiCol1
        // 
        _gaiCol1.HeaderText = "Assigned To";
        _gaiCol1.Name = "_gaiCol1";
        _gaiCol1.ReadOnly = true;
        _gaiCol1.Width = 140;
        // 
        // _gaiCol2
        // 
        _gaiCol2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        _gaiCol2.HeaderText = "Description";
        _gaiCol2.Name = "_gaiCol2";
        _gaiCol2.ReadOnly = true;
        // 
        // _gaiCol3
        // 
        _gaiCol3.HeaderText = "Due Date";
        _gaiCol3.Name = "_gaiCol3";
        _gaiCol3.ReadOnly = true;
        _gaiCol3.Width = 135;
        // 
        // _pageAI
        // 
        _pageAI.Controls.Add(_gridActionItems);
        _pageAI.Controls.Add(_toolbarAI);
        _pageAI.Location = new Point(4, 34);
        _pageAI.Name = "_pageAI";
        _pageAI.Size = new Size(1335, 282);
        _pageAI.TabIndex = 0;
        _pageAI.Text = "Action Items";
        // 
        // _infoLbl
        // 
        _infoLbl.Dock = DockStyle.Top;
        _infoLbl.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
        _infoLbl.ForeColor = Color.FromArgb(100, 100, 100);
        _infoLbl.Location = new Point(0, 0);
        _infoLbl.Name = "_infoLbl";
        _infoLbl.Padding = new Padding(6, 0, 0, 0);
        _infoLbl.Size = new Size(192, 36);
        _infoLbl.TabIndex = 1;
        _infoLbl.Text = "Open action items from other meetings that tag this person with @";
        _infoLbl.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _gridMentions
        // 
        _gridMentions.AllowUserToAddRows = false;
        _gridMentions.AllowUserToDeleteRows = false;
        _gridMentions.BackgroundColor = Color.White;
        _gridMentions.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = Color.FromArgb(52, 73, 94);
        dataGridViewCellStyle3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        dataGridViewCellStyle3.ForeColor = Color.White;
        dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
        _gridMentions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
        _gridMentions.ColumnHeadersHeight = 39;
        _gridMentions.Columns.AddRange(new DataGridViewColumn[] { _gmCol0, _gmCol1, _gmCol2 });
        dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle4.BackColor = SystemColors.Window;
        dataGridViewCellStyle4.Font = new Font("Segoe UI", 13F);
        dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
        _gridMentions.DefaultCellStyle = dataGridViewCellStyle4;
        _gridMentions.Dock = DockStyle.Fill;
        _gridMentions.EnableHeadersVisualStyles = false;
        _gridMentions.GridColor = Color.FromArgb(220, 230, 240);
        _gridMentions.Location = new Point(0, 36);
        _gridMentions.MultiSelect = false;
        _gridMentions.Name = "_gridMentions";
        _gridMentions.ReadOnly = true;
        _gridMentions.RowHeadersVisible = false;
        _gridMentions.RowTemplate.Height = 36;
        _gridMentions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _gridMentions.Size = new Size(192, 246);
        _gridMentions.TabIndex = 0;
        // 
        // _gmCol0
        // 
        _gmCol0.HeaderText = "Their Meeting Person";
        _gmCol0.Name = "_gmCol0";
        _gmCol0.ReadOnly = true;
        _gmCol0.Width = 240;
        // 
        // _gmCol1
        // 
        _gmCol1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        _gmCol1.HeaderText = "Description";
        _gmCol1.Name = "_gmCol1";
        _gmCol1.ReadOnly = true;
        // 
        // _gmCol2
        // 
        _gmCol2.HeaderText = "Due Date";
        _gmCol2.Name = "_gmCol2";
        _gmCol2.ReadOnly = true;
        _gmCol2.Width = 135;
        // 
        // _pageMentions
        // 
        _pageMentions.Controls.Add(_gridMentions);
        _pageMentions.Controls.Add(_infoLbl);
        _pageMentions.Location = new Point(4, 34);
        _pageMentions.Name = "_pageMentions";
        _pageMentions.Size = new Size(192, 282);
        _pageMentions.TabIndex = 1;
        _pageMentions.Text = "Mentions";
        // 
        // _tabsBottom
        // 
        _tabsBottom.Controls.Add(_pageAI);
        _tabsBottom.Controls.Add(_pageMentions);
        _tabsBottom.Dock = DockStyle.Fill;
        _tabsBottom.Font = new Font("Segoe UI", 14F);
        _tabsBottom.Location = new Point(0, 0);
        _tabsBottom.Name = "_tabsBottom";
        _tabsBottom.SelectedIndex = 0;
        _tabsBottom.Size = new Size(1343, 320);
        _tabsBottom.TabIndex = 0;
        // 
        // _pnlBottom
        // 
        _pnlBottom.BackColor = Color.White;
        _pnlBottom.Controls.Add(_tabsBottom);
        _pnlBottom.Dock = DockStyle.Bottom;
        _pnlBottom.Location = new Point(0, 429);
        _pnlBottom.Name = "_pnlBottom";
        _pnlBottom.Size = new Size(1343, 320);
        _pnlBottom.TabIndex = 2;
        // 
        // _tabsMain
        // 
        _tabsMain.Controls.Add(_pageProjectNotes);
        _tabsMain.Controls.Add(_pageCareerUpdates);
        _tabsMain.Controls.Add(_pageTrainingUpdates);
        _tabsMain.Controls.Add(_pageGeneralNotes);
        _tabsMain.Controls.Add(_pageChecklist);
        _tabsMain.Dock = DockStyle.Fill;
        _tabsMain.DrawMode = TabDrawMode.OwnerDrawFixed;
        _tabsMain.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        _tabsMain.ItemSize = new Size(240, 40);
        _tabsMain.Location = new Point(0, 78);
        _tabsMain.Name = "_tabsMain";
        _tabsMain.Padding = new Point(0, 4);
        _tabsMain.SelectedIndex = 0;
        _tabsMain.Size = new Size(1343, 350);
        _tabsMain.SizeMode = TabSizeMode.Fixed;
        _tabsMain.TabIndex = 0;
        _tabsMain.DrawItem += OnTabsMainDrawItem;
        _tabsMain.SelectedIndexChanged += TabsMain_SelectedIndexChanged;
        // 
        // _pageProjectNotes
        // 
        _pageProjectNotes.BackColor = Color.White;
        _pageProjectNotes.Controls.Add(_rtbProjectNotes);
        _pageProjectNotes.Location = new Point(4, 44);
        _pageProjectNotes.Name = "_pageProjectNotes";
        _pageProjectNotes.Size = new Size(1335, 302);
        _pageProjectNotes.TabIndex = 0;
        _pageProjectNotes.Text = "Project Notes";
        // 
        // _rtbProjectNotes
        // 
        _rtbProjectNotes.BackColor = Color.White;
        _rtbProjectNotes.BorderStyle = BorderStyle.None;
        _rtbProjectNotes.Dock = DockStyle.Fill;
        _rtbProjectNotes.Font = new Font("Segoe UI", 13F);
        _rtbProjectNotes.Location = new Point(0, 0);
        _rtbProjectNotes.Name = "_rtbProjectNotes";
        _rtbProjectNotes.ScrollBars = RichTextBoxScrollBars.Vertical;
        _rtbProjectNotes.Size = new Size(1335, 302);
        _rtbProjectNotes.TabIndex = 0;
        _rtbProjectNotes.Text = "";
        // 
        // _pageCareerUpdates
        // 
        _pageCareerUpdates.BackColor = Color.White;
        _pageCareerUpdates.Controls.Add(_rtbCareerUpdates);
        _pageCareerUpdates.Location = new Point(4, 44);
        _pageCareerUpdates.Name = "_pageCareerUpdates";
        _pageCareerUpdates.Size = new Size(192, 52);
        _pageCareerUpdates.TabIndex = 1;
        _pageCareerUpdates.Text = "Career Updates";
        // 
        // _rtbCareerUpdates
        // 
        _rtbCareerUpdates.BackColor = Color.White;
        _rtbCareerUpdates.BorderStyle = BorderStyle.None;
        _rtbCareerUpdates.Dock = DockStyle.Fill;
        _rtbCareerUpdates.Font = new Font("Segoe UI", 13F);
        _rtbCareerUpdates.Location = new Point(0, 0);
        _rtbCareerUpdates.Name = "_rtbCareerUpdates";
        _rtbCareerUpdates.ScrollBars = RichTextBoxScrollBars.Vertical;
        _rtbCareerUpdates.Size = new Size(192, 52);
        _rtbCareerUpdates.TabIndex = 0;
        _rtbCareerUpdates.Text = "";
        // 
        // _pageTrainingUpdates
        // 
        _pageTrainingUpdates.BackColor = Color.White;
        _pageTrainingUpdates.Controls.Add(_rtbTrainingUpdates);
        _pageTrainingUpdates.Location = new Point(4, 44);
        _pageTrainingUpdates.Name = "_pageTrainingUpdates";
        _pageTrainingUpdates.Size = new Size(192, 52);
        _pageTrainingUpdates.TabIndex = 2;
        _pageTrainingUpdates.Text = "Training Updates";
        // 
        // _rtbTrainingUpdates
        // 
        _rtbTrainingUpdates.BackColor = Color.White;
        _rtbTrainingUpdates.BorderStyle = BorderStyle.None;
        _rtbTrainingUpdates.Dock = DockStyle.Fill;
        _rtbTrainingUpdates.Font = new Font("Segoe UI", 13F);
        _rtbTrainingUpdates.Location = new Point(0, 0);
        _rtbTrainingUpdates.Name = "_rtbTrainingUpdates";
        _rtbTrainingUpdates.ScrollBars = RichTextBoxScrollBars.Vertical;
        _rtbTrainingUpdates.Size = new Size(192, 52);
        _rtbTrainingUpdates.TabIndex = 0;
        _rtbTrainingUpdates.Text = "";
        // 
        // _pageGeneralNotes
        // 
        _pageGeneralNotes.BackColor = Color.White;
        _pageGeneralNotes.Controls.Add(_rtbGeneralNotes);
        _pageGeneralNotes.Location = new Point(4, 44);
        _pageGeneralNotes.Name = "_pageGeneralNotes";
        _pageGeneralNotes.Size = new Size(192, 52);
        _pageGeneralNotes.TabIndex = 3;
        _pageGeneralNotes.Text = "General Notes";
        // 
        // _rtbGeneralNotes
        // 
        _rtbGeneralNotes.BackColor = Color.White;
        _rtbGeneralNotes.BorderStyle = BorderStyle.None;
        _rtbGeneralNotes.Dock = DockStyle.Fill;
        _rtbGeneralNotes.Font = new Font("Segoe UI", 13F);
        _rtbGeneralNotes.Location = new Point(0, 0);
        _rtbGeneralNotes.Name = "_rtbGeneralNotes";
        _rtbGeneralNotes.ScrollBars = RichTextBoxScrollBars.Vertical;
        _rtbGeneralNotes.Size = new Size(192, 52);
        _rtbGeneralNotes.TabIndex = 0;
        _rtbGeneralNotes.Text = "";
        // 
        // _pageChecklist
        // 
        _pageChecklist.BackColor = Color.White;
        _pageChecklist.Controls.Add(_pnlChecklistOuter);
        _pageChecklist.Location = new Point(4, 44);
        _pageChecklist.Name = "_pageChecklist";
        _pageChecklist.Size = new Size(192, 52);
        _pageChecklist.TabIndex = 4;
        _pageChecklist.Text = "Checklist";
        // 
        // _pnlChecklistOuter
        // 
        _pnlChecklistOuter.BackColor = Color.White;
        _pnlChecklistOuter.Controls.Add(_checklistContainer);
        _pnlChecklistOuter.Controls.Add(_pnlChecklistHdr);
        _pnlChecklistOuter.Dock = DockStyle.Fill;
        _pnlChecklistOuter.Location = new Point(0, 0);
        _pnlChecklistOuter.Name = "_pnlChecklistOuter";
        _pnlChecklistOuter.Size = new Size(192, 52);
        _pnlChecklistOuter.TabIndex = 0;
        // 
        // _checklistContainer
        // 
        _checklistContainer.AutoScroll = true;
        _checklistContainer.BackColor = Color.White;
        _checklistContainer.Dock = DockStyle.Fill;
        _checklistContainer.Location = new Point(0, 40);
        _checklistContainer.Name = "_checklistContainer";
        _checklistContainer.Size = new Size(192, 12);
        _checklistContainer.TabIndex = 0;
        // 
        // _pnlChecklistHdr
        // 
        _pnlChecklistHdr.BackColor = Color.FromArgb(52, 73, 94);
        _pnlChecklistHdr.Controls.Add(_tblChecklistHdr);
        _pnlChecklistHdr.Dock = DockStyle.Top;
        _pnlChecklistHdr.Location = new Point(0, 0);
        _pnlChecklistHdr.Name = "_pnlChecklistHdr";
        _pnlChecklistHdr.Size = new Size(192, 40);
        _pnlChecklistHdr.TabIndex = 1;
        // 
        // _tblChecklistHdr
        //
        _tblChecklistHdr.ColumnCount = 3;
        _tblChecklistHdr.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tblChecklistHdr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        _tblChecklistHdr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
        _tblChecklistHdr.Controls.Add(_lblHdrQuestion, 0, 0);
        _tblChecklistHdr.Controls.Add(_lblHdrFrequency, 1, 0);
        _tblChecklistHdr.Controls.Add(_lblHdrAnswer, 2, 0);
        _tblChecklistHdr.Dock = DockStyle.Fill;
        _tblChecklistHdr.Location = new Point(0, 0);
        _tblChecklistHdr.Name = "_tblChecklistHdr";
        _tblChecklistHdr.RowCount = 1;
        _tblChecklistHdr.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _tblChecklistHdr.Size = new Size(192, 40);
        _tblChecklistHdr.TabIndex = 0;
        // 
        // _lblHdrQuestion
        // 
        _lblHdrQuestion.Dock = DockStyle.Fill;
        _lblHdrQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        _lblHdrQuestion.ForeColor = Color.White;
        _lblHdrQuestion.Location = new Point(3, 0);
        _lblHdrQuestion.Name = "_lblHdrQuestion";
        _lblHdrQuestion.Size = new Size(1, 40);
        _lblHdrQuestion.TabIndex = 0;
        _lblHdrQuestion.Text = "Question";
        _lblHdrQuestion.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblHdrFrequency
        // 
        _lblHdrFrequency.Dock = DockStyle.Fill;
        _lblHdrFrequency.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        _lblHdrFrequency.ForeColor = Color.White;
        _lblHdrFrequency.Location = new Point(-195, 0);
        _lblHdrFrequency.Name = "_lblHdrFrequency";
        _lblHdrFrequency.Size = new Size(124, 40);
        _lblHdrFrequency.TabIndex = 1;
        _lblHdrFrequency.Text = "Frequency";
        _lblHdrFrequency.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _lblHdrAnswer
        // 
        _lblHdrAnswer.Dock = DockStyle.Fill;
        _lblHdrAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        _lblHdrAnswer.ForeColor = Color.White;
        _lblHdrAnswer.Location = new Point(-65, 0);
        _lblHdrAnswer.Name = "_lblHdrAnswer";
        _lblHdrAnswer.Size = new Size(254, 40);
        _lblHdrAnswer.TabIndex = 2;
        _lblHdrAnswer.Text = "Answer";
        _lblHdrAnswer.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MeetingForm
        // 
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1784, 821);
        Controls.Add(_tabsMain);
        Controls.Add(_pnlBottomSep);
        Controls.Add(_pnlBottom);
        Controls.Add(_pnlRightSep);
        Controls.Add(_pnlRight);
        Controls.Add(_pnlFooter);
        Controls.Add(_pnlHeader);
        Font = new Font("Segoe UI", 14F);
        MinimumSize = new Size(1300, 680);
        Name = "MeetingForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "1:1 Meeting";
        _pnlHeader.ResumeLayout(false);
        _pnlFooter.ResumeLayout(false);
        _tblRight.ResumeLayout(false);
        _tblRight.PerformLayout();
        _pnlRight.ResumeLayout(false);
        _flowAI.ResumeLayout(false);
        _flowAI.PerformLayout();
        _toolbarAI.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_gridActionItems).EndInit();
        _pageAI.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_gridMentions).EndInit();
        _pageMentions.ResumeLayout(false);
        _tabsBottom.ResumeLayout(false);
        _pnlBottom.ResumeLayout(false);
        _tabsMain.ResumeLayout(false);
        _pageProjectNotes.ResumeLayout(false);
        _pageCareerUpdates.ResumeLayout(false);
        _pageTrainingUpdates.ResumeLayout(false);
        _pageGeneralNotes.ResumeLayout(false);
        _pageChecklist.ResumeLayout(false);
        _pnlChecklistOuter.ResumeLayout(false);
        _pnlChecklistHdr.ResumeLayout(false);
        _tblChecklistHdr.ResumeLayout(false);
        _tblChecklistHdr.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label          _lblName            = null!;
    private System.Windows.Forms.Label          _lblDate            = null!;
    private System.Windows.Forms.Label          _lblGlowsHeader     = null!;
    private System.Windows.Forms.Label          _lblGrowsHeader     = null!;
    private System.Windows.Forms.CheckedListBox _clbGlows           = null!;
    private System.Windows.Forms.CheckedListBox _clbGrows           = null!;
    private System.Windows.Forms.DataGridView   _gridActionItems    = null!;
    private System.Windows.Forms.ComboBox       _cboAiFilter        = null!;
    private System.Windows.Forms.Label          _lblAiCount         = null!;
    private System.Windows.Forms.DataGridView   _gridMentions       = null!;
    private System.Windows.Forms.Panel          _checklistContainer = null!;
    private System.Windows.Forms.TabControl     _tabsMain           = null!;
    private System.Drawing.Color[]              _tabColors          = null!;
    private System.Windows.Forms.RichTextBox    _rtbProjectNotes    = null!;
    private System.Windows.Forms.RichTextBox    _rtbCareerUpdates   = null!;
    private System.Windows.Forms.RichTextBox    _rtbTrainingUpdates = null!;
    private System.Windows.Forms.RichTextBox    _rtbGeneralNotes    = null!;
    private Panel _pnlHeader;
    private Button _btnSave;
    private Button _btnClose;
    private Panel _pnlFooter;
    private Panel _pnlRightSep;
    private TableLayoutPanel _tblRight;
    private Panel _pnlRight;
    private Panel _pnlBottomSep;
    private Button _btnAddAI;
    private Button _btnComplete;
    private Button _btnDeleteAI;
    private FlowLayoutPanel _flowAI;
    private Panel _toolbarAI;
    private DataGridViewTextBoxColumn _gaiCol0;
    private DataGridViewTextBoxColumn _gaiCol1;
    private DataGridViewTextBoxColumn _gaiCol2;
    private DataGridViewTextBoxColumn _gaiCol3;
    private TabPage _pageAI;
    private Label _infoLbl;
    private DataGridViewTextBoxColumn _gmCol0;
    private DataGridViewTextBoxColumn _gmCol1;
    private DataGridViewTextBoxColumn _gmCol2;
    private TabPage _pageMentions;
    private TabControl _tabsBottom;
    private Panel _pnlBottom;
    private TabPage _pageProjectNotes;
    private TabPage _pageCareerUpdates;
    private TabPage _pageTrainingUpdates;
    private TabPage _pageGeneralNotes;
    private TabPage _pageChecklist;
    private Panel _pnlChecklistOuter;
    private Panel _pnlChecklistHdr;
    private TableLayoutPanel _tblChecklistHdr;
    private Label _lblHdrQuestion;
    private Label _lblHdrFrequency;
    private Label _lblHdrAnswer;
}
