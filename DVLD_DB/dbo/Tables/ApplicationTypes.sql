CREATE TABLE [dbo].[ApplicationTypes] (
    [ApplicationTypeID]    INT            IDENTITY (1, 1) NOT NULL,
    [ApplicationTypeTitle] NVARCHAR (150) NOT NULL,
    [ApplicationFees]      SMALLMONEY     CONSTRAINT [DF_ApplicationTypes_Fees] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ApplicationTypes] PRIMARY KEY CLUSTERED ([ApplicationTypeID] ASC)
);

