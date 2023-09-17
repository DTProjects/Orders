CREATE TABLE [dbo].[Order] (
    [Id]   INT IDENTITY(1,1) NOT NULL,
    [OrderNumber] VARCHAR(100) NOT NULL,
    [CustomerId]   INT NOT NULL,
    [Quantity] DECIMAL(9,2) DEFAULT(0) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UC_OrderNumber] UNIQUE (OrderNumber),
    CONSTRAINT [FK_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

