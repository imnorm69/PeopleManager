namespace PeopleManager.Models;

/// <summary>
/// Records an answer to a checklist item for a specific person on a specific date,
/// optionally linked to the meeting during which it was captured.
/// </summary>
public class ChecklistItemEvaluation
{
    /// <summary>Gets or sets the primary key.</summary>
    public int EvaluationId { get; set; }

    /// <summary>Gets or sets the person this answer relates to.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the item that was answered.</summary>
    public int ItemId { get; set; }

    /// <summary>Gets or sets the item navigation property.</summary>
    public ChecklistItem Item { get; set; } = null!;

    /// <summary>
    /// Gets or sets the meeting during which this answer was recorded.
    /// Null if captured outside a meeting context. Set to null on meeting deletion.
    /// </summary>
    public int? MeetingId { get; set; }

    /// <summary>Gets or sets the meeting navigation property.</summary>
    public Meeting? Meeting { get; set; }

    /// <summary>Gets or sets the date the evaluation was recorded (matches meeting date when captured in a meeting).</summary>
    public DateTime EvaluatedDate { get; set; }

    /// <summary>Gets or sets the actual date and time this answer was saved, independent of <see cref="EvaluatedDate"/>.</summary>
    public DateTime RecordedAt { get; set; }

    /// <summary>Gets or sets the answer value, serialised as a string regardless of the item's value type.</summary>
    public string? Value { get; set; }

    /// <summary>Gets or sets optional supplemental notes for this answer.</summary>
    public string? Notes { get; set; }
}
