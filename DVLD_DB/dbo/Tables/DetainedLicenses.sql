CREATE TABLE [dbo].[DetainedLicenses] (
    [DetainID]             INT           IDENTITY (1, 1) NOT NULL,
    [LicenseID]            INT           NOT NULL,
    [DetainDate]           SMALLDATETIME NOT NULL,
    [FineFees]             SMALLMONEY    NOT NULL,
    [CreatedByUserID]      INT           NOT NULL,
    [IsReleased]           BIT           CONSTRAINT [DF_DetainedLicenses_IsReleased] DEFAULT ((0)) NOT NULL,
    [ReleaseDate]          SMALLDATETIME NULL,
    [ReleasedByUserID]     INT           NULL,
    [ReleaseApplicationID] INT           NULL,
    CONSTRAINT [PK_DetainedLicenses] PRIMARY KEY CLUSTERED ([DetainID] ASC),
    CONSTRAINT [FK_DetainedLicenses_Applications] FOREIGN KEY ([ReleaseApplicationID]) REFERENCES [dbo].[Applications] ([ApplicationID]),
    CONSTRAINT [FK_DetainedLicenses_Licenses] FOREIGN KEY ([LicenseID]) REFERENCES [dbo].[Licenses] ([LicenseID]),
    CONSTRAINT [FK_DetainedLicenses_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [FK_DetainedLicenses_Users1] FOREIGN KEY ([ReleasedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);

