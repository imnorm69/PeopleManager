using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

/// <summary>
/// Represents a reusable checklist item that can be assigned to people
/// and answered during 1:1 meetings.
/// </summary>
public class ChecklistItem
{
    /// <summary>Gets or sets the primary key.</summary>
    public int ItemId { get; set; }

    /// <summary>Gets or sets the text of the item shown during meetings.</summary>
    [Required, MaxLength(500)]
    public string Description { get; set; } = "";

    /// <summary>Gets or sets the expected answer type (Yes/No, Integer, Text, Percentage, or Date).</summary>
    public ChecklistValueType ValueType { get; set; }

    /// <summary>Gets or sets the display order relative to other items.</summary>
    public int SortOrder { get; set; }

    /// <summary>Gets all person assignments for this item.</summary>
    public ICollection<PersonItemAssignment> Assignments { get; set; } = new List<PersonItemAssignment>();

    /// <summary>Gets all recorded evaluation answers for this item across all people and meetings.</summary>
    public ICollection<ChecklistItemEvaluation> Evaluations { get; set; } = new List<ChecklistItemEvaluation>();
}
