namespace PeopleManager.Models;

/// <summary>
/// Represents a single 1:1 meeting between the manager and a direct report.
/// </summary>
public class Meeting
{
    /// <summary>Gets or sets the primary key.</summary>
    public int MeetingId { get; set; }

    /// <summary>Gets or sets the person (direct report) this meeting is with.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the date the meeting took place.</summary>
    public DateTime MeetingDate { get; set; }

    /// <summary>Gets the free-text notes recorded across all categories during this meeting.</summary>
    public ICollection<MeetingNote> Notes { get; set; } = new List<MeetingNote>();

    /// <summary>Gets all action items that were created during this meeting.</summary>
    public ICollection<ActionItem> CreatedActionItems { get; set; } = new List<ActionItem>();
}
