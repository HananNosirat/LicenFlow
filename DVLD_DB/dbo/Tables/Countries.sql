CREATE TABLE [dbo].[Countries] (
    [CountryID]   INT           IDENTITY (1, 1) NOT NULL,
    [CountryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK__Countrie__10D160BFDBD6933F] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);

