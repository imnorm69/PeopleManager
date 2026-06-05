namespace PeopleManager.Models;

public class PersonEmploymentPeriod
{
    public int PeriodId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public DateTime HireDate { get; set; }
    public DateTime? SeparationDate { get; set; }
    public SeparationReason? SeparationReason { get; set; }
    public string? SeparationNotes { get; set; }

    public bool IsActive => SeparationDate == null;
}
