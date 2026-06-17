using Microsoft.EntityFrameworkCore;

namespace PeopleManager.Data;

public static class DbFactory
{
    private const string ConnectionString =
        "Server=WIN1164;Database=BAPeopleMgr;User Id=BAPeopleDev;Password=Developer;TrustServerCertificate=True";

    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(ConnectionString)
            .Options;
        return new AppDbContext(options);
    }

    public static async Task InitializeDatabaseAsync()
    {
        await using var ctx = Create();

        // Create DB + all tables if this is a brand-new install.
        await ctx.Database.EnsureCreatedAsync();

        // Apply incremental schema changes for databases that already existed
        // before a given feature was added. Each block is fully idempotent.
        await ApplySchemaUpdatesAsync(ctx);
    }

    private static async Task ApplySchemaUpdatesAsync(AppDbContext ctx)
    {
        // v3: Replace template-based checklist with directly-assigned questions.
        //     All four old tables are empty (feature was never exposed in the UI),
        //     so we drop them and create the new schema.
        await ctx.Database.ExecuteSqlRawAsync(@"
            -- Drop old tables in dependency order (safe: they are always empty)
            IF EXISTS (SELECT 1 FROM sys.tables WHERE name = N'ChecklistItemEvaluations')
                DROP TABLE ChecklistItemEvaluations;
            IF EXISTS (SELECT 1 FROM sys.tables WHERE name = N'PersonChecklistAssignments')
                DROP TABLE PersonChecklistAssignments;
            IF EXISTS (SELECT 1 FROM sys.tables WHERE name = N'ChecklistTemplateItems')
                DROP TABLE ChecklistTemplateItems;
            IF EXISTS (SELECT 1 FROM sys.tables WHERE name = N'ChecklistTemplates')
                DROP TABLE ChecklistTemplates;

            -- ChecklistQuestions
            IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'ChecklistQuestions')
            BEGIN
                CREATE TABLE ChecklistQuestions (
                    QuestionId  INT IDENTITY(1,1) NOT NULL,
                    Description NVARCHAR(500)     NOT NULL,
                    ValueType   INT               NOT NULL DEFAULT 0,
                    SortOrder   INT               NOT NULL DEFAULT 0,
                    CONSTRAINT PK_ChecklistQuestions PRIMARY KEY (QuestionId)
                );
            END

            -- PersonQuestionAssignments  (Frequency lives here, not on the question)
            IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'PersonQuestionAssignments')
            BEGIN
                CREATE TABLE PersonQuestionAssignments (
                    AssignmentId INT          IDENTITY(1,1) NOT NULL,
                    PersonId     INT          NOT NULL,
                    QuestionId   INT          NOT NULL,
                    Frequency    INT          NOT NULL,
                    AssignedDate DATETIME2(7) NOT NULL,
                    CONSTRAINT PK_PersonQuestionAssignments PRIMARY KEY (AssignmentId),
                    CONSTRAINT FK_PQA_People    FOREIGN KEY (PersonId)   REFERENCES People(PersonId),
                    CONSTRAINT FK_PQA_Questions FOREIGN KEY (QuestionId) REFERENCES ChecklistQuestions(QuestionId),
                    CONSTRAINT UQ_PQA_PersonQuestion UNIQUE (PersonId, QuestionId)
                );
            END

            -- ChecklistItemEvaluations  (now references QuestionId instead of TemplateItemId)
            IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'ChecklistItemEvaluations')
            BEGIN
                CREATE TABLE ChecklistItemEvaluations (
                    EvaluationId  INT IDENTITY(1,1) NOT NULL,
                    PersonId      INT          NOT NULL,
                    QuestionId    INT          NOT NULL,
                    MeetingId     INT          NULL,
                    EvaluatedDate DATETIME2(7) NOT NULL,
                    Value         NVARCHAR(MAX) NULL,
                    Notes         NVARCHAR(MAX) NULL,
                    CONSTRAINT PK_ChecklistItemEvaluations PRIMARY KEY (EvaluationId),
                    CONSTRAINT FK_CIE_People    FOREIGN KEY (PersonId)   REFERENCES People(PersonId),
                    CONSTRAINT FK_CIE_Questions FOREIGN KEY (QuestionId) REFERENCES ChecklistQuestions(QuestionId),
                    CONSTRAINT FK_CIE_Meetings  FOREIGN KEY (MeetingId)  REFERENCES Meetings(MeetingId)
                );
                CREATE INDEX IX_CIE_Person_Question_Date
                    ON ChecklistItemEvaluations (PersonId, QuestionId, EvaluatedDate);
            END");

        // v2: DueDate column on ActionItems (default to CreatedDate + 14 days for existing rows)
        // EXEC wrapper: SQL Server resolves column names at parse time for the whole batch,
        // so the UPDATE must run as dynamic SQL after the ALTER TABLE ADD has executed.
        await ctx.Database.ExecuteSqlRawAsync(@"
            IF NOT EXISTS (
                SELECT 1 FROM sys.columns
                WHERE object_id = OBJECT_ID(N'ActionItems') AND name = N'DueDate'
            )
            BEGIN
                ALTER TABLE ActionItems ADD DueDate DATETIME2(7) NULL;
                EXEC(N'UPDATE ActionItems SET DueDate = DATEADD(day, 14, CreatedDate)');
                ALTER TABLE ActionItems ALTER COLUMN DueDate DATETIME2(7) NOT NULL;
            END");

        // v2: Source column on GlowsGrows (optional, nullable)
        await ctx.Database.ExecuteSqlRawAsync(@"
            IF NOT EXISTS (
                SELECT 1 FROM sys.columns
                WHERE object_id = OBJECT_ID(N'GlowsGrows') AND name = N'Source'
            )
            BEGIN
                ALTER TABLE GlowsGrows ADD Source NVARCHAR(500) NULL;
            END");

        // v2: IsActive column on People (default 1 = active for existing rows)
        await ctx.Database.ExecuteSqlRawAsync(@"
            IF NOT EXISTS (
                SELECT 1 FROM sys.columns
                WHERE object_id = OBJECT_ID(N'People') AND name = N'IsActive'
            )
            BEGIN
                ALTER TABLE People ADD IsActive BIT NOT NULL DEFAULT 1;
            END");

        // v2: PersonEmploymentPeriods table + seed one period per existing person
        await ctx.Database.ExecuteSqlRawAsync(@"
            IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'PersonEmploymentPeriods')
            BEGIN
                CREATE TABLE PersonEmploymentPeriods (
                    PeriodId          INT IDENTITY(1,1) NOT NULL,
                    PersonId          INT NOT NULL,
                    HireDate          DATETIME2(7) NOT NULL,
                    SeparationDate    DATETIME2(7) NULL,
                    SeparationReason  INT NULL,
                    SeparationNotes   NVARCHAR(MAX) NULL,
                    CONSTRAINT PK_PersonEmploymentPeriods
                        PRIMARY KEY (PeriodId),
                    CONSTRAINT FK_PersonEmploymentPeriods_People_PersonId
                        FOREIGN KEY (PersonId) REFERENCES People(PersonId)
                );
                CREATE INDEX IX_PersonEmploymentPeriods_PersonId_SeparationDate
                    ON PersonEmploymentPeriods (PersonId, SeparationDate);

                -- Give every existing person an opening employment period
                INSERT INTO PersonEmploymentPeriods (PersonId, HireDate)
                SELECT PersonId, StartDate FROM People;
            END");
    }
}
