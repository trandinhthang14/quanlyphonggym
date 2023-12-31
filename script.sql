USE [FitnessDB]
GO
/****** Object:  Table [dbo].[CoachsTbl]    Script Date: 7/1/2023 9:25:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoachsTbl](
	[CId] [int] IDENTITY(1,1) NOT NULL,
	[CName] [nvarchar](50) NOT NULL,
	[CGen] [nvarchar](10) NOT NULL,
	[CDOB] [date] NOT NULL,
	[CPhone] [varchar](50) NOT NULL,
	[CExperience] [int] NOT NULL,
	[CAddress] [nvarchar](150) NOT NULL,
	[IdC] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinanceTbl]    Script Date: 7/1/2023 9:25:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinanceTbl](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[Agent] [int] NOT NULL,
	[Member] [int] NOT NULL,
	[BPeriod] [varchar](50) NOT NULL,
	[BDate] [date] NOT NULL,
	[BAmount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembershipsTbl]    Script Date: 7/1/2023 9:25:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipsTbl](
	[MShipId] [int] IDENTITY(1,1) NOT NULL,
	[MName] [nvarchar](50) NOT NULL,
	[MDuration] [int] NOT NULL,
	[MGoal] [varchar](50) NOT NULL,
	[MCost] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MShipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembersTbl]    Script Date: 7/1/2023 9:25:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembersTbl](
	[MId] [int] IDENTITY(1,1) NOT NULL,
	[MName] [varchar](50) NOT NULL,
	[MGen] [varchar](10) NOT NULL,
	[MDOB] [date] NOT NULL,
	[MDate] [date] NOT NULL,
	[MMembership] [int] NOT NULL,
	[MCoach] [int] NOT NULL,
	[MPhone] [varchar](11) NOT NULL,
	[MTiming] [varchar](50) NOT NULL,
	[MStatus] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceptionistTbl]    Script Date: 7/1/2023 9:25:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceptionistTbl](
	[ReceptId] [int] IDENTITY(1,1) NOT NULL,
	[RecepName] [varchar](50) NOT NULL,
	[Recepgen] [varchar](50) NOT NULL,
	[RecepDOB] [date] NOT NULL,
	[RecepAdd] [varchar](50) NOT NULL,
	[RecepPhone] [varchar](11) NOT NULL,
	[RecepPass] [nchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CoachsTbl] ON 

INSERT [dbo].[CoachsTbl] ([CId], [CName], [CGen], [CDOB], [CPhone], [CExperience], [CAddress], [IdC]) VALUES (5, N'Tran Trung', N'Nam', CAST(N'1994-06-28' AS Date), N'098888853', 5, N'Nam Ninh', N'6778294828')
INSERT [dbo].[CoachsTbl] ([CId], [CName], [CGen], [CDOB], [CPhone], [CExperience], [CAddress], [IdC]) VALUES (6, N'Tran Trung', N'Nam', CAST(N'1994-06-28' AS Date), N'098888853', 5, N'Nam Dinh', N'6778294830')
INSERT [dbo].[CoachsTbl] ([CId], [CName], [CGen], [CDOB], [CPhone], [CExperience], [CAddress], [IdC]) VALUES (7, N'Pham Hung', N'Nam', CAST(N'1990-02-06' AS Date), N'0988888827', 5, N'Ha Noi', N'9872949248')
SET IDENTITY_INSERT [dbo].[CoachsTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[FinanceTbl] ON 

INSERT [dbo].[FinanceTbl] ([BillId], [Agent], [Member], [BPeriod], [BDate], [BAmount]) VALUES (3, 1, 1, N'8-2023', CAST(N'2023-05-24' AS Date), 15000)
INSERT [dbo].[FinanceTbl] ([BillId], [Agent], [Member], [BPeriod], [BDate], [BAmount]) VALUES (4, 1, 3, N'7-2023', CAST(N'2023-05-24' AS Date), 30000)
SET IDENTITY_INSERT [dbo].[FinanceTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[MembershipsTbl] ON 

INSERT [dbo].[MembershipsTbl] ([MShipId], [MName], [MDuration], [MGoal], [MCost]) VALUES (2, N'Goi Bac', 4, N'Giam 5 kg', 15000)
INSERT [dbo].[MembershipsTbl] ([MShipId], [MName], [MDuration], [MGoal], [MCost]) VALUES (3, N'Goi Vang', 3, N'Giam 10 kg', 25000)
INSERT [dbo].[MembershipsTbl] ([MShipId], [MName], [MDuration], [MGoal], [MCost]) VALUES (4, N'Goi Bach Kim', 2, N'Giam 15 Kg', 30000)
SET IDENTITY_INSERT [dbo].[MembershipsTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[MembersTbl] ON 

INSERT [dbo].[MembersTbl] ([MId], [MName], [MGen], [MDOB], [MDate], [MMembership], [MCoach], [MPhone], [MTiming], [MStatus]) VALUES (1, N'Van Tung', N'Nam', CAST(N'2001-03-01' AS Date), CAST(N'2023-05-24' AS Date), 2, 5, N'093985938', N'10AM-12AM', N'Pending')
INSERT [dbo].[MembersTbl] ([MId], [MName], [MGen], [MDOB], [MDate], [MMembership], [MCoach], [MPhone], [MTiming], [MStatus]) VALUES (3, N'Co Huong', N'N?', CAST(N'1994-06-07' AS Date), CAST(N'2023-05-24' AS Date), 4, 7, N'098738278', N'8AM-10AM', N'Pending')
SET IDENTITY_INSERT [dbo].[MembersTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ReceptionistTbl] ON 

INSERT [dbo].[ReceptionistTbl] ([ReceptId], [RecepName], [Recepgen], [RecepDOB], [RecepAdd], [RecepPhone], [RecepPass]) VALUES (1, N'TranThang', N'Nam', CAST(N'2023-04-07' AS Date), N'Nam Dinh', N'095556224', N'tranthang ')
SET IDENTITY_INSERT [dbo].[ReceptionistTbl] OFF
GO
ALTER TABLE [dbo].[FinanceTbl]  WITH CHECK ADD  CONSTRAINT [FK_FinanceTbl_ToTable] FOREIGN KEY([Agent])
REFERENCES [dbo].[ReceptionistTbl] ([ReceptId])
GO
ALTER TABLE [dbo].[FinanceTbl] CHECK CONSTRAINT [FK_FinanceTbl_ToTable]
GO
ALTER TABLE [dbo].[FinanceTbl]  WITH CHECK ADD  CONSTRAINT [FK_FinanceTbl_ToTable_1] FOREIGN KEY([Member])
REFERENCES [dbo].[MembersTbl] ([MId])
GO
ALTER TABLE [dbo].[FinanceTbl] CHECK CONSTRAINT [FK_FinanceTbl_ToTable_1]
GO
ALTER TABLE [dbo].[MembersTbl]  WITH CHECK ADD  CONSTRAINT [FK_MembersTbl_ToTable] FOREIGN KEY([MMembership])
REFERENCES [dbo].[MembershipsTbl] ([MShipId])
GO
ALTER TABLE [dbo].[MembersTbl] CHECK CONSTRAINT [FK_MembersTbl_ToTable]
GO
ALTER TABLE [dbo].[MembersTbl]  WITH CHECK ADD  CONSTRAINT [FK_MembersTbl_ToTable_1] FOREIGN KEY([MCoach])
REFERENCES [dbo].[CoachsTbl] ([CId])
GO
ALTER TABLE [dbo].[MembersTbl] CHECK CONSTRAINT [FK_MembersTbl_ToTable_1]
GO
