CREATE TABLE [dbo].[Users] (
    [Id]       INT   NOT NULL,
    [UserRole] VARCHAR (10) NOT NULL,
    [Password] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([UserRole]='admin' OR [UserRole]='deposito')
);

CREATE TABLE [dbo].[Products] (
    [Id]            VARCHAR (20) NOT NULL,
    [ProductName]   VARCHAR (50) NOT NULL,
    [ProductWeight] DECIMAL (18) NOT NULL,
    [ClientTin]     BIGINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Products__Client__70DDC3D8] FOREIGN KEY ([ClientTin]) REFERENCES [dbo].[Clients] ([Tin])
);

CREATE TABLE [dbo].[Imports] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [ProductId]     VARCHAR (20) NOT NULL,
    [Tin]           BIGINT       NOT NULL,
    [PriceByUnit]   DECIMAL (18) NOT NULL,
    [Ammount]       INT          NOT NULL,
    [EntryDate]     DATE         NOT NULL,
    [DepartureDate] DATE         NOT NULL,
    [IsStored]      BIT          CONSTRAINT [DF_Imports_IsStored] DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK__Imports__Tin__5AEE82B9] FOREIGN KEY ([Tin]) REFERENCES [dbo].[Clients] ([Tin])
);

CREATE TABLE [dbo].[Clients] (
    [Tin]          BIGINT        NOT NULL,
    [ClientName]   NVARCHAR (50) NOT NULL,
    [Discount]     INT           NOT NULL,
    [Seniority]    INT           NOT NULL,
    [RegisterDate] DATE          NOT NULL,
    CONSTRAINT [PK__Clients__C451DB077566F103] PRIMARY KEY CLUSTERED ([Tin] ASC),
    UNIQUE NONCLUSTERED ([Tin] ASC)
);