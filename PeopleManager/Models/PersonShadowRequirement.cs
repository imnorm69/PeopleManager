namespace PeopleManager.Models;

/// <summary>
/// The shadow quota points a specific person is required to accumulate in a specific
/// calendar-year quarter. Populated on demand the first time a shadow session is logged
/// for that person in a quarter that doesn't have an entry yet.
/// </summary>
public class PersonShadowRequirement
{
    /// <summary>Gets or sets the primary key.</summary>
    public int PersonShadowRequirementId { get; set; }

    /// <summary>Gets or sets the person this requirement applies to.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the calendar year.</summary>
    public int Year { get; set; }

    /// <summary>Gets or sets the calendar-year quarter (1-4).</summary>
    public int Quarter { get; set; }

    /// <summary>Gets or sets the points required for this person in this quarter.</summary>
    public decimal RequiredPoints { get; set; }
}
