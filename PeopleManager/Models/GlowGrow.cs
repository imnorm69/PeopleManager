namespace PeopleManager.Models;

public class GlowGrow
{
    public int GlowGrowId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public GlowGrowType Type { get; set; }
    public string Note { get; set; } = "";
    public string? Source { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CommunicatedDate { get; set; }
}
