namespace PeopleManager.Models;

public enum GlowGrowType { Glow, Grow }

public enum MeetingNoteCategory
{
    GlowsGrows,
    ProjectNotes,
    CareerUpdates,
    TrainingUpdates,
    ActionItems
}

public enum ActionItemAssignee { Me, Person }

public enum ChecklistValueType { YesNo, Integer, Text, Percentage, Date }

public enum CheckFrequency { Weekly, BiWeekly, Monthly, Quarterly, SemiAnnual, Annual }

public enum SeparationReason
{
    EndOfInternship,
    VoluntaryResignation,
    Termination,
    Other
}
