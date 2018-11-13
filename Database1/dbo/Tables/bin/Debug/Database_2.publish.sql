﻿/*
Deployment script for FestiSpec

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "FestiSpec"
:setvar DefaultFilePrefix "FestiSpec"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The type for column employee_id in table [dbo].[Bank_Account] is currently  NCHAR (10) NULL but is being changed to  INT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Bank_Account])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column contact_id on table [dbo].[Event] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Event])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Plan_inspector].[inspector_id] on table [dbo].[Plan_inspector] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Plan_inspector])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file 55fd25a8-e308-4bcf-8e24-7e11caa69d04';

PRINT N'Rename [dbo].[Plan_inspector].[Id] to plan_id';


GO
EXECUTE sp_rename @objname = N'[dbo].[Plan_inspector].[Id]', @newname = N'plan_id', @objtype = N'COLUMN';


GO
PRINT N'The following operation was generated from a refactoring log file d38f95e3-1ba6-45e5-ac20-9d31ccc33d20';

PRINT N'Rename [dbo].[Contact].[Id] to contact_id';


GO
EXECUTE sp_rename @objname = N'[dbo].[Contact].[Id]', @newname = N'contact_id', @objtype = N'COLUMN';


GO
PRINT N'Altering [dbo].[Bank_Account]...';


GO
ALTER TABLE [dbo].[Bank_Account] ALTER COLUMN [employee_id] INT NULL;


GO
PRINT N'Altering [dbo].[Event]...';


GO
ALTER TABLE [dbo].[Event] ALTER COLUMN [contact_id] INT NOT NULL;


GO
PRINT N'Starting rebuilding table [dbo].[Plan_inspector]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Plan_inspector] (
    [plan_id]      INT NOT NULL,
    [inspector_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([plan_id] ASC, [inspector_id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Plan_inspector])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Plan_inspector] ([plan_id])
        SELECT   [plan_id]
        FROM     [dbo].[Plan_inspector]
        ORDER BY [plan_id] ASC;
    END

DROP TABLE [dbo].[Plan_inspector];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Plan_inspector]', N'Plan_inspector';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Department]...';


GO
CREATE TABLE [dbo].[Department] (
    [id]          INT            NOT NULL,
    [name]        NVARCHAR (MAX) NULL,
    [description] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Employee]...';


GO
CREATE TABLE [dbo].[Employee] (
    [id]            INT            NOT NULL,
    [department_id] INT            NULL,
    [name]          NVARCHAR (MAX) NULL,
    [surname]       NVARCHAR (MAX) NULL,
    [acces level]   INT            NULL,
    [position]      NVARCHAR (MAX) NULL,
    [postcode]      NVARCHAR (6)   NULL,
    [house number]  NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Inlogdata]...';


GO
CREATE TABLE [dbo].[Inlogdata] (
    [Id]       INT           NOT NULL,
    [username] NVARCHAR (50) NULL,
    [password] NVARCHAR (24) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Invoice]...';


GO
CREATE TABLE [dbo].[Invoice] (
    [id]             INT             NOT NULL,
    [employee_id]    INT             NULL,
    [quotation_id]   INT             NULL,
    [payment_status] INT             NULL,
    [sum]            DECIMAL (18, 2) NULL,
    [deadline]       DATETIME        NULL,
    [date]           DATE            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Planning]...';


GO
CREATE TABLE [dbo].[Planning] (
    [id]               INT      NOT NULL,
    [customer_id]      INT      NULL,
    [event_id]         INT      NULL,
    [questionnaire_id] INT      NULL,
    [start_date]       DATETIME NULL,
    [employee_id]      INT      NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[Contact]...';


GO
ALTER TABLE [dbo].[Contact]
    ADD UNIQUE NONCLUSTERED ([contact_id] ASC);


GO
PRINT N'Creating unnamed constraint on [dbo].[Plan_inspector]...';


GO
ALTER TABLE [dbo].[Plan_inspector] WITH NOCHECK
    ADD FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Planning] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Plan_inspector]...';


GO
ALTER TABLE [dbo].[Plan_inspector] WITH NOCHECK
    ADD FOREIGN KEY ([inspector_id]) REFERENCES [dbo].[Inspector] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Employee]...';


GO
ALTER TABLE [dbo].[Employee] WITH NOCHECK
    ADD FOREIGN KEY ([id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Employee]...';


GO
ALTER TABLE [dbo].[Employee] WITH NOCHECK
    ADD FOREIGN KEY ([department_id]) REFERENCES [dbo].[Department] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Inlogdata]...';


GO
ALTER TABLE [dbo].[Inlogdata] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Invoice]...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employee] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Invoice]...';


GO
ALTER TABLE [dbo].[Invoice] WITH NOCHECK
    ADD FOREIGN KEY ([quotation_id]) REFERENCES [dbo].[Quotation] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning] WITH NOCHECK
    ADD FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning] WITH NOCHECK
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employee] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning] WITH NOCHECK
    ADD FOREIGN KEY ([questionnaire_id]) REFERENCES [dbo].[Questionnaire] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning] WITH NOCHECK
    ADD FOREIGN KEY ([event_id]) REFERENCES [dbo].[Event] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Bank_Account]...';


GO
ALTER TABLE [dbo].[Bank_Account] WITH NOCHECK
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Contact]...';


GO
ALTER TABLE [dbo].[Contact] WITH NOCHECK
    ADD FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Event]...';


GO
ALTER TABLE [dbo].[Event] WITH NOCHECK
    ADD FOREIGN KEY ([contact_id]) REFERENCES [dbo].[Contact] ([contact_id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Inspector]...';


GO
ALTER TABLE [dbo].[Inspector] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Question]...';


GO
ALTER TABLE [dbo].[Question] WITH NOCHECK
    ADD FOREIGN KEY ([questionnaire_id]) REFERENCES [dbo].[Questionnaire] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation] WITH NOCHECK
    ADD FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Planning] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation] WITH NOCHECK
    ADD FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation] WITH NOCHECK
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employee] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation] WITH NOCHECK
    ADD FOREIGN KEY ([event_id]) REFERENCES [dbo].[Event] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[StandardQuestionsList]...';


GO
ALTER TABLE [dbo].[StandardQuestionsList] WITH NOCHECK
    ADD FOREIGN KEY ([standardquestion_id]) REFERENCES [dbo].[StandardQuestion] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[StandardQuestionsList]...';


GO
ALTER TABLE [dbo].[StandardQuestionsList] WITH NOCHECK
    ADD FOREIGN KEY ([questionnaire_id]) REFERENCES [dbo].[Questionnaire] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '55fd25a8-e308-4bcf-8e24-7e11caa69d04')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('55fd25a8-e308-4bcf-8e24-7e11caa69d04')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd38f95e3-1ba6-45e5-ac20-9d31ccc33d20')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d38f95e3-1ba6-45e5-ac20-9d31ccc33d20')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Plan_inspector'), OBJECT_ID(N'dbo.Employee'), OBJECT_ID(N'dbo.Inlogdata'), OBJECT_ID(N'dbo.Invoice'), OBJECT_ID(N'dbo.Planning'), OBJECT_ID(N'dbo.Bank_Account'), OBJECT_ID(N'dbo.Contact'), OBJECT_ID(N'dbo.Event'), OBJECT_ID(N'dbo.Inspector'), OBJECT_ID(N'dbo.Question'), OBJECT_ID(N'dbo.Quotation'), OBJECT_ID(N'dbo.StandardQuestionsList'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO
