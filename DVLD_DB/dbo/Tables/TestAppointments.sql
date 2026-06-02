CREATE TABLE [dbo].[TestAppointments] (
    [TestAppointmentID]                INT           IDENTITY (1, 1) NOT NULL,
    [TestTypeID]                       INT           NOT NULL,
    [LocalDrivingLicenseApplicationID] INT           NOT NULL,
    [AppointmentDate]                  SMALLDATETIME NOT NULL,
    [PaidFees]                         SMALLMONEY    NOT NULL,
    [CreatedByUserID]                  INT           NOT NULL,
    [IsLocked]                         BIT           CONSTRAINT [DF_TestAppointments_AppointmentLocked] DEFAULT ((0)) NOT NULL,
    [RetakeTestApplicationID]          INT           NULL,
    CONSTRAINT [PK_TestAppointments] PRIMARY KEY CLUSTERED ([TestAppointmentID] ASC),
    CONSTRAINT [FK_TestAppointments_Applications] FOREIGN KEY ([RetakeTestApplicationID]) REFERENCES [dbo].[Applications] ([ApplicationID]),
    CONSTRAINT [FK_TestAppointments_LocalDrivingLicenseApplications] FOREIGN KEY ([LocalDrivingLicenseApplicationID]) REFERENCES [dbo].[LocalDrivingLicenseApplications] ([LocalDrivingLicenseApplicationID]),
    CONSTRAINT [FK_TestAppointments_TestTypes] FOREIGN KEY ([TestTypeID]) REFERENCES [dbo].[TestTypes] ([TestTypeID]),
    CONSTRAINT [FK_TestAppointments_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);

