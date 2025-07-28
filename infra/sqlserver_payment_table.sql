-- Payment table schema for SQL Server
CREATE TABLE [dbo].[Payments] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [OrderId] NVARCHAR(100) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [RazorpayPaymentId] NVARCHAR(100) NULL,
    [IdempotencyKey] NVARCHAR(100) NULL
);
