CREATE TABLE [dbo].[Group_Contacts] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [GroupId]   INT NOT NULL,
    [ContactId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Group_Contacts_ToContacts] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contacts] ([ContactId]),
    CONSTRAINT [FK_Group_Contacts_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([GroupId]) ON DELETE CASCADE
);

