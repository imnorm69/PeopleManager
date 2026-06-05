namespace PeopleManager.Models;

public class ActionItem
{
    public int ActionItemId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public int CreatedInMeetingId { get; set; }
    public Meeting CreatedInMeeting { get; set; } = null!;

    public string Description { get; set; } = "";
    public ActionItemAssignee AssignedTo { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }

    public bool IsComplete { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string? CompletionNotes { get; set; }

    public int? CompletedInMeetingId { get; set; }
    public Meeting? CompletedInMeeting { get; set; }
}
