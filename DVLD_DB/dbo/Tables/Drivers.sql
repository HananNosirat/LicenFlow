CREATE TABLE [dbo].[Drivers] (
    [DriverID]        INT           IDENTITY (1, 1) NOT NULL,
    [PersonID]        INT           NOT NULL,
    [CreatedByUserID] INT           NOT NULL,
    [CreatedDate]     SMALLDATETIME NOT NULL,
    CONSTRAINT [PK_Drivers_1] PRIMARY KEY CLUSTERED ([DriverID] ASC),
    CONSTRAINT [FK_Drivers_People] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[People] ([PersonID]),
    CONSTRAINT [FK_Drivers_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);

