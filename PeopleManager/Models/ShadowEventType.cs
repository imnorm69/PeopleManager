using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

/// <summary>
/// A type of ceremony or event that can be observed during a shadow session
/// (e.g. Planning, Refinement, or a team-specific combination such as
/// "Planning + Refinement"), along with the quota points it earns.
/// </summary>
public class ShadowEventType
{
    /// <summary>Gets or sets the primary key.</summary>
    public int ShadowEventTypeId { get; set; }

    /// <summary>Gets or sets the event type name.</summary>
    [Required, MaxLength(100)]
    public string Name { get; set; } = "";

    /// <summary>Gets or sets the quota points earned for shadowing this event type (0.5 or 1).</summary>
    public decimal Points { get; set; } = 1m;

    /// <summary>Gets or sets whether this event type is offered when logging new shadow sessions.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Gets all shadow sessions recorded against this event type.</summary>
    public ICollection<ShadowSession> ShadowSessions { get; set; } = new List<ShadowSession>();
}
