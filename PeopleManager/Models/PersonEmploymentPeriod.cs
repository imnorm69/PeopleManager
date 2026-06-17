namespace PeopleManager.Models;

/// <summary>
/// Represents a continuous period of employment for a person,
/// bounded by a hire date and an optional separation date.
/// Re-hired employees have multiple periods.
/// </summary>
public class PersonEmploymentPeriod
{
    /// <summary>Gets or sets the primary key.</summary>
    public int PeriodId { get; set; }

    /// <summary>Gets or sets the person this period belongs to.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the start date of this employment period.</summary>
    public DateTime HireDate { get; set; }

    /// <summary>Gets or sets the end date of this employment period. Null means currently employed.</summary>
    public DateTime? SeparationDate { get; set; }

    /// <summary>Gets or sets the reason for separation, if applicable.</summary>
    public SeparationReason? SeparationReason { get; set; }

    /// <summary>Gets or sets additional notes recorded at the time of separation.</summary>
    public string? SeparationNotes { get; set; }

    /// <summary>Gets whether this period is currently active (no separation date set).</summary>
    public bool IsActive => SeparationDate == null;
}
