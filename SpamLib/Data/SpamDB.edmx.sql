
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2018 23:53:39
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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

-- Creating table 'Recepients'
CREATE TABLE [dbo].[Recepients] (
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
    [MailingLists_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Senders_Id] uniqueidentifier  NOT NULL,
    [Servers_Id] uniqueidentifier  NOT NULL
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
    [Port] nvarchar(max)  NOT NULL,
    [UseSSL] bit  NOT NULL
);
GO

-- Creating table 'MailingListRecepient'
CREATE TABLE [dbo].[MailingListRecepient] (
    [MailingLists_Id] uniqueidentifier  NOT NULL,
    [Recepients_Id] uniqueidentifier  NOT NULL
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

-- Creating primary key on [Id] in table 'Recepients'
ALTER TABLE [dbo].[Recepients]
ADD CONSTRAINT [PK_Recepients]
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

-- Creating primary key on [MailingLists_Id], [Recepients_Id] in table 'MailingListRecepient'
ALTER TABLE [dbo].[MailingListRecepient]
ADD CONSTRAINT [PK_MailingListRecepient]
    PRIMARY KEY CLUSTERED ([MailingLists_Id], [Recepients_Id] ASC);
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

-- Creating foreign key on [Recepients_Id] in table 'MailingListRecepient'
ALTER TABLE [dbo].[MailingListRecepient]
ADD CONSTRAINT [FK_MailingListRecepient_Recepient]
    FOREIGN KEY ([Recepients_Id])
    REFERENCES [dbo].[Recepients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailingListRecepient_Recepient'
CREATE INDEX [IX_FK_MailingListRecepient_Recepient]
ON [dbo].[MailingListRecepient]
    ([Recepients_Id]);
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

-- Creating foreign key on [Senders_Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_EmailSender]
    FOREIGN KEY ([Senders_Id])
    REFERENCES [dbo].[Senders]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailSender'
CREATE INDEX [IX_FK_EmailSender]
ON [dbo].[Emails]
    ([Senders_Id]);
GO

-- Creating foreign key on [Servers_Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_EmailServer]
    FOREIGN KEY ([Servers_Id])
    REFERENCES [dbo].[Servers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailServer'
CREATE INDEX [IX_FK_EmailServer]
ON [dbo].[Emails]
    ([Servers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------