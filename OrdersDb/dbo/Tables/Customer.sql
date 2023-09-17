CREATE TABLE [dbo].[Customer] (
    [Id]  INT      IDENTITY(1, 1) NOT NULL,
    [FirstName]    VARCHAR (100) NULL,
    [LastName]     VARCHAR (100) NULL,
    [PhoneNumber] VARCHAR (10) NULL,
    [EmailAddress] VARCHAR (100) NULL,
    [AnnualIncome] DECIMAL(19, 2) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

