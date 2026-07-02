using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Models;

/// <summary>
/// Represents a managed employee or direct report.
/// </summary>
public class Person
{
    /// <summary>Gets or sets the primary key.</summary>
    public int PersonId { get; set; }

    /// <summary>Gets or sets the employee's first name.</summary>
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = "";

    /// <summary>Gets or sets the employee's last name.</summary>
    [Required, MaxLength(100)]
    public string LastName { get; set; } = "";

    /// <summary>
    /// Gets or sets the original (first-ever) hire date.
    /// Re-hire dates are tracked separately in <see cref="EmploymentPeriods"/>.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>Gets or sets whether the employee is currently active (not separated).</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Gets the full name in "First Last" format.</summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>Gets the display name in "Last, First" format used in lists and dropdowns.</summary>
    public string DisplayName => $"{LastName}, {FirstName}";

    /// <summary>Gets all employment periods (hire → separation) for this person.</summary>
    public ICollection<PersonEmploymentPeriod> EmploymentPeriods { get; set; } = new List<PersonEmploymentPeriod>();

    /// <summary>Gets all job titles held by this person, ordered by effective date.</summary>
    public ICollection<PersonJobTitle> JobTitles { get; set; } = new List<PersonJobTitle>();

    /// <summary>Gets all team/project assignments for this person.</summary>
    public ICollection<PersonProjectAssignment> ProjectAssignments { get; set; } = new List<PersonProjectAssignment>();

    /// <summary>Gets all glows and grows recorded for this person.</summary>
    public ICollection<GlowGrow> GlowsGrows { get; set; } = new List<GlowGrow>();

    /// <summary>Gets all 1:1 meetings held with this person.</summary>
    public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    /// <summary>Gets all action items associated with this person.</summary>
    public ICollection<ActionItem> ActionItems { get; set; } = new List<ActionItem>();

    /// <summary>Gets the checklist items assigned to this person.</summary>
    public ICollection<PersonItemAssignment> ItemAssignments { get; set; } = new List<PersonItemAssignment>();

    /// <summary>Gets all recorded checklist evaluation answers for this person.</summary>
    public ICollection<ChecklistItemEvaluation> ChecklistEvaluations { get; set; } = new List<ChecklistItemEvaluation>();
}
