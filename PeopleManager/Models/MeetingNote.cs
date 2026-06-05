namespace PeopleManager.Models;

public class MeetingNote
{
    public int MeetingNoteId { get; set; }
    public int MeetingId { get; set; }
    public Meeting Meeting { get; set; } = null!;
    public MeetingNoteCategory Category { get; set; }
    public string NoteText { get; set; } = "";
}
