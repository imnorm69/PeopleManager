namespace PeopleManager.Models;

/// <summary>Distinguishes between positive feedback (Glow) and constructive feedback (Grow).</summary>
public enum GlowGrowType { Glow, Grow }

/// <summary>Categories used to organise free-text notes within a 1:1 meeting.</summary>
public enum MeetingNoteCategory
{
    /// <summary>General discussion notes (mapped to the "General Notes" tab in the meeting form).</summary>
    GlowsGrows,
    /// <summary>Notes about ongoing projects and work updates.</summary>
    ProjectNotes,
    /// <summary>Notes about career development, goals, and growth conversations.</summary>
    CareerUpdates,
    /// <summary>Notes about training, learning, and skill development.</summary>
    TrainingUpdates,
    /// <summary>Placeholder category; action items are managed separately, not as notes.</summary>
    ActionItems
}

/// <summary>Indicates who is responsible for completing an action item.</summary>
public enum ActionItemAssignee
{
    /// <summary>The manager is responsible.</summary>
    Me,
    /// <summary>The direct report is responsible.</summary>
    Person
}

/// <summary>The data type used to capture a checklist question's answer.</summary>
public enum ChecklistValueType
{
    /// <summary>A simple Yes or No answer.</summary>
    YesNo,
    /// <summary>A whole number.</summary>
    Integer,
    /// <summary>Free-form text.</summary>
    Text,
    /// <summary>A whole-number percentage from 0 to 100.</summary>
    Percentage,
    /// <summary>A calendar date.</summary>
    Date
}

/// <summary>How often a checklist question should be revisited for a given person.</summary>
public enum CheckFrequency { Weekly, BiWeekly, Monthly, Quarterly, SemiAnnual, Annual }

/// <summary>The reason an employee's employment ended.</summary>
public enum SeparationReason
{
    EndOfInternship,
    VoluntaryResignation,
    Termination,
    Other
}

/// <summary>The type of event observed during a shadow session.</summary>
public enum ShadowEventType
{
    Planning,
    Refinement,
    Review,
    Retro,
    DailyStandup,
    Other
}
