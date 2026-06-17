namespace PeopleManager.Models;

/// <summary>
/// Represents a single piece of positive feedback (Glow) or constructive feedback (Grow)
/// recorded for a person, optionally communicated during a 1:1 meeting.
/// </summary>
public class GlowGrow
{
    /// <summary>Gets or sets the primary key.</summary>
    public int GlowGrowId { get; set; }

    /// <summary>Gets or sets the person this feedback is about.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets whether this is a Glow (positive) or Grow (constructive) item.</summary>
    public GlowGrowType Type { get; set; }

    /// <summary>Gets or sets the full text of the feedback.</summary>
    public string Note { get; set; } = "";

    /// <summary>Gets or sets where the feedback originated (e.g., "Email from stakeholder").</summary>
    public string? Source { get; set; }

    /// <summary>Gets or sets the date the feedback was recorded.</summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the date this feedback was communicated to the employee.
    /// Null means it has not yet been communicated.
    /// </summary>
    public DateTime? CommunicatedDate { get; set; }
}
