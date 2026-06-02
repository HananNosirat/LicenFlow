CREATE TABLE [dbo].[TestTypes] (
    [TestTypeID]          INT            IDENTITY (1, 1) NOT NULL,
    [TestTypeTitle]       NVARCHAR (100) NOT NULL,
    [TestTypeDescription] NVARCHAR (500) NOT NULL,
    [TestTypeFees]        SMALLMONEY     NOT NULL,
    CONSTRAINT [PK_TestTypes] PRIMARY KEY CLUSTERED ([TestTypeID] ASC)
);

