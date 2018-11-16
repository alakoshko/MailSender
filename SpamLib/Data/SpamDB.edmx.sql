
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/16/2018 14:57:43
-- Generated from EDMX file: D:\Документы\GitHub\MailSender\SpamLib\Data\SpamDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpamDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MailingListRecepient_MailingList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailingListRecepient] DROP CONSTRAINT [FK_MailingListRecepient_MailingList];
GO
IF OBJECT_ID(N'[dbo].[FK_MailingListRecepient_Recepient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailingListRecepient] DROP CONSTRAINT [FK_MailingListRecepient_Recepient];
GO
IF OBJECT_ID(N'[dbo].[FK_MailingListScheduledTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledTasks] DROP CONSTRAINT [FK_MailingListScheduledTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduledTaskEmail_ScheduledTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledTaskEmail] DROP CONSTRAINT [FK_ScheduledTaskEmail_ScheduledTask];
GO
IF OBJECT_ID(N'[dbo].[FK_ScheduledTaskEmail_Email]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledTaskEmail] DROP CONSTRAINT [FK_ScheduledTaskEmail_Email];
GO
IF OBJECT_ID(N'[dbo].[FK_ServerScheduledTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledTasks] DROP CONSTRAINT [FK_ServerScheduledTask];
GO
IF OBJECT_ID(N'[dbo].[FK_SenderScheduledTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ScheduledTasks] DROP CONSTRAINT [FK_SenderScheduledTask];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MailingLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailingLists];
GO
IF OBJECT_ID(N'[dbo].[Recipients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recipients];
GO
IF OBJECT_ID(N'[dbo].[ScheduledTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduledTasks];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO
IF OBJECT_ID(N'[dbo].[Senders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Senders];
GO
IF OBJECT_ID(N'[dbo].[Servers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servers];
GO
IF OBJECT_ID(N'[dbo].[MailingListRecepient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailingListRecepient];
GO
IF OBJECT_ID(N'[dbo].[ScheduledTaskEmail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduledTaskEmail];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MailingLists'
CREATE TABLE [dbo].[MailingLists] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Decription] nvarchar(max)  NULL
);
GO

-- Creating table 'Recipients'
CREATE TABLE [dbo].[Recipients] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'ScheduledTasks'
CREATE TABLE [dbo].[ScheduledTasks] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [MailingLists_Id] uniqueidentifier  NULL,
    [Servers_Id] uniqueidentifier  NOT NULL,
    [Senders_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Senders'
CREATE TABLE [dbo].[Senders] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Servers'
CREATE TABLE [dbo].[Servers] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Port] smallint  NOT NULL,
    [UseSSL] bit  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MailingListRecepient'
CREATE TABLE [dbo].[MailingListRecepient] (
    [MailingLists_Id] uniqueidentifier  NOT NULL,
    [Recipients_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ScheduledTaskEmail'
CREATE TABLE [dbo].[ScheduledTaskEmail] (
    [ScheduledTasks_Id] uniqueidentifier  NOT NULL,
    [Emails_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MailingLists'
ALTER TABLE [dbo].[MailingLists]
ADD CONSTRAINT [PK_MailingLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Recipients'
ALTER TABLE [dbo].[Recipients]
ADD CONSTRAINT [PK_Recipients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScheduledTasks'
ALTER TABLE [dbo].[ScheduledTasks]
ADD CONSTRAINT [PK_ScheduledTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Senders'
ALTER TABLE [dbo].[Senders]
ADD CONSTRAINT [PK_Senders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servers'
ALTER TABLE [dbo].[Servers]
ADD CONSTRAINT [PK_Servers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MailingLists_Id], [Recipients_Id] in table 'MailingListRecepient'
ALTER TABLE [dbo].[MailingListRecepient]
ADD CONSTRAINT [PK_MailingListRecepient]
    PRIMARY KEY CLUSTERED ([MailingLists_Id], [Recipients_Id] ASC);
GO

-- Creating primary key on [ScheduledTasks_Id], [Emails_Id] in table 'ScheduledTaskEmail'
ALTER TABLE [dbo].[ScheduledTaskEmail]
ADD CONSTRAINT [PK_ScheduledTaskEmail]
    PRIMARY KEY CLUSTERED ([ScheduledTasks_Id], [Emails_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MailingLists_Id] in table 'MailingListRecepient'
ALTER TABLE [dbo].[MailingListRecepient]
ADD CONSTRAINT [FK_MailingListRecepient_MailingList]
    FOREIGN KEY ([MailingLists_Id])
    REFERENCES [dbo].[MailingLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Recipients_Id] in table 'MailingListRecepient'
ALTER TABLE [dbo].[MailingListRecepient]
ADD CONSTRAINT [FK_MailingListRecepient_Recepient]
    FOREIGN KEY ([Recipients_Id])
    REFERENCES [dbo].[Recipients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailingListRecepient_Recepient'
CREATE INDEX [IX_FK_MailingListRecepient_Recepient]
ON [dbo].[MailingListRecepient]
    ([Recipients_Id]);
GO

-- Creating foreign key on [MailingLists_Id] in table 'ScheduledTasks'
ALTER TABLE [dbo].[ScheduledTasks]
ADD CONSTRAINT [FK_MailingListScheduledTask]
    FOREIGN KEY ([MailingLists_Id])
    REFERENCES [dbo].[MailingLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailingListScheduledTask'
CREATE INDEX [IX_FK_MailingListScheduledTask]
ON [dbo].[ScheduledTasks]
    ([MailingLists_Id]);
GO

-- Creating foreign key on [ScheduledTasks_Id] in table 'ScheduledTaskEmail'
ALTER TABLE [dbo].[ScheduledTaskEmail]
ADD CONSTRAINT [FK_ScheduledTaskEmail_ScheduledTask]
    FOREIGN KEY ([ScheduledTasks_Id])
    REFERENCES [dbo].[ScheduledTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Emails_Id] in table 'ScheduledTaskEmail'
ALTER TABLE [dbo].[ScheduledTaskEmail]
ADD CONSTRAINT [FK_ScheduledTaskEmail_Email]
    FOREIGN KEY ([Emails_Id])
    REFERENCES [dbo].[Emails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduledTaskEmail_Email'
CREATE INDEX [IX_FK_ScheduledTaskEmail_Email]
ON [dbo].[ScheduledTaskEmail]
    ([Emails_Id]);
GO

-- Creating foreign key on [Servers_Id] in table 'ScheduledTasks'
ALTER TABLE [dbo].[ScheduledTasks]
ADD CONSTRAINT [FK_ServerScheduledTask]
    FOREIGN KEY ([Servers_Id])
    REFERENCES [dbo].[Servers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServerScheduledTask'
CREATE INDEX [IX_FK_ServerScheduledTask]
ON [dbo].[ScheduledTasks]
    ([Servers_Id]);
GO

-- Creating foreign key on [Senders_Id] in table 'ScheduledTasks'
ALTER TABLE [dbo].[ScheduledTasks]
ADD CONSTRAINT [FK_SenderScheduledTask]
    FOREIGN KEY ([Senders_Id])
    REFERENCES [dbo].[Senders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SenderScheduledTask'
CREATE INDEX [IX_FK_SenderScheduledTask]
ON [dbo].[ScheduledTasks]
    ([Senders_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------