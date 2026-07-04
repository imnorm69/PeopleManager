namespace PeopleManager.Models;

/// <summary>
/// Records one person observing another as they facilitate a meeting or event,
/// earning the shadower quota points toward their calendar-quarter requirement.
/// </summary>
public class ShadowSession
{
    /// <summary>Gets or sets the primary key.</summary>
    public int ShadowSessionId { get; set; }

    /// <summary>Gets or sets the date the shadow session occurred.</summary>
    public DateTime Date { get; set; }

    /// <summary>Gets or sets the person who did the observing (earns the quota points).</summary>
    public int ShadowerId { get; set; }

    /// <summary>Gets or sets the shadower navigation property.</summary>
    public Person Shadower { get; set; } = null!;

    /// <summary>Gets or sets the name of the person who was observed facilitating, as typed in.</summary>
    public string ObservedName { get; set; } = "";

    /// <summary>Gets or sets the free-text name of the team that was observed.</summary>
    public string TeamObserved { get; set; } = "";

    /// <summary>Gets or sets the event type observed.</summary>
    public int EventTypeId { get; set; }

    /// <summary>Gets or sets the event type navigation property.</summary>
    public ShadowEventType EventType { get; set; } = null!;

    /// <summary>Gets or sets the quota points earned (0.5 or 1), or null if shadow requirements were disabled when logged.</summary>
    public decimal? Points { get; set; }
}
