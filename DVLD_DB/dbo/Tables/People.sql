CREATE TABLE [dbo].[People] (
    [PersonID]             INT            IDENTITY (1, 1) NOT NULL,
    [NationalNo]           NVARCHAR (20)  NOT NULL,
    [FirstName]            NVARCHAR (20)  NOT NULL,
    [SecondName]           NVARCHAR (20)  NOT NULL,
    [ThirdName]            NVARCHAR (20)  NULL,
    [LastName]             NVARCHAR (20)  NOT NULL,
    [DateOfBirth]          DATETIME       NOT NULL,
    [Gendor]               TINYINT        CONSTRAINT [DF_People_Gendor] DEFAULT ((0)) NOT NULL,
    [Address]              NVARCHAR (500) NOT NULL,
    [Phone]                NVARCHAR (20)  NOT NULL,
    [Email]                NVARCHAR (50)  NULL,
    [NationalityCountryID] INT            NOT NULL,
    [ImagePath]            NVARCHAR (250) NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([PersonID] ASC),
    CONSTRAINT [FK_People_Countries1] FOREIGN KEY ([NationalityCountryID]) REFERENCES [dbo].[Countries] ([CountryID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0 Male , 1 Femail', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'People', @level2type = N'COLUMN', @level2name = N'Gendor';

