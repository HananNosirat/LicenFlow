CREATE TABLE [dbo].[Applications] (
    [ApplicationID]     INT        IDENTITY (1, 1) NOT NULL,
    [ApplicantPersonID] INT        NOT NULL,
    [ApplicationDate]   DATETIME   NOT NULL,
    [ApplicationTypeID] INT        NOT NULL,
    [ApplicationStatus] TINYINT    CONSTRAINT [DF_Applications_ApplicationStatus] DEFAULT ((1)) NOT NULL,
    [LastStatusDate]    DATETIME   NOT NULL,
    [PaidFees]          SMALLMONEY NOT NULL,
    [CreatedByUserID]   INT        NOT NULL,
    CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED ([ApplicationID] ASC),
    CONSTRAINT [FK_Applications_ApplicationTypes] FOREIGN KEY ([ApplicationTypeID]) REFERENCES [dbo].[ApplicationTypes] ([ApplicationTypeID]),
    CONSTRAINT [FK_Applications_People] FOREIGN KEY ([ApplicantPersonID]) REFERENCES [dbo].[People] ([PersonID]),
    CONSTRAINT [FK_Applications_Users] FOREIGN KEY ([CreatedByUserID]) REFERENCES [dbo].[Users] ([UserID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1-New 2-Cancelled 3-Completed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications', @level2type = N'COLUMN', @level2name = N'ApplicationStatus';

