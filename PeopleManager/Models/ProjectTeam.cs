using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

public class ProjectTeam
{
    public int ProjectTeamId { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = "";

    public ICollection<PersonProjectAssignment> Assignments { get; set; } = new List<PersonProjectAssignment>();
}
