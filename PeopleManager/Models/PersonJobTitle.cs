using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

/// <summary>
/// Records a job title held by a person from a given effective date.
/// The current title is the one with the most recent <see cref="EffectiveDate"/>.
/// </summary>
public class PersonJobTitle
{
    /// <summary>Gets or sets the primary key.</summary>
    public int PersonJobTitleId { get; set; }

    /// <summary>Gets or sets the person who holds this title.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the job title text.</summary>
    [Required, MaxLength(200)]
    public string Title { get; set; } = "";

    /// <summary>Gets or sets the date from which this title is effective.</summary>
    public DateTime EffectiveDate { get; set; }
}
