CREATE TABLE [dbo].[Tests] (
    [TestID]            INT            IDENTITY (1, 1) NOT NULL,
    [TestAppointmentID] INT            NOT NULL,
    [TestResult]        BIT            NOT NULL,
    [Notes]             NVARCHAR (500) NULL,
    [CreatedByUserID]   INT            NOT NULL,
    CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED ([TestID] ASC),
    CONSTRAINT [FK_Tests_TestAppointments] FOREIGN KEY ([TestAppointmentID]) REFERENCES [dbo].[TestAppointments] ([TestAppointmentID]),
    CONSTRAINT [FK_Tests_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0 - Fail 1-Pass', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tests', @level2type = N'COLUMN', @level2name = N'TestResult';

