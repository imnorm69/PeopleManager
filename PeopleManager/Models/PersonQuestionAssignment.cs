namespace PeopleManager.Models;

public class PersonQuestionAssignment
{
    public int AssignmentId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public int QuestionId { get; set; }
    public ChecklistQuestion Question { get; set; } = null!;
    public CheckFrequency Frequency { get; set; }   // set per-person at assignment time
    public DateTime AssignedDate { get; set; }
}
