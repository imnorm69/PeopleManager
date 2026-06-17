namespace PeopleManager.Models;

/// <summary>
/// Represents a task or follow-up item created during or associated with a 1:1 meeting.
/// </summary>
public class ActionItem
{
    /// <summary>Gets or sets the primary key.</summary>
    public int ActionItemId { get; set; }

    /// <summary>Gets or sets the person this action item belongs to.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the meeting in which this action item was created.</summary>
    public int CreatedInMeetingId { get; set; }

    /// <summary>Gets or sets the meeting navigation property for creation.</summary>
    public Meeting CreatedInMeeting { get; set; } = null!;

    /// <summary>Gets or sets the text description of the action required.</summary>
    public string Description { get; set; } = "";

    /// <summary>Gets or sets whether this item is assigned to the manager or to the person.</summary>
    public ActionItemAssignee AssignedTo { get; set; }

    /// <summary>Gets or sets the date the action item was created (matches the meeting date).</summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>Gets or sets the date by which the action should be completed.</summary>
    public DateTime DueDate { get; set; }

    /// <summary>Gets or sets whether this action item has been completed.</summary>
    public bool IsComplete { get; set; }

    /// <summary>Gets or sets the date the action item was marked complete.</summary>
    public DateTime? CompletedDate { get; set; }

    /// <summary>Gets or sets optional notes recorded when the item was marked complete.</summary>
    public string? CompletionNotes { get; set; }

    /// <summary>Gets or sets the meeting in which this item was completed, if applicable.</summary>
    public int? CompletedInMeetingId { get; set; }

    /// <summary>Gets or sets the meeting navigation property for completion.</summary>
    public Meeting? CompletedInMeeting { get; set; }
}
