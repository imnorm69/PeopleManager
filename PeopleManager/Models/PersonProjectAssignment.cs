namespace PeopleManager.Models;

/// <summary>
/// Records a person's assignment to a project team, including when the record
/// was created, when the assignment became effective, and when it ended.
/// </summary>
public class PersonProjectAssignment
{
    /// <summary>Gets or sets the primary key.</summary>
    public int AssignmentId { get; set; }

    /// <summary>Gets or sets the person assigned to the team.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the person navigation property.</summary>
    public Person Person { get; set; } = null!;

    /// <summary>Gets or sets the team or project being assigned to.</summary>
    public int ProjectTeamId { get; set; }

    /// <summary>Gets or sets the project team navigation property.</summary>
    public ProjectTeam ProjectTeam { get; set; } = null!;

    /// <summary>Gets or sets the date the assignment record was created in the system.</summary>
    public DateTime AssignedDate { get; set; }

    /// <summary>Gets or sets the date from which the assignment is operationally effective.</summary>
    public DateTime EffectiveDate { get; set; }

    /// <summary>Gets or sets the date the assignment ended. Null means still active.</summary>
    public DateTime? RemovedDate { get; set; }
}
