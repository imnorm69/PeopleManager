namespace PeopleManager.Models;

/// <summary>
/// Represents the assignment of a checklist item to a specific person,
/// including the frequency at which it should be reviewed.
/// </summary>
public class PersonItemAssignment
{
    /// <summary>Gets or sets the primary key.</summary>
    public int AssignmentId { get; set; }

    /// <summary>Gets or sets the person this item is assigned to.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the item being assigned.</summary>
    public int ItemId { get; set; }

    /// <summary>Gets or sets the item navigation property.</summary>
    public ChecklistItem Item { get; set; } = null!;

    /// <summary>Gets or sets how often this item should be reviewed for this person.</summary>
    public CheckFrequency Frequency { get; set; }

    /// <summary>Gets or sets the date the item was assigned to this person.</summary>
    public DateTime AssignedDate { get; set; }
}
