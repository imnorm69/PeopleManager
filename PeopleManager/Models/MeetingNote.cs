namespace PeopleManager.Models;

/// <summary>
/// Represents a single free-text note section recorded during a 1:1 meeting,
/// categorised by topic (e.g., Project Notes, Career Updates).
/// One record exists per category per meeting when notes are present.
/// </summary>
public class MeetingNote
{
    /// <summary>Gets or sets the primary key.</summary>
    public int MeetingNoteId { get; set; }

    /// <summary>Gets or sets the meeting these notes belong to.</summary>
    public int MeetingId { get; set; }

    /// <summary>Gets or sets the meeting navigation property.</summary>
    public Meeting Meeting { get; set; } = null!;

    /// <summary>Gets or sets which note category this record represents.</summary>
    public MeetingNoteCategory Category { get; set; }

    /// <summary>Gets or sets the full note text for this category.</summary>
    public string NoteText { get; set; } = "";
}
