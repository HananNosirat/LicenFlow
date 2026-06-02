CREATE TABLE [dbo].[LicenseClasses] (
    [LicenseClassID]        INT            IDENTITY (1, 1) NOT NULL,
    [ClassName]             NVARCHAR (50)  NOT NULL,
    [ClassDescription]      NVARCHAR (500) NOT NULL,
    [MinimumAllowedAge]     TINYINT        CONSTRAINT [DF_LicenseClasses_Age] DEFAULT ((18)) NOT NULL,
    [DefaultValidityLength] TINYINT        CONSTRAINT [DF_LicenseClasses_DefaultPeriodLength] DEFAULT ((1)) NOT NULL,
    [ClassFees]             SMALLMONEY     CONSTRAINT [DF_LicenseClasses_ClassFees] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_LicenseClasses] PRIMARY KEY CLUSTERED ([LicenseClassID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Minmum age allowed to apply for this license', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseClasses', @level2type = N'COLUMN', @level2name = N'MinimumAllowedAge';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'How many years the licesnse will be valid.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseClasses', @level2type = N'COLUMN', @level2name = N'DefaultValidityLength';

