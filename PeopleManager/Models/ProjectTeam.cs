using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

/// <summary>
/// Represents a project team or working group that people can be assigned to.
/// </summary>
public class ProjectTeam
{
    /// <summary>Gets or sets the primary key.</summary>
    public int ProjectTeamId { get; set; }

    /// <summary>Gets or sets the team or project name.</summary>
    [Required, MaxLength(200)]
    public string Name { get; set; } = "";

    /// <summary>Gets all person assignments (current and historical) for this team.</summary>
    public ICollection<PersonProjectAssignment> Assignments { get; set; } = new List<PersonProjectAssignment>();
}
