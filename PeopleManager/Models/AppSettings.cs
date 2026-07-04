namespace PeopleManager.Models;

/// <summary>
/// Singleton row holding application-wide configuration.
/// </summary>
public class AppSettings
{
    /// <summary>Gets or sets the primary key. Always 1 — this is a singleton row.</summary>
    public int AppSettingsId { get; set; }

    /// <summary>Gets or sets whether shadow point requirements are tracked and enforced.</summary>
    public bool ShadowRequirementsEnabled { get; set; } = true;

    /// <summary>Gets or sets the default per-quarter shadow point requirement (0 or more).</summary>
    public decimal DefaultShadowPointRequirement { get; set; } = 2m;
}
