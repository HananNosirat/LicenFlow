CREATE TABLE [dbo].[LocalDrivingLicenseApplications] (
    [LocalDrivingLicenseApplicationID] INT IDENTITY (1, 1) NOT NULL,
    [ApplicationID]                    INT NOT NULL,
    [LicenseClassID]                   INT NOT NULL,
    CONSTRAINT [PK_DrivingLicsenseApplications] PRIMARY KEY CLUSTERED ([LocalDrivingLicenseApplicationID] ASC),
    CONSTRAINT [FK_DrivingLicsenseApplications_Applications] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[Applications] ([ApplicationID]),
    CONSTRAINT [FK_DrivingLicsenseApplications_LicenseClasses] FOREIGN KEY ([LicenseClassID]) REFERENCES [dbo].[LicenseClasses] ([LicenseClassID])
);

