using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

public class ChecklistQuestion
{
    public int QuestionId { get; set; }

    [Required, MaxLength(500)]
    public string Description { get; set; } = "";

    public ChecklistValueType ValueType { get; set; }
    public int SortOrder { get; set; }

    public ICollection<PersonQuestionAssignment> Assignments { get; set; } = new List<PersonQuestionAssignment>();
    public ICollection<ChecklistItemEvaluation>  Evaluations { get; set; } = new List<ChecklistItemEvaluation>();
}
