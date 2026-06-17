namespace PeopleManager.Models;

/// <summary>
/// Records an answer to a checklist question for a specific person on a specific date,
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

    /// <summary>Gets or sets the question that was answered.</summary>
    public int QuestionId { get; set; }

    /// <summary>Gets or sets the question navigation property.</summary>
    public ChecklistQuestion Question { get; set; } = null!;

    /// <summary>
    /// Gets or sets the meeting during which this answer was recorded.
    /// Null if captured outside a meeting context. Set to null on meeting deletion.
    /// </summary>
    public int? MeetingId { get; set; }

    /// <summary>Gets or sets the meeting navigation property.</summary>
    public Meeting? Meeting { get; set; }

    /// <summary>Gets or sets the date the evaluation was recorded (matches meeting date when captured in a meeting).</summary>
    public DateTime EvaluatedDate { get; set; }

    /// <summary>Gets or sets the answer value, serialised as a string regardless of the question's value type.</summary>
    public string? Value { get; set; }

    /// <summary>Gets or sets optional supplemental notes for this answer.</summary>
    public string? Notes { get; set; }
}
