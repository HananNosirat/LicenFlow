CREATE TABLE [dbo].[Licenses] (
    [LicenseID]       INT            IDENTITY (1, 1) NOT NULL,
    [ApplicationID]   INT            NOT NULL,
    [DriverID]        INT            NOT NULL,
    [LicenseClass]    INT            NOT NULL,
    [IssueDate]       DATETIME       NOT NULL,
    [ExpirationDate]  DATETIME       NOT NULL,
    [Notes]           NVARCHAR (500) NULL,
    [PaidFees]        SMALLMONEY     NOT NULL,
    [IsActive]        BIT            CONSTRAINT [DF_Licenses_IsActive] DEFAULT ((1)) NOT NULL,
    [IssueReason]     TINYINT        CONSTRAINT [DF_Licenses_IssueReason] DEFAULT ((1)) NOT NULL,
    [CreatedByUserID] INT            NOT NULL,
    CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED ([LicenseID] ASC),
    CONSTRAINT [FK_Licenses_Applications] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[Applications] ([ApplicationID]),
    CONSTRAINT [FK_Licenses_Drivers] FOREIGN KEY ([DriverID]) REFERENCES [dbo].[Drivers] ([DriverID]),
    CONSTRAINT [FK_Licenses_LicenseClasses] FOREIGN KEY ([LicenseClass]) REFERENCES [dbo].[LicenseClasses] ([LicenseClassID]),
    CONSTRAINT [FK_Licenses_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Licenses', @level2type = N'COLUMN', @level2name = N'IssueReason';

