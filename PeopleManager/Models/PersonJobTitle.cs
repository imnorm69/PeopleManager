using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

public class PersonJobTitle
{
    public int PersonJobTitleId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    [Required, MaxLength(200)]
    public string Title { get; set; } = "";

    public DateTime EffectiveDate { get; set; }
}
