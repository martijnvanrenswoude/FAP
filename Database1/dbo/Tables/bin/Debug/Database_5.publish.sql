﻿/*
Deployment script for FAPDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "FAPDb"
:setvar DefaultFilePrefix "FAPDb"
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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Bank_Account]...';


GO
CREATE TABLE [dbo].[Bank_Account] (
    [account_number] INT NOT NULL,
    [employee_id]    INT NULL,
    PRIMARY KEY CLUSTERED ([account_number] ASC)
);


GO
PRINT N'Creating [dbo].[Contact]...';


GO
CREATE TABLE [dbo].[Contact] (
    [contact_id]   INT            NOT NULL,
    [customer_id]  INT            NOT NULL,
    [name]         NVARCHAR (MAX) NULL,
    [surname]      NVARCHAR (MAX) NULL,
    [telephone_nr] INT            NULL,
    [email]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([contact_id] ASC, [customer_id] ASC),
    UNIQUE NONCLUSTERED ([contact_id] ASC)
);


GO
PRINT N'Creating [dbo].[Customer]...';


GO
CREATE TABLE [dbo].[Customer] (
    [id]           INT            NOT NULL,
    [name]         NVARCHAR (MAX) NULL,
    [telephone_nr] INT            NULL,
    [postcode]     NVARCHAR (6)   NULL,
    [house number] NVARCHAR (10)  NULL,
    [email]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


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
PRINT N'Creating [dbo].[Event]...';


GO
CREATE TABLE [dbo].[Event] (
    [Id]              INT            NOT NULL,
    [contact_id]      INT            NOT NULL,
    [name]            NVARCHAR (MAX) NULL,
    [date]            NVARCHAR (MAX) NULL,
    [amount_visitors] INT            NULL,
    [surface area_m2] INT            NULL,
    [description]     NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ID]...';


GO
CREATE TABLE [dbo].[ID] (
    [Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
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
PRINT N'Creating [dbo].[Inspector]...';


GO
CREATE TABLE [dbo].[Inspector] (
    [Id]           INT            NOT NULL,
    [name]         NVARCHAR (MAX) NULL,
    [surname]      NVARCHAR (MAX) NULL,
    [telephone_nr] INT            NULL,
    [postcode]     NVARCHAR (6)   NULL,
    [house number] NVARCHAR (5)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Inspector_shedule]...';


GO
CREATE TABLE [dbo].[Inspector_shedule] (
    [inspector_id]    INT      NOT NULL,
    [date]            DATE     NULL,
    [available_from]  DATETIME NULL,
    [available_until] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([inspector_id] ASC)
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
PRINT N'Creating [dbo].[Payment_status]...';


GO
CREATE TABLE [dbo].[Payment_status] (
    [id]          INT            NOT NULL,
    [name]        NVARCHAR (MAX) NULL,
    [descriptiom] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Plan_inspector]...';


GO
CREATE TABLE [dbo].[Plan_inspector] (
    [plan_id]      INT NOT NULL,
    [inspector_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([plan_id] ASC, [inspector_id] ASC)
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
PRINT N'Creating [dbo].[Question]...';


GO
CREATE TABLE [dbo].[Question] (
    [Id]               INT            NOT NULL,
    [questionnaire_id] INT            NOT NULL,
    [question]         NVARCHAR (MAX) NULL,
    [answer]           NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Questionnaire]...';


GO
CREATE TABLE [dbo].[Questionnaire] (
    [Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Quotation]...';


GO
CREATE TABLE [dbo].[Quotation] (
    [id]          INT             NOT NULL,
    [plan_id]     INT             NULL,
    [customer_id] INT             NULL,
    [employee_id] INT             NULL,
    [event_id]    INT             NULL,
    [sum]         DECIMAL (18, 2) NULL,
    [deadline]    DATETIME        NULL,
    [date]        DATE            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[StandardQuestion]...';


GO
CREATE TABLE [dbo].[StandardQuestion] (
    [Id]       INT            NOT NULL,
    [question] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[StandardQuestionsList]...';


GO
CREATE TABLE [dbo].[StandardQuestionsList] (
    [standardquestion_id] INT            NOT NULL,
    [questionnaire_id]    INT            NOT NULL,
    [answer]              NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([standardquestion_id] ASC, [questionnaire_id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[Bank_Account]...';


GO
ALTER TABLE [dbo].[Bank_Account]
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Contact]...';


GO
ALTER TABLE [dbo].[Contact]
    ADD FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Employee]...';


GO
ALTER TABLE [dbo].[Employee]
    ADD FOREIGN KEY ([id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Employee]...';


GO
ALTER TABLE [dbo].[Employee]
    ADD FOREIGN KEY ([department_id]) REFERENCES [dbo].[Department] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Event]...';


GO
ALTER TABLE [dbo].[Event]
    ADD FOREIGN KEY ([contact_id]) REFERENCES [dbo].[Contact] ([contact_id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Inlogdata]...';


GO
ALTER TABLE [dbo].[Inlogdata]
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Inspector]...';


GO
ALTER TABLE [dbo].[Inspector]
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[ID] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Inspector_shedule]...';


GO
ALTER TABLE [dbo].[Inspector_shedule]
    ADD FOREIGN KEY ([inspector_id]) REFERENCES [dbo].[Inspector] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Invoice]...';


GO
ALTER TABLE [dbo].[Invoice]
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employee] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Invoice]...';


GO
ALTER TABLE [dbo].[Invoice]
    ADD FOREIGN KEY ([quotation_id]) REFERENCES [dbo].[Quotation] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Invoice]...';


GO
ALTER TABLE [dbo].[Invoice]
    ADD FOREIGN KEY ([payment_status]) REFERENCES [dbo].[Payment_status] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Plan_inspector]...';


GO
ALTER TABLE [dbo].[Plan_inspector]
    ADD FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Planning] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Plan_inspector]...';


GO
ALTER TABLE [dbo].[Plan_inspector]
    ADD FOREIGN KEY ([inspector_id]) REFERENCES [dbo].[Inspector] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning]
    ADD FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning]
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employee] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning]
    ADD FOREIGN KEY ([questionnaire_id]) REFERENCES [dbo].[Questionnaire] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Planning]...';


GO
ALTER TABLE [dbo].[Planning]
    ADD FOREIGN KEY ([event_id]) REFERENCES [dbo].[Event] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Question]...';


GO
ALTER TABLE [dbo].[Question]
    ADD FOREIGN KEY ([questionnaire_id]) REFERENCES [dbo].[Questionnaire] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation]
    ADD FOREIGN KEY ([plan_id]) REFERENCES [dbo].[Planning] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation]
    ADD FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation]
    ADD FOREIGN KEY ([employee_id]) REFERENCES [dbo].[Employee] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Quotation]...';


GO
ALTER TABLE [dbo].[Quotation]
    ADD FOREIGN KEY ([event_id]) REFERENCES [dbo].[Event] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[StandardQuestionsList]...';


GO
ALTER TABLE [dbo].[StandardQuestionsList]
    ADD FOREIGN KEY ([standardquestion_id]) REFERENCES [dbo].[StandardQuestion] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[StandardQuestionsList]...';


GO
ALTER TABLE [dbo].[StandardQuestionsList]
    ADD FOREIGN KEY ([questionnaire_id]) REFERENCES [dbo].[Questionnaire] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4c6b4f68-f203-4c35-a605-fb510b9141a7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4c6b4f68-f203-4c35-a605-fb510b9141a7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '414729a7-81f6-4266-870a-60d816768538')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('414729a7-81f6-4266-870a-60d816768538')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8b2fe1ca-b225-4001-8781-1958d37a99e5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8b2fe1ca-b225-4001-8781-1958d37a99e5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '698688e1-1962-432a-9ef0-49ddab4d36bc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('698688e1-1962-432a-9ef0-49ddab4d36bc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd7fcb4ea-d29c-4b9d-b672-d1f0ef48794a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d7fcb4ea-d29c-4b9d-b672-d1f0ef48794a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8549346b-4116-4301-913f-5e60372ed642')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8549346b-4116-4301-913f-5e60372ed642')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '37e5c431-000a-4d8c-8594-139924435516')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('37e5c431-000a-4d8c-8594-139924435516')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e3dd32fb-781d-428f-ac13-396ada3b0e92')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e3dd32fb-781d-428f-ac13-396ada3b0e92')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'adf77514-24ce-466e-bdab-72a1a1edf9a9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('adf77514-24ce-466e-bdab-72a1a1edf9a9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '21c2d74e-4623-4d1a-971e-b1a3ef8cb484')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('21c2d74e-4623-4d1a-971e-b1a3ef8cb484')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6cea2a86-64c5-48a2-b9ab-7a25f24a14f3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6cea2a86-64c5-48a2-b9ab-7a25f24a14f3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '387e704d-06ab-4217-be0d-d7b272f152e5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('387e704d-06ab-4217-be0d-d7b272f152e5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '85eed486-a977-4daa-a6bf-4b61c255af4f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('85eed486-a977-4daa-a6bf-4b61c255af4f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ee8565f3-468f-448c-9da5-049ed9aa19d4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ee8565f3-468f-448c-9da5-049ed9aa19d4')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0fa0cf3f-d3f6-4adc-aa34-4b7f98214209')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0fa0cf3f-d3f6-4adc-aa34-4b7f98214209')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '15f1b2a5-6e46-49b8-8275-9b2e6405988d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('15f1b2a5-6e46-49b8-8275-9b2e6405988d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a98842a1-7584-4a7a-8521-fcc71a4c28ef')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a98842a1-7584-4a7a-8521-fcc71a4c28ef')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3b4a2607-5e78-4d94-95a6-f04b84984812')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3b4a2607-5e78-4d94-95a6-f04b84984812')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ca33d1bf-c9f6-473d-9416-9ed372d16d0f')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ca33d1bf-c9f6-473d-9416-9ed372d16d0f')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b9a159bd-5c39-4ccc-a2b8-540eae1d7ce9')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b9a159bd-5c39-4ccc-a2b8-540eae1d7ce9')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '57e70407-fe9b-4c7e-ba4f-de14b0a69955')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('57e70407-fe9b-4c7e-ba4f-de14b0a69955')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e8d68462-40b6-4188-ba24-1b44a4d24645')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e8d68462-40b6-4188-ba24-1b44a4d24645')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '93671c54-137b-4080-8206-7de37da3145e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('93671c54-137b-4080-8206-7de37da3145e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '53ca4be8-785a-44bc-aabc-cf838614309d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('53ca4be8-785a-44bc-aabc-cf838614309d')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5fa35a00-d14c-4308-a223-7bca6bd9a027')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5fa35a00-d14c-4308-a223-7bca6bd9a027')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '55fd25a8-e308-4bcf-8e24-7e11caa69d04')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('55fd25a8-e308-4bcf-8e24-7e11caa69d04')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd38f95e3-1ba6-45e5-ac20-9d31ccc33d20')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d38f95e3-1ba6-45e5-ac20-9d31ccc33d20')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
