using PeopleManager.Models;

namespace PeopleManager.Forms;

/// <summary>
/// Read-only detail view for a single glow or grow item, showing all fields including the full note text.
/// </summary>
public partial class GlowGrowDetailForm : Form
{
    /// <summary>Initialises and builds the detail view for the given glow/grow item.</summary>
    /// <param name="item">The glow or grow record to display.</param>
    public GlowGrowDetailForm() : this(new GlowGrow { Note = "" }) { }

    public GlowGrowDetailForm(GlowGrow item)
    {
        InitializeComponent();
        PopulateFromItem(item);
    }

    private void PopulateFromItem(GlowGrow item)
    {
        Text = item.Type == GlowGrowType.Glow ? "Glow Detail" : "Grow Detail";
        var typeColor = item.Type == GlowGrowType.Glow
            ? Color.FromArgb(39, 174, 96)
            : Color.FromArgb(192, 57, 43);
        _pnlBanner.BackColor = typeColor;
        _lblType.Text = item.Type == GlowGrowType.Glow ? "GLOW" : "GROW";
        _lblPerson.Text = item.Person?.FullName ?? "";
        _lblRecorded.Text = item.CreatedDate.ToLongDateString();
        _lblSource.Text = item.Source ?? "—";
        _lblCommunicated.Text = item.CommunicatedDate.HasValue
            ? item.CommunicatedDate.Value.ToLongDateString() : "Not yet communicated";
        _rtbNote.Text = item.Note;
    }
}
