namespace PeopleManager.Forms;

partial class GlowGrowDetailForm
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

        // Banner
        this._pnlBanner = new System.Windows.Forms.Panel();
        this._lblType = new System.Windows.Forms.Label();

        this._pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
        this._pnlBanner.Height = 54;
        this._pnlBanner.SuspendLayout();

        this._lblType.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblType.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
        this._lblType.ForeColor = System.Drawing.Color.White;
        this._lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this._pnlBanner.Controls.Add(this._lblType);
        this._pnlBanner.ResumeLayout(false);

        // Main layout
        var layout = new System.Windows.Forms.TableLayoutPanel();
        layout.Dock = System.Windows.Forms.DockStyle.Fill;
        layout.Padding = new System.Windows.Forms.Padding(16);
        layout.ColumnCount = 2;
        layout.RowCount = 6;
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195));
        layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100));
        layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60));
        layout.SuspendLayout();

        // Row 0 — Person
        var lblPersonLabel = new System.Windows.Forms.Label();
        lblPersonLabel.Text = "Person:";
        lblPersonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lblPersonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        lblPersonLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);

        this._lblPerson = new System.Windows.Forms.Label();
        this._lblPerson.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this._lblPerson.AutoEllipsis = true;

        layout.Controls.Add(lblPersonLabel, 0, 0);
        layout.Controls.Add(this._lblPerson, 1, 0);

        // Row 1 — Recorded
        var lblRecordedLabel = new System.Windows.Forms.Label();
        lblRecordedLabel.Text = "Recorded:";
        lblRecordedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lblRecordedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        lblRecordedLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);

        this._lblRecorded = new System.Windows.Forms.Label();
        this._lblRecorded.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblRecorded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this._lblRecorded.AutoEllipsis = true;

        layout.Controls.Add(lblRecordedLabel, 0, 1);
        layout.Controls.Add(this._lblRecorded, 1, 1);

        // Row 2 — Source
        var lblSourceLabel = new System.Windows.Forms.Label();
        lblSourceLabel.Text = "Source:";
        lblSourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lblSourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        lblSourceLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);

        this._lblSource = new System.Windows.Forms.Label();
        this._lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this._lblSource.AutoEllipsis = true;

        layout.Controls.Add(lblSourceLabel, 0, 2);
        layout.Controls.Add(this._lblSource, 1, 2);

        // Row 3 — Communicated
        var lblCommunicatedLabel = new System.Windows.Forms.Label();
        lblCommunicatedLabel.Text = "Communicated:";
        lblCommunicatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lblCommunicatedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        lblCommunicatedLabel.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);

        this._lblCommunicated = new System.Windows.Forms.Label();
        this._lblCommunicated.Dock = System.Windows.Forms.DockStyle.Fill;
        this._lblCommunicated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this._lblCommunicated.AutoEllipsis = true;

        layout.Controls.Add(lblCommunicatedLabel, 0, 3);
        layout.Controls.Add(this._lblCommunicated, 1, 3);

        // Row 4 — Note
        var lblNoteLabel = new System.Windows.Forms.Label();
        lblNoteLabel.Text = "Note:";
        lblNoteLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
        lblNoteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        lblNoteLabel.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);

        this._rtbNote = new System.Windows.Forms.RichTextBox();
        this._rtbNote.Dock = System.Windows.Forms.DockStyle.Fill;
        this._rtbNote.ReadOnly = true;
        this._rtbNote.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
        this._rtbNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this._rtbNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        this._rtbNote.Font = new System.Drawing.Font("Segoe UI", 14f);

        layout.Controls.Add(lblNoteLabel, 0, 4);
        layout.Controls.Add(this._rtbNote, 1, 4);

        // Row 5 — Close button
        var btnRow = new System.Windows.Forms.Panel();
        btnRow.Dock = System.Windows.Forms.DockStyle.Fill;
        layout.SetColumnSpan(btnRow, 2);

        var btnClose = new System.Windows.Forms.Button();
        btnClose.Text = "Close";
        btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
        btnClose.Width = 120;
        btnClose.Dock = System.Windows.Forms.DockStyle.Right;
        btnRow.Controls.Add(btnClose);

        layout.Controls.Add(btnRow, 0, 5);
        layout.ResumeLayout(false);

        this.AcceptButton = btnClose;

        // Form
        this.Controls.Add(layout);
        this.Controls.Add(this._pnlBanner);

        this.Text = "Glow/Grow Detail";
        this.Size = new System.Drawing.Size(760, 570);
        this.MinimumSize = new System.Drawing.Size(620, 450);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.BackColor = System.Drawing.Color.White;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Panel _pnlBanner = null!;
    private System.Windows.Forms.Label _lblType = null!;
    private System.Windows.Forms.Label _lblPerson = null!;
    private System.Windows.Forms.Label _lblRecorded = null!;
    private System.Windows.Forms.Label _lblSource = null!;
    private System.Windows.Forms.Label _lblCommunicated = null!;
    private System.Windows.Forms.RichTextBox _rtbNote = null!;
}
