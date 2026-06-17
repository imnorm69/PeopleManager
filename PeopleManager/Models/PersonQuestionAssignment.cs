namespace PeopleManager.Models;

/// <summary>
/// Represents the assignment of a checklist question to a specific person,
/// including the frequency at which it should be reviewed.
/// </summary>
public class PersonQuestionAssignment
{
    /// <summary>Gets or sets the primary key.</summary>
    public int AssignmentId { get; set; }

    /// <summary>Gets or sets the person this question is assigned to.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the question being assigned.</summary>
    public int QuestionId { get; set; }

    /// <summary>Gets or sets the question navigation property.</summary>
    public ChecklistQuestion Question { get; set; } = null!;

    /// <summary>Gets or sets how often this question should be reviewed for this person.</summary>
    public CheckFrequency Frequency { get; set; }

    /// <summary>Gets or sets the date the question was assigned to this person.</summary>
    public DateTime AssignedDate { get; set; }
}
