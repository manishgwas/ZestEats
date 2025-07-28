-- Order table schema for SQL Server
CREATE TABLE [dbo].[Orders] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [UserId] NVARCHAR(100) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [PaymentId] NVARCHAR(100) NULL,
    [DeliveryId] NVARCHAR(100) NULL,
    [IdempotencyKey] NVARCHAR(100) NULL
);

CREATE TABLE [dbo].[OrderItems] (
    [OrderId] UNIQUEIDENTIFIER NOT NULL,
    [MenuItemId] NVARCHAR(100) NOT NULL,
    [Quantity] INT NOT NULL,
    [Price] FLOAT NOT NULL,
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);
