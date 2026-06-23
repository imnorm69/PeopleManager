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
        pnlHeader = new Panel();
        btnSave = new Button();
        btnClose = new Button();
        pnlFooter = new Panel();
        pnlRightSep = new Panel();
        _lblGlowsHeader = new Label();
        _lblGrowsHeader = new Label();
        _clbGlows = new CheckedListBox();
        _clbGrows = new CheckedListBox();
        tblRight = new TableLayoutPanel();
        pnlRight = new Panel();
        pnlBottomSep = new Panel();
        btnAddAI = new Button();
        btnComplete = new Button();
        btnDeleteAI = new Button();
        _cboAiFilter = new ComboBox();
        _lblAiCount = new Label();
        flowAI = new FlowLayoutPanel();
        toolbarAI = new Panel();
        _gridActionItems = new DataGridView();
        gaiCol0 = new DataGridViewTextBoxColumn();
        gaiCol1 = new DataGridViewTextBoxColumn();
        gaiCol2 = new DataGridViewTextBoxColumn();
        gaiCol3 = new DataGridViewTextBoxColumn();
        pageAI = new TabPage();
        infoLbl = new Label();
        _gridMentions = new DataGridView();
        gmCol0 = new DataGridViewTextBoxColumn();
        gmCol1 = new DataGridViewTextBoxColumn();
        gmCol2 = new DataGridViewTextBoxColumn();
        pageMentions = new TabPage();
        tabsBottom = new TabControl();
        pnlBottom = new Panel();
        _tabsMain = new TabControl();
        pageProjectNotes = new TabPage();
        _rtbProjectNotes = new RichTextBox();
        pageCareerUpdates = new TabPage();
        _rtbCareerUpdates = new RichTextBox();
        pageTrainingUpdates = new TabPage();
        _rtbTrainingUpdates = new RichTextBox();
        pageGeneralNotes = new TabPage();
        _rtbGeneralNotes = new RichTextBox();
        pageChecklist = new TabPage();
        pnlChecklistOuter = new Panel();
        _checklistContainer = new Panel();
        pnlChecklistHdr = new Panel();
        tblChecklistHdr = new TableLayoutPanel();
        lblHdrQuestion = new Label();
        lblHdrFrequency = new Label();
        lblHdrAnswer = new Label();
        pnlHeader.SuspendLayout();
        pnlFooter.SuspendLayout();
        tblRight.SuspendLayout();
        pnlRight.SuspendLayout();
        flowAI.SuspendLayout();
        toolbarAI.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridActionItems).BeginInit();
        pageAI.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_gridMentions).BeginInit();
        pageMentions.SuspendLayout();
        tabsBottom.SuspendLayout();
        pnlBottom.SuspendLayout();
        _tabsMain.SuspendLayout();
        pageProjectNotes.SuspendLayout();
        pageCareerUpdates.SuspendLayout();
        pageTrainingUpdates.SuspendLayout();
        pageGeneralNotes.SuspendLayout();
        pageChecklist.SuspendLayout();
        pnlChecklistOuter.SuspendLayout();
        pnlChecklistHdr.SuspendLayout();
        tblChecklistHdr.SuspendLayout();
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
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(30, 58, 95);
        pnlHeader.Controls.Add(_lblDate);
        pnlHeader.Controls.Add(_lblName);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(16, 0, 16, 0);
        pnlHeader.Size = new Size(1784, 78);
        pnlHeader.TabIndex = 6;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(41, 128, 185);
        btnSave.Cursor = Cursors.Hand;
        btnSave.Dock = DockStyle.Right;
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(1412, 12);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(180, 48);
        btnSave.TabIndex = 0;
        btnSave.Text = "Save Meeting";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += BtnSave_Click;
        // 
        // btnClose
        // 
        btnClose.BackColor = Color.FromArgb(127, 140, 141);
        btnClose.Cursor = Cursors.Hand;
        btnClose.DialogResult = DialogResult.OK;
        btnClose.Dock = DockStyle.Right;
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.FlatStyle = FlatStyle.Flat;
        btnClose.ForeColor = Color.White;
        btnClose.Location = new Point(1592, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(180, 48);
        btnClose.TabIndex = 1;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = false;
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.White;
        pnlFooter.Controls.Add(btnSave);
        pnlFooter.Controls.Add(btnClose);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 749);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(12);
        pnlFooter.Size = new Size(1784, 72);
        pnlFooter.TabIndex = 5;
        // 
        // pnlRightSep
        // 
        pnlRightSep.BackColor = Color.FromArgb(210, 215, 220);
        pnlRightSep.Dock = DockStyle.Right;
        pnlRightSep.Location = new Point(1343, 78);
        pnlRightSep.Name = "pnlRightSep";
        pnlRightSep.Size = new Size(1, 671);
        pnlRightSep.TabIndex = 3;
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
        // tblRight
        // 
        tblRight.ColumnCount = 1;
        tblRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblRight.Controls.Add(_lblGlowsHeader, 0, 0);
        tblRight.Controls.Add(_clbGlows, 0, 1);
        tblRight.Controls.Add(_lblGrowsHeader, 0, 2);
        tblRight.Controls.Add(_clbGrows, 0, 3);
        tblRight.Dock = DockStyle.Fill;
        tblRight.Location = new Point(6, 6);
        tblRight.Name = "tblRight";
        tblRight.RowCount = 4;
        tblRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        tblRight.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tblRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
        tblRight.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tblRight.Size = new Size(428, 659);
        tblRight.TabIndex = 0;
        // 
        // pnlRight
        // 
        pnlRight.BackColor = Color.White;
        pnlRight.Controls.Add(tblRight);
        pnlRight.Dock = DockStyle.Right;
        pnlRight.Location = new Point(1344, 78);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(6);
        pnlRight.Size = new Size(440, 671);
        pnlRight.TabIndex = 4;
        // 
        // pnlBottomSep
        // 
        pnlBottomSep.BackColor = Color.FromArgb(210, 215, 220);
        pnlBottomSep.Dock = DockStyle.Bottom;
        pnlBottomSep.Location = new Point(0, 428);
        pnlBottomSep.Name = "pnlBottomSep";
        pnlBottomSep.Size = new Size(1343, 1);
        pnlBottomSep.TabIndex = 1;
        // 
        // btnAddAI
        // 
        btnAddAI.AutoSize = true;
        btnAddAI.BackColor = Color.FromArgb(39, 174, 96);
        btnAddAI.Cursor = Cursors.Hand;
        btnAddAI.FlatAppearance.BorderSize = 0;
        btnAddAI.FlatStyle = FlatStyle.Flat;
        btnAddAI.ForeColor = Color.White;
        btnAddAI.Location = new Point(3, 3);
        btnAddAI.Name = "btnAddAI";
        btnAddAI.Padding = new Padding(12, 0, 12, 0);
        btnAddAI.Size = new Size(199, 40);
        btnAddAI.TabIndex = 0;
        btnAddAI.Text = "+ Add Action Item";
        btnAddAI.UseVisualStyleBackColor = false;
        btnAddAI.Click += BtnAddAI_Click;
        // 
        // btnComplete
        // 
        btnComplete.AutoSize = true;
        btnComplete.BackColor = Color.FromArgb(41, 128, 185);
        btnComplete.Cursor = Cursors.Hand;
        btnComplete.FlatAppearance.BorderSize = 0;
        btnComplete.FlatStyle = FlatStyle.Flat;
        btnComplete.ForeColor = Color.White;
        btnComplete.Location = new Point(211, 0);
        btnComplete.Margin = new Padding(6, 0, 0, 0);
        btnComplete.Name = "btnComplete";
        btnComplete.Padding = new Padding(12, 0, 12, 0);
        btnComplete.Size = new Size(175, 40);
        btnComplete.TabIndex = 1;
        btnComplete.Text = "Mark Complete";
        btnComplete.UseVisualStyleBackColor = false;
        btnComplete.Click += BtnComplete_Click;
        // 
        // btnDeleteAI
        // 
        btnDeleteAI.AutoSize = true;
        btnDeleteAI.BackColor = Color.FromArgb(192, 57, 43);
        btnDeleteAI.Cursor = Cursors.Hand;
        btnDeleteAI.FlatAppearance.BorderSize = 0;
        btnDeleteAI.FlatStyle = FlatStyle.Flat;
        btnDeleteAI.ForeColor = Color.White;
        btnDeleteAI.Location = new Point(392, 0);
        btnDeleteAI.Margin = new Padding(6, 0, 0, 0);
        btnDeleteAI.Name = "btnDeleteAI";
        btnDeleteAI.Padding = new Padding(12, 0, 12, 0);
        btnDeleteAI.Size = new Size(100, 40);
        btnDeleteAI.TabIndex = 2;
        btnDeleteAI.Text = "Delete";
        btnDeleteAI.UseVisualStyleBackColor = false;
        btnDeleteAI.Click += BtnDeleteAI_Click;
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
        // flowAI
        // 
        flowAI.Controls.Add(btnAddAI);
        flowAI.Controls.Add(btnComplete);
        flowAI.Controls.Add(btnDeleteAI);
        flowAI.Controls.Add(_cboAiFilter);
        flowAI.Controls.Add(_lblAiCount);
        flowAI.Dock = DockStyle.Fill;
        flowAI.Location = new Point(6, 6);
        flowAI.Name = "flowAI";
        flowAI.Size = new Size(1323, 42);
        flowAI.TabIndex = 0;
        // 
        // toolbarAI
        // 
        toolbarAI.BackColor = Color.FromArgb(248, 249, 250);
        toolbarAI.Controls.Add(flowAI);
        toolbarAI.Dock = DockStyle.Top;
        toolbarAI.Location = new Point(0, 0);
        toolbarAI.Name = "toolbarAI";
        toolbarAI.Padding = new Padding(6);
        toolbarAI.Size = new Size(1335, 54);
        toolbarAI.TabIndex = 1;
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
        _gridActionItems.Columns.AddRange(new DataGridViewColumn[] { gaiCol0, gaiCol1, gaiCol2, gaiCol3 });
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
        // gaiCol0
        // 
        gaiCol0.HeaderText = "Added";
        gaiCol0.Name = "gaiCol0";
        gaiCol0.ReadOnly = true;
        gaiCol0.Width = 120;
        // 
        // gaiCol1
        // 
        gaiCol1.HeaderText = "Assigned To";
        gaiCol1.Name = "gaiCol1";
        gaiCol1.ReadOnly = true;
        gaiCol1.Width = 140;
        // 
        // gaiCol2
        // 
        gaiCol2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        gaiCol2.HeaderText = "Description";
        gaiCol2.Name = "gaiCol2";
        gaiCol2.ReadOnly = true;
        // 
        // gaiCol3
        // 
        gaiCol3.HeaderText = "Due Date";
        gaiCol3.Name = "gaiCol3";
        gaiCol3.ReadOnly = true;
        gaiCol3.Width = 135;
        // 
        // pageAI
        // 
        pageAI.Controls.Add(_gridActionItems);
        pageAI.Controls.Add(toolbarAI);
        pageAI.Location = new Point(4, 34);
        pageAI.Name = "pageAI";
        pageAI.Size = new Size(1335, 282);
        pageAI.TabIndex = 0;
        pageAI.Text = "Action Items";
        // 
        // infoLbl
        // 
        infoLbl.Dock = DockStyle.Top;
        infoLbl.Font = new Font("Segoe UI", 13F, FontStyle.Italic);
        infoLbl.ForeColor = Color.FromArgb(100, 100, 100);
        infoLbl.Location = new Point(0, 0);
        infoLbl.Name = "infoLbl";
        infoLbl.Padding = new Padding(6, 0, 0, 0);
        infoLbl.Size = new Size(192, 36);
        infoLbl.TabIndex = 1;
        infoLbl.Text = "Open action items from other meetings that tag this person with @";
        infoLbl.TextAlign = ContentAlignment.MiddleLeft;
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
        _gridMentions.Columns.AddRange(new DataGridViewColumn[] { gmCol0, gmCol1, gmCol2 });
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
        // gmCol0
        // 
        gmCol0.HeaderText = "Their Meeting Person";
        gmCol0.Name = "gmCol0";
        gmCol0.ReadOnly = true;
        gmCol0.Width = 240;
        // 
        // gmCol1
        // 
        gmCol1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        gmCol1.HeaderText = "Description";
        gmCol1.Name = "gmCol1";
        gmCol1.ReadOnly = true;
        // 
        // gmCol2
        // 
        gmCol2.HeaderText = "Due Date";
        gmCol2.Name = "gmCol2";
        gmCol2.ReadOnly = true;
        gmCol2.Width = 135;
        // 
        // pageMentions
        // 
        pageMentions.Controls.Add(_gridMentions);
        pageMentions.Controls.Add(infoLbl);
        pageMentions.Location = new Point(4, 34);
        pageMentions.Name = "pageMentions";
        pageMentions.Size = new Size(192, 282);
        pageMentions.TabIndex = 1;
        pageMentions.Text = "Mentions";
        // 
        // tabsBottom
        // 
        tabsBottom.Controls.Add(pageAI);
        tabsBottom.Controls.Add(pageMentions);
        tabsBottom.Dock = DockStyle.Fill;
        tabsBottom.Font = new Font("Segoe UI", 14F);
        tabsBottom.Location = new Point(0, 0);
        tabsBottom.Name = "tabsBottom";
        tabsBottom.SelectedIndex = 0;
        tabsBottom.Size = new Size(1343, 320);
        tabsBottom.TabIndex = 0;
        // 
        // pnlBottom
        // 
        pnlBottom.BackColor = Color.White;
        pnlBottom.Controls.Add(tabsBottom);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 429);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(1343, 320);
        pnlBottom.TabIndex = 2;
        // 
        // _tabsMain
        // 
        _tabsMain.Controls.Add(pageProjectNotes);
        _tabsMain.Controls.Add(pageCareerUpdates);
        _tabsMain.Controls.Add(pageTrainingUpdates);
        _tabsMain.Controls.Add(pageGeneralNotes);
        _tabsMain.Controls.Add(pageChecklist);
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
        // pageProjectNotes
        // 
        pageProjectNotes.BackColor = Color.White;
        pageProjectNotes.Controls.Add(_rtbProjectNotes);
        pageProjectNotes.Location = new Point(4, 44);
        pageProjectNotes.Name = "pageProjectNotes";
        pageProjectNotes.Size = new Size(1335, 302);
        pageProjectNotes.TabIndex = 0;
        pageProjectNotes.Text = "Project Notes";
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
        // pageCareerUpdates
        // 
        pageCareerUpdates.BackColor = Color.White;
        pageCareerUpdates.Controls.Add(_rtbCareerUpdates);
        pageCareerUpdates.Location = new Point(4, 44);
        pageCareerUpdates.Name = "pageCareerUpdates";
        pageCareerUpdates.Size = new Size(192, 52);
        pageCareerUpdates.TabIndex = 1;
        pageCareerUpdates.Text = "Career Updates";
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
        // pageTrainingUpdates
        // 
        pageTrainingUpdates.BackColor = Color.White;
        pageTrainingUpdates.Controls.Add(_rtbTrainingUpdates);
        pageTrainingUpdates.Location = new Point(4, 44);
        pageTrainingUpdates.Name = "pageTrainingUpdates";
        pageTrainingUpdates.Size = new Size(192, 52);
        pageTrainingUpdates.TabIndex = 2;
        pageTrainingUpdates.Text = "Training Updates";
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
        // pageGeneralNotes
        // 
        pageGeneralNotes.BackColor = Color.White;
        pageGeneralNotes.Controls.Add(_rtbGeneralNotes);
        pageGeneralNotes.Location = new Point(4, 44);
        pageGeneralNotes.Name = "pageGeneralNotes";
        pageGeneralNotes.Size = new Size(192, 52);
        pageGeneralNotes.TabIndex = 3;
        pageGeneralNotes.Text = "General Notes";
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
        // pageChecklist
        // 
        pageChecklist.BackColor = Color.White;
        pageChecklist.Controls.Add(pnlChecklistOuter);
        pageChecklist.Location = new Point(4, 44);
        pageChecklist.Name = "pageChecklist";
        pageChecklist.Size = new Size(192, 52);
        pageChecklist.TabIndex = 4;
        pageChecklist.Text = "Checklist";
        // 
        // pnlChecklistOuter
        // 
        pnlChecklistOuter.BackColor = Color.White;
        pnlChecklistOuter.Controls.Add(_checklistContainer);
        pnlChecklistOuter.Controls.Add(pnlChecklistHdr);
        pnlChecklistOuter.Dock = DockStyle.Fill;
        pnlChecklistOuter.Location = new Point(0, 0);
        pnlChecklistOuter.Name = "pnlChecklistOuter";
        pnlChecklistOuter.Size = new Size(192, 52);
        pnlChecklistOuter.TabIndex = 0;
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
        // pnlChecklistHdr
        // 
        pnlChecklistHdr.BackColor = Color.FromArgb(52, 73, 94);
        pnlChecklistHdr.Controls.Add(tblChecklistHdr);
        pnlChecklistHdr.Dock = DockStyle.Top;
        pnlChecklistHdr.Location = new Point(0, 0);
        pnlChecklistHdr.Name = "pnlChecklistHdr";
        pnlChecklistHdr.Size = new Size(192, 40);
        pnlChecklistHdr.TabIndex = 1;
        // 
        // tblChecklistHdr
        // 
        tblChecklistHdr.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblChecklistHdr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        tblChecklistHdr.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
        tblChecklistHdr.Controls.Add(lblHdrQuestion, 0, 0);
        tblChecklistHdr.Controls.Add(lblHdrFrequency, 1, 0);
        tblChecklistHdr.Controls.Add(lblHdrAnswer, 2, 0);
        tblChecklistHdr.Dock = DockStyle.Fill;
        tblChecklistHdr.Location = new Point(0, 0);
        tblChecklistHdr.Name = "tblChecklistHdr";
        tblChecklistHdr.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblChecklistHdr.Size = new Size(192, 40);
        tblChecklistHdr.TabIndex = 0;
        // 
        // lblHdrQuestion
        // 
        lblHdrQuestion.Dock = DockStyle.Fill;
        lblHdrQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblHdrQuestion.ForeColor = Color.White;
        lblHdrQuestion.Location = new Point(3, 0);
        lblHdrQuestion.Name = "lblHdrQuestion";
        lblHdrQuestion.Size = new Size(1, 40);
        lblHdrQuestion.TabIndex = 0;
        lblHdrQuestion.Text = "Question";
        lblHdrQuestion.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHdrFrequency
        // 
        lblHdrFrequency.Dock = DockStyle.Fill;
        lblHdrFrequency.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblHdrFrequency.ForeColor = Color.White;
        lblHdrFrequency.Location = new Point(-195, 0);
        lblHdrFrequency.Name = "lblHdrFrequency";
        lblHdrFrequency.Size = new Size(124, 40);
        lblHdrFrequency.TabIndex = 1;
        lblHdrFrequency.Text = "Frequency";
        lblHdrFrequency.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHdrAnswer
        // 
        lblHdrAnswer.Dock = DockStyle.Fill;
        lblHdrAnswer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblHdrAnswer.ForeColor = Color.White;
        lblHdrAnswer.Location = new Point(-65, 0);
        lblHdrAnswer.Name = "lblHdrAnswer";
        lblHdrAnswer.Size = new Size(254, 40);
        lblHdrAnswer.TabIndex = 2;
        lblHdrAnswer.Text = "Answer";
        lblHdrAnswer.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MeetingForm
        // 
        BackColor = Color.FromArgb(245, 247, 250);
        ClientSize = new Size(1784, 821);
        Controls.Add(_tabsMain);
        Controls.Add(pnlBottomSep);
        Controls.Add(pnlBottom);
        Controls.Add(pnlRightSep);
        Controls.Add(pnlRight);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 14F);
        MinimumSize = new Size(1300, 680);
        Name = "MeetingForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "1:1 Meeting";
        pnlHeader.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        tblRight.ResumeLayout(false);
        pnlRight.ResumeLayout(false);
        flowAI.ResumeLayout(false);
        flowAI.PerformLayout();
        toolbarAI.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_gridActionItems).EndInit();
        pageAI.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_gridMentions).EndInit();
        pageMentions.ResumeLayout(false);
        tabsBottom.ResumeLayout(false);
        pnlBottom.ResumeLayout(false);
        _tabsMain.ResumeLayout(false);
        pageProjectNotes.ResumeLayout(false);
        pageCareerUpdates.ResumeLayout(false);
        pageTrainingUpdates.ResumeLayout(false);
        pageGeneralNotes.ResumeLayout(false);
        pageChecklist.ResumeLayout(false);
        pnlChecklistOuter.ResumeLayout(false);
        pnlChecklistHdr.ResumeLayout(false);
        tblChecklistHdr.ResumeLayout(false);
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
    private Panel pnlHeader;
    private Button btnSave;
    private Button btnClose;
    private Panel pnlFooter;
    private Panel pnlRightSep;
    private TableLayoutPanel tblRight;
    private Panel pnlRight;
    private Panel pnlBottomSep;
    private Button btnAddAI;
    private Button btnComplete;
    private Button btnDeleteAI;
    private FlowLayoutPanel flowAI;
    private Panel toolbarAI;
    private DataGridViewTextBoxColumn gaiCol0;
    private DataGridViewTextBoxColumn gaiCol1;
    private DataGridViewTextBoxColumn gaiCol2;
    private DataGridViewTextBoxColumn gaiCol3;
    private TabPage pageAI;
    private Label infoLbl;
    private DataGridViewTextBoxColumn gmCol0;
    private DataGridViewTextBoxColumn gmCol1;
    private DataGridViewTextBoxColumn gmCol2;
    private TabPage pageMentions;
    private TabControl tabsBottom;
    private Panel pnlBottom;
    private TabPage pageProjectNotes;
    private TabPage pageCareerUpdates;
    private TabPage pageTrainingUpdates;
    private TabPage pageGeneralNotes;
    private TabPage pageChecklist;
    private Panel pnlChecklistOuter;
    private Panel pnlChecklistHdr;
    private TableLayoutPanel tblChecklistHdr;
    private Label lblHdrQuestion;
    private Label lblHdrFrequency;
    private Label lblHdrAnswer;
}
