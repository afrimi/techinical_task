USE [PSIT]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Addresses]
    GO
DROP TABLE [dbo].[Employees]
    GO
DROP TABLE [dbo].[Addresses]
    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Addresses](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [City] [nvarchar](50) NOT NULL,
    [Country] [nvarchar](50) NOT NULL,
    [Address] [nvarchar](60) NOT NULL,
    [PostCode] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]


DROP TABLE [dbo].[Positions]
    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Positions](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Employees](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Age] [int] NOT NULL,
    [AddressId] [int] NOT NULL,
    [PositionId] [int] NOT NULL,
    [SigningTimeUtc] [datetime] NOT NULL DEFAULT GETUTCDATE(),
    [LeavingTimeUtc] [datetime] NULL,
    [IsActive] [bit] NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET IDENTITY_INSERT [dbo].[Addresses] ON

    INSERT [dbo].[Addresses] ([Id], [City], [Country], [Address], [PostCode]) VALUES (1, N'Boston', N'United States', N'1 Main St, Boston, MA 02129, USA', N'02129')
    INSERT [dbo].[Addresses] ([Id], [City], [Country], [Address], [PostCode]) VALUES (2, N'Brookline', N'United States', N'21 Warwick Rd, Brookline, MA 02445, USA', N'02445')
    INSERT [dbo].[Addresses] ([Id], [City], [Country], [Address], [PostCode]) VALUES (3, N'Prishtine', N'Kosova', N'35 Gezim Redenica, Prishtine, Kosova 10000', N'10000')
    INSERT [dbo].[Addresses] ([Id], [City], [Country], [Address], [PostCode]) VALUES (4, N'Tirane', N'Albania', N'Pashko Vasa, Tirane, Albania 45000', N'45000')
    SET IDENTITY_INSERT [dbo].[Addresses] OFF

    SET IDENTITY_INSERT [dbo].[Positions] ON

    INSERT [dbo].[Positions] ([Id], [Name]) VALUES (1, N'Developer')
    INSERT [dbo].[Positions] ([Id], [Name]) VALUES (2, N'Designer')
    INSERT [dbo].[Positions] ([Id], [Name]) VALUES (3, N'Sales')
    INSERT [dbo].[Positions] ([Id], [Name]) VALUES (4, N'Customer Support')
    INSERT [dbo].[Positions] ([Id], [Name]) VALUES (5, N'Marketing')
    INSERT [dbo].[Positions] ([Id], [Name]) VALUES (6, N'Product Owner')
    SET IDENTITY_INSERT [dbo].[Positions] OFF

    SET IDENTITY_INSERT [dbo].[Employees] ON

    INSERT [dbo].[Employees] ([Id], [Name], [Age], [AddressId], [PositionId], [SigningTimeUtc], [LeavingTimeUtc], [IsActive]) VALUES (1, N'John Doe', 26, 1, 1, GETUTCDATE(), NULL, 1)
    INSERT [dbo].[Employees] ([Id], [Name], [Age], [AddressId], [PositionId], [SigningTimeUtc], [LeavingTimeUtc], [IsActive]) VALUES (2, N'Kane Miller', 35, 2, 2, GETUTCDATE(), NULL, 1)
    INSERT [dbo].[Employees] ([Id], [Name], [Age], [AddressId], [PositionId], [SigningTimeUtc], [LeavingTimeUtc], [IsActive]) VALUES (3, N'Jana McLeaf', 30, 1, 2, GETUTCDATE(), NULL, 1)
    INSERT [dbo].[Employees] ([Id], [Name], [Age], [AddressId], [PositionId], [SigningTimeUtc], [LeavingTimeUtc], [IsActive]) VALUES (4, N'Afrim Arifi', 31, 1, 3, GETUTCDATE(), NULL, 1)
    INSERT [dbo].[Employees] ([Id], [Name], [Age], [AddressId], [PositionId], [SigningTimeUtc], [LeavingTimeUtc], [IsActive]) VALUES (5, N'Roy Kean', 21, 2, 5, GETUTCDATE(), NULL, 1)
    SET IDENTITY_INSERT [dbo].[Employees] OFF

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD CONSTRAINT [FK_Employees_Addresses] FOREIGN KEY([AddressId])
    REFERENCES [dbo].[Addresses] ([Id])
    GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Addresses]
    GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD CONSTRAINT [FK_Employees_Positions] FOREIGN KEY([PositionId])
    REFERENCES [dbo].[Positions] ([Id])
    GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions]
    GO

CREATE NONCLUSTERED INDEX [IX_Employees_AddressId] ON [dbo].[Employees]
(
	[AddressId]
)
GO

CREATE NONCLUSTERED INDEX [IX_Employees_PositionId] ON [dbo].[Employees]
(
	[PositionId]
)
GO

CREATE NONCLUSTERED INDEX [IX_Employees_Name] ON [dbo].[Employees]
(
	[Name]
)
GO