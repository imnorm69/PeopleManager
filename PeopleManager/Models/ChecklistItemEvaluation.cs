namespace PeopleManager.Models;

public class ChecklistItemEvaluation
{
    public int EvaluationId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public int QuestionId { get; set; }
    public ChecklistQuestion Question { get; set; } = null!;
    public int? MeetingId { get; set; }
    public Meeting? Meeting { get; set; }
    public DateTime EvaluatedDate { get; set; }
    public string? Value { get; set; }
    public string? Notes { get; set; }
}
