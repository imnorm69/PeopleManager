using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

/// <summary>
/// Represents a reusable checklist question that can be assigned to people
/// and answered during 1:1 meetings.
/// </summary>
public class ChecklistQuestion
{
    /// <summary>Gets or sets the primary key.</summary>
    public int QuestionId { get; set; }

    /// <summary>Gets or sets the text of the question shown during meetings.</summary>
    [Required, MaxLength(500)]
    public string Description { get; set; } = "";

    /// <summary>Gets or sets the expected answer type (Yes/No, Integer, Text, Percentage, or Date).</summary>
    public ChecklistValueType ValueType { get; set; }

    /// <summary>Gets or sets the display order relative to other questions.</summary>
    public int SortOrder { get; set; }

    /// <summary>Gets all person assignments for this question.</summary>
    public ICollection<PersonQuestionAssignment> Assignments { get; set; } = new List<PersonQuestionAssignment>();

    /// <summary>Gets all recorded evaluation answers for this question across all people and meetings.</summary>
    public ICollection<ChecklistItemEvaluation> Evaluations { get; set; } = new List<ChecklistItemEvaluation>();
}
