namespace PeopleManager.Models;

public class Meeting
{
    public int MeetingId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public DateTime MeetingDate { get; set; }

    public ICollection<MeetingNote> Notes { get; set; } = new List<MeetingNote>();
    public ICollection<ActionItem> CreatedActionItems { get; set; } = new List<ActionItem>();
}
