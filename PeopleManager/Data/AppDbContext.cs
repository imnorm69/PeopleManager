using Microsoft.EntityFrameworkCore;
using PeopleManager.Models;

namespace PeopleManager.Data;

/// <summary>
/// Entity Framework Core database context for PeopleManager.
/// All table mappings, relationship configurations, and index definitions live here.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>Gets or sets the People table.</summary>
    public DbSet<Person>                   People                    { get; set; }
    /// <summary>Gets or sets the PersonEmploymentPeriods table.</summary>
    public DbSet<PersonEmploymentPeriod>   PersonEmploymentPeriods   { get; set; }
    /// <summary>Gets or sets the PersonJobTitles table.</summary>
    public DbSet<PersonJobTitle>           PersonJobTitles           { get; set; }
    /// <summary>Gets or sets the ProjectTeams table.</summary>
    public DbSet<ProjectTeam>              ProjectTeams              { get; set; }
    /// <summary>Gets or sets the PersonProjectAssignments table.</summary>
    public DbSet<PersonProjectAssignment>  PersonProjectAssignments  { get; set; }
    /// <summary>Gets or sets the GlowsGrows table.</summary>
    public DbSet<GlowGrow>                 GlowsGrows                { get; set; }
    /// <summary>Gets or sets the Meetings table.</summary>
    public DbSet<Meeting>                  Meetings                  { get; set; }
    /// <summary>Gets or sets the MeetingNotes table.</summary>
    public DbSet<MeetingNote>              MeetingNotes              { get; set; }
    /// <summary>Gets or sets the ActionItems table.</summary>
    public DbSet<ActionItem>               ActionItems               { get; set; }
    /// <summary>Gets or sets the ChecklistItems table.</summary>
    public DbSet<ChecklistItem>            ChecklistItems            { get; set; }
    /// <summary>Gets or sets the PersonItemAssignments table.</summary>
    public DbSet<PersonItemAssignment>     PersonItemAssignments     { get; set; }
    /// <summary>Gets or sets the ChecklistItemEvaluations table.</summary>
    public DbSet<ChecklistItemEvaluation>  ChecklistItemEvaluations  { get; set; }
    /// <summary>Gets or sets the ShadowSessions table.</summary>
    public DbSet<ShadowSession>            ShadowSessions            { get; set; }

    /// <summary>Initialises a new context instance with the given options.</summary>
    /// <param name="options">EF Core options including the connection string.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── Explicit PKs (property name doesn't match [TypeName]Id convention) ──
        modelBuilder.Entity<PersonProjectAssignment>().HasKey(a => a.AssignmentId);
        modelBuilder.Entity<PersonEmploymentPeriod>().HasKey(p => p.PeriodId);
        modelBuilder.Entity<PersonItemAssignment>().HasKey(a => a.AssignmentId);
        modelBuilder.Entity<ChecklistItem>().HasKey(i => i.ItemId);
        modelBuilder.Entity<ChecklistItemEvaluation>().HasKey(e => e.EvaluationId);


        // ── ActionItem — two Meeting FKs, no cascade to avoid cycles ────────────
        modelBuilder.Entity<ActionItem>()
            .HasOne(a => a.CreatedInMeeting)
            .WithMany(m => m.CreatedActionItems)
            .HasForeignKey(a => a.CreatedInMeetingId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ActionItem>()
            .HasOne(a => a.CompletedInMeeting)
            .WithMany()
            .HasForeignKey(a => a.CompletedInMeetingId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ActionItem>()
            .HasOne(a => a.Person)
            .WithMany(p => p.ActionItems)
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Meeting → Person ─────────────────────────────────────────────────────
        modelBuilder.Entity<Meeting>()
            .HasOne(m => m.Person)
            .WithMany(p => p.Meetings)
            .HasForeignKey(m => m.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── PersonEmploymentPeriod → Person ──────────────────────────────────────
        modelBuilder.Entity<PersonEmploymentPeriod>()
            .HasOne(p => p.Person)
            .WithMany(p => p.EmploymentPeriods)
            .HasForeignKey(p => p.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── ChecklistItemEvaluation ───────────────────────────────────────────────
        modelBuilder.Entity<ChecklistItemEvaluation>()
            .HasOne(e => e.Person)
            .WithMany(p => p.ChecklistEvaluations)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChecklistItemEvaluation>()
            .HasOne(e => e.Item)
            .WithMany(i => i.Evaluations)
            .HasForeignKey(e => e.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChecklistItemEvaluation>()
            .HasOne(e => e.Meeting)
            .WithMany()
            .HasForeignKey(e => e.MeetingId)
            .OnDelete(DeleteBehavior.SetNull);

        // ── PersonItemAssignment ─────────────────────────────────────────────────
        modelBuilder.Entity<PersonItemAssignment>()
            .HasOne(a => a.Person)
            .WithMany(p => p.ItemAssignments)
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PersonItemAssignment>()
            .HasOne(a => a.Item)
            .WithMany(i => i.Assignments)
            .HasForeignKey(a => a.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── PersonProjectAssignment → Person ──────────────────────────────────────
        modelBuilder.Entity<PersonProjectAssignment>()
            .HasOne(a => a.Person)
            .WithMany(p => p.ProjectAssignments)
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── GlowGrow → Person ────────────────────────────────────────────────────
        modelBuilder.Entity<GlowGrow>()
            .HasOne(g => g.Person)
            .WithMany(p => p.GlowsGrows)
            .HasForeignKey(g => g.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── ShadowSession — two Person FKs, no cascade to avoid cycles ──────────
        modelBuilder.Entity<ShadowSession>()
            .HasOne(s => s.Shadower)
            .WithMany(p => p.ShadowSessionsAsShadower)
            .HasForeignKey(s => s.ShadowerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShadowSession>()
            .HasOne(s => s.ObservedPerson)
            .WithMany(p => p.ShadowSessionsAsObserved)
            .HasForeignKey(s => s.ObservedPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Indexes ──────────────────────────────────────────────────────────────
        modelBuilder.Entity<PersonJobTitle>()
            .HasIndex(j => new { j.PersonId, j.EffectiveDate });
        modelBuilder.Entity<PersonProjectAssignment>()
            .HasIndex(a => new { a.PersonId, a.RemovedDate });
        modelBuilder.Entity<PersonEmploymentPeriod>()
            .HasIndex(p => new { p.PersonId, p.SeparationDate });
        modelBuilder.Entity<ActionItem>()
            .HasIndex(a => new { a.PersonId, a.IsComplete });
        modelBuilder.Entity<ChecklistItemEvaluation>()
            .HasIndex(e => new { e.PersonId, e.ItemId, e.EvaluatedDate });
        modelBuilder.Entity<PersonItemAssignment>()
            .HasIndex(a => new { a.PersonId, a.ItemId })
            .IsUnique();   // a person can only be assigned a given item once
        modelBuilder.Entity<ShadowSession>()
            .HasIndex(s => new { s.ShadowerId, s.Date });   // quota lookups per shadower per quarter
    }
}
