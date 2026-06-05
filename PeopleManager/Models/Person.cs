using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

public class Person
{
    public int PersonId { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; } = "";

    [Required, MaxLength(100)]
    public string LastName { get; set; } = "";

    public DateTime StartDate { get; set; }   // original (first) hire date
    public bool IsActive { get; set; } = true;

    public string FullName => $"{FirstName} {LastName}";
    public string DisplayName => $"{LastName}, {FirstName}";

    public ICollection<PersonEmploymentPeriod> EmploymentPeriods { get; set; } = new List<PersonEmploymentPeriod>();
    public ICollection<PersonJobTitle> JobTitles { get; set; } = new List<PersonJobTitle>();
    public ICollection<PersonProjectAssignment> ProjectAssignments { get; set; } = new List<PersonProjectAssignment>();
    public ICollection<GlowGrow> GlowsGrows { get; set; } = new List<GlowGrow>();
    public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    public ICollection<ActionItem> ActionItems { get; set; } = new List<ActionItem>();
    public ICollection<PersonQuestionAssignment> QuestionAssignments { get; set; } = new List<PersonQuestionAssignment>();
    public ICollection<ChecklistItemEvaluation>  ChecklistEvaluations { get; set; } = new List<ChecklistItemEvaluation>();
}
