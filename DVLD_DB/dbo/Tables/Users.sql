CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [PersonID] INT           NOT NULL,
    [UserName] NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (20) NOT NULL,
    [IsActive] BIT           NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_People] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[People] ([PersonID])
);

