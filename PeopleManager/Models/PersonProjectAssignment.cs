namespace PeopleManager.Models;

public class PersonProjectAssignment
{
    public int AssignmentId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public int ProjectTeamId { get; set; }
    public ProjectTeam ProjectTeam { get; set; } = null!;

    public DateTime AssignedDate { get; set; }   // when the record was created
    public DateTime EffectiveDate { get; set; }  // when the assignment takes effect
    public DateTime? RemovedDate { get; set; }   // null = still active
}
