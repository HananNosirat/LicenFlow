CREATE TABLE [dbo].[InternationalLicenses] (
    [InternationalLicenseID]    INT           IDENTITY (1, 1) NOT NULL,
    [ApplicationID]             INT           NOT NULL,
    [DriverID]                  INT           NOT NULL,
    [IssuedUsingLocalLicenseID] INT           NOT NULL,
    [IssueDate]                 SMALLDATETIME NOT NULL,
    [ExpirationDate]            SMALLDATETIME NOT NULL,
    [IsActive]                  BIT           NOT NULL,
    [CreatedByUserID]           INT           NOT NULL,
    CONSTRAINT [PK_InternationalLicenses] PRIMARY KEY CLUSTERED ([InternationalLicenseID] ASC),
    CONSTRAINT [FK_InternationalLicenses_Applications] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[Applications] ([ApplicationID]),
    CONSTRAINT [FK_InternationalLicenses_Drivers] FOREIGN KEY ([DriverID]) REFERENCES [dbo].[Drivers] ([DriverID]),
    CONSTRAINT [FK_InternationalLicenses_Licenses] FOREIGN KEY ([IssuedUsingLocalLicenseID]) REFERENCES [dbo].[Licenses] ([LicenseID]),
    CONSTRAINT [FK_InternationalLicenses_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);

