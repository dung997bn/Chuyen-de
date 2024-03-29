USE [QuanLyDangKyPhongHopNeu]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[HoTen] [nvarchar](128) NULL,
	[DiaChi] [nvarchar](128) NULL,
	[SDT] [varchar](128) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhuNha]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuNha](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhuNha] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.KhuNha] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LanhDao]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanhDao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](128) NULL,
	[ChucVu] [nvarchar](128) NULL,
	[Email] [nvarchar](128) NULL,
	[DonViCongTac] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LanhDao] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichDangKy]    Script Date: 2/18/2020 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LichDangKy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](256) NULL,
	[IDPhong] [int] NOT NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
	[NgayDangKy] [datetime] NOT NULL,
	[TenNguoiDangKy] [nvarchar](128) NULL,
	[Email] [nvarchar](128) NULL,
	[SoDienThoai] [varchar](128) NULL,
	[TinhTrang] [nvarchar](128) NULL,
	[ThanhPhan] [nvarchar](max) NULL,
	[IdLanhDao] [int] NOT NULL,
	[NoiDungCuocHop] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LichDangKy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LichThietBi]    Script Date: 2/18/2020 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichThietBi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDLichDangKy] [int] NULL,
	[IDThietBi] [int] NULL,
	[SoLuongThue] [int] NULL,
	[TinhTrang] [nvarchar](128) NULL,
	[NguoiThue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LichThietBi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 2/18/2020 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiPhong] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mails]    Script Date: 2/18/2020 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenMail] [nvarchar](128) NULL,
	[ValueOfMail] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Mails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phong]    Script Date: 2/18/2020 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](128) NULL,
	[IDKhuNha] [int] NOT NULL,
	[IDLoaiPhong] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Phong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThietBi]    Script Date: 2/18/2020 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThietBi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenThietBi] [nvarchar](128) NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ThietBi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'Ad', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'Rp', N'Report')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'389b0061-c1ed-4726-aea9-83af809404c0', N'Ad')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a679d4de-f283-46b3-8b2e-ce03d9d7e2ae', N'Ad')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c7724404-91bb-462b-9c82-613f19a4501d', N'Ad')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'389b0061-c1ed-4726-aea9-83af809404c0', N'Rp')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a679d4de-f283-46b3-8b2e-ce03d9d7e2ae', N'Rp')
INSERT [dbo].[AspNetUsers] ([Id], [HoTen], [DiaChi], [SDT], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1178479e-dab0-4278-a4cd-e7e986a1fe58', N'Dương Kirin', N'Hà nội', NULL, N'drm1997bn@gmail.com', 1, N'AATKA0YeIzOE56QSR+GiaQT1yPnHzMTAFG8QOc0e5MlQ6SVxYk6aqaxEzmfZBsltIg==', N'a73ae483-e9e6-40e9-bfc0-434582bea110', NULL, 0, 0, NULL, 0, 0, N'dung998bn')
INSERT [dbo].[AspNetUsers] ([Id], [HoTen], [DiaChi], [SDT], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'389b0061-c1ed-4726-aea9-83af809404c0', N'Nguyễn Xuân Dũng', N'Bắc Ninh', N'0964195598', N'phaichisophan@gmail.com', 1, N'AGB6ysEgRx9uBtQ4VRQleRUfqewLv8v0zHageseZkmBzo2tsstw/QJ1Jepvb7lW0tw==', N'4bcab946-89d5-44cd-9213-adc55acbfa2c', NULL, 0, 0, NULL, 0, 0, N'dung997bn')
INSERT [dbo].[AspNetUsers] ([Id], [HoTen], [DiaChi], [SDT], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a679d4de-f283-46b3-8b2e-ce03d9d7e2ae', N'Phạm Minh Hoàn', N'Viện Công nghệ thông tin và Kinh tế số', N'0949263666', N'hoanpm@neu.edu.vn', 1, N'AFHjvs/kMi3Mu7tPmRCGgZcGb+t9LQ5sWJYaIwXg4QnVoUBrcfhLsClA47x07Ij1NA==', N'29b075e6-08e5-4ee0-87a5-95b90f507ef0', NULL, 0, 0, NULL, 0, 0, N'hoanpm')
INSERT [dbo].[AspNetUsers] ([Id], [HoTen], [DiaChi], [SDT], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c7724404-91bb-462b-9c82-613f19a4501d', N'Dương Kirin', N'Bắc Ninh', NULL, N'11150961@st.neu.edu.vn', 1, N'AJuHBCIXbsmlcBPhogBFTDFL/oWftdYsYFvWoYEiXuuXEX/bineuW0rmoxbVGCcTLQ==', N'0a1fd5c9-40f0-4bef-bf43-690a34806035', NULL, 0, 0, NULL, 0, 0, N'11152203@st.neu.edu.vn')
INSERT [dbo].[AspNetUsers] ([Id], [HoTen], [DiaChi], [SDT], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd90995f0-c945-4c0d-bd5f-e8ab744b657d', N'Dương Kirin', N'Bắc Ninh', N'0964195598', N'ashton@gmail.com', 1, N'AM/94Brpeivs/O0bBfmOqCzvvKGe9YW+ejWbA+dei9IMFJYehslHVyD+M/WFdahi0w==', N'687ecbd9-6ff5-4240-9933-cc7938d3c374', NULL, 0, 0, NULL, 0, 0, N'ashtoncox')
SET IDENTITY_INSERT [dbo].[KhuNha] ON 

INSERT [dbo].[KhuNha] ([ID], [TenKhuNha]) VALUES (1, N'Tầng 5 Nhà A1')
INSERT [dbo].[KhuNha] ([ID], [TenKhuNha]) VALUES (2, N'Tầng G Nhà A1')
INSERT [dbo].[KhuNha] ([ID], [TenKhuNha]) VALUES (3, N'Tầng 10 Nhà A2')
INSERT [dbo].[KhuNha] ([ID], [TenKhuNha]) VALUES (4, N'Tầng hầm B1')
INSERT [dbo].[KhuNha] ([ID], [TenKhuNha]) VALUES (5, N'Tầng hầm B2')
SET IDENTITY_INSERT [dbo].[KhuNha] OFF
SET IDENTITY_INSERT [dbo].[LanhDao] ON 

INSERT [dbo].[LanhDao] ([ID], [HoTen], [ChucVu], [Email], [DonViCongTac]) VALUES (2, N'GS.TS Trần Thọ Đạt', N'Bí thư Đảng ủy', N'a@gmail.com', N'Đảng ủy')
INSERT [dbo].[LanhDao] ([ID], [HoTen], [ChucVu], [Email], [DonViCongTac]) VALUES (3, N'PGS.TS Phạm Hồng Chương', N'Hiệu trưởng', N'b@gmail.com', N'Ban Giám hiệu')
INSERT [dbo].[LanhDao] ([ID], [HoTen], [ChucVu], [Email], [DonViCongTac]) VALUES (4, N'PGS.TS Hoàng Văn Cường', N'Phó Hiệu trưởng', N'c@gmail.com', N'Ban Giám hiệu')
INSERT [dbo].[LanhDao] ([ID], [HoTen], [ChucVu], [Email], [DonViCongTac]) VALUES (46, N'TS Nguyễn Trung Tuấn', N'Viện trưởng', N'a@gmail.com', N'Viện CNTT & KTS')
INSERT [dbo].[LanhDao] ([ID], [HoTen], [ChucVu], [Email], [DonViCongTac]) VALUES (47, N'PGS. TS Trần Thị Vân Hoa', N'Phó Hiệu trưởng', N'd@gmail.com', N'Ban Giám hiệu')
INSERT [dbo].[LanhDao] ([ID], [HoTen], [ChucVu], [Email], [DonViCongTac]) VALUES (48, N'PGS.TS Bùi Đức Thọ', N'Phó Hiệu trưởng', N'bdt@gmail.com', N'Ban Giám hiệu')
SET IDENTITY_INSERT [dbo].[LanhDao] OFF
SET IDENTITY_INSERT [dbo].[LichDangKy] ON 

INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (80, N'dungdung', 4, CAST(N'2019-04-07 13:30:00.000' AS DateTime), CAST(N'2019-04-07 17:00:00.000' AS DateTime), CAST(N'2019-04-07 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'5435435345', N'Đã chấp nhận', N'rew', 4, N'Họp hội đồng')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (120, N'hyhy', 3, CAST(N'2019-05-29 13:00:00.000' AS DateTime), CAST(N'2019-05-29 13:30:00.000' AS DateTime), CAST(N'2019-05-29 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đang chờ xử lý', N'11152208@st.neu.edu.vn', 2, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (121, N'dungdung', 4, CAST(N'2019-05-29 13:00:00.000' AS DateTime), CAST(N'2019-05-29 16:00:00.000' AS DateTime), CAST(N'2019-05-29 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chấp nhận', N'11150961@st.neu.edu.vn,11152208@st.neu.edu.vn,11152294@st.neu.edu.vn', 4, N'Họp báo cáo')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (122, N'hyhy', 3, CAST(N'2019-05-31 13:00:00.000' AS DateTime), CAST(N'2019-05-31 13:30:00.000' AS DateTime), CAST(N'2019-05-31 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đang chờ xử lý', N'11150961@st.neu.edu.vn', 2, N'Họp báo cáo')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (123, N'dungdung', 8, CAST(N'2019-05-31 07:00:00.000' AS DateTime), CAST(N'2019-05-31 11:30:00.000' AS DateTime), CAST(N'2019-05-31 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chấp nhận', N'11150961@st.neu.edu.vn', 2, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (124, N'dungdung', 4, CAST(N'2019-05-31 10:30:00.000' AS DateTime), CAST(N'2019-05-31 17:30:00.000' AS DateTime), CAST(N'2019-05-31 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11150961@st.neu.edu.vn,11152208@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (125, N'dungdung', 8, CAST(N'2019-05-31 13:30:00.000' AS DateTime), CAST(N'2019-05-31 17:00:00.000' AS DateTime), CAST(N'2019-05-31 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chấp nhận', N'11152208@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (126, N'Họp hội đồng', 10, CAST(N'2019-05-31 12:00:00.000' AS DateTime), CAST(N'2019-05-31 13:00:00.000' AS DateTime), CAST(N'2019-05-31 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11150961@st.neu.edu.vn,11152208@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (127, N'dungdung', 5, CAST(N'2019-05-31 07:00:00.000' AS DateTime), CAST(N'2019-05-31 09:30:00.000' AS DateTime), CAST(N'2019-05-31 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11152208@st.neu.edu.vn', 2, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (128, N'dungdung', 6, CAST(N'2019-06-02 07:00:00.000' AS DateTime), CAST(N'2019-06-02 08:30:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11150961@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (129, N'dungdung', 6, CAST(N'2019-06-02 09:00:00.000' AS DateTime), CAST(N'2019-06-02 11:30:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chấp nhận', N'11150961@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (130, N'dungdung', 6, CAST(N'2019-06-02 12:00:00.000' AS DateTime), CAST(N'2019-06-02 15:30:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chấp nhận', N'11150961@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (131, N'dungdung', 6, CAST(N'2019-06-02 15:30:00.000' AS DateTime), CAST(N'2019-06-02 18:00:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11152208@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (132, N'Họp hội đồng', 4, CAST(N'2019-06-02 18:00:00.000' AS DateTime), CAST(N'2019-06-02 19:30:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11152294@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (133, N'hyhy', 7, CAST(N'2019-06-02 19:30:00.000' AS DateTime), CAST(N'2019-06-02 21:30:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đang chờ xử lý', N'11152294@st.neu.edu.vn', 4, N'họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (134, N'Họp hội đồng', 9, CAST(N'2019-06-02 12:30:00.000' AS DateTime), CAST(N'2019-06-02 19:00:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đang chờ xử lý', N'11152294@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (135, N'hyhy', 3, CAST(N'2019-06-02 09:00:00.000' AS DateTime), CAST(N'2019-06-02 14:00:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đang chờ xử lý', N'11150961@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (136, N'dungdung', 8, CAST(N'2019-06-02 18:00:00.000' AS DateTime), CAST(N'2019-06-02 21:00:00.000' AS DateTime), CAST(N'2019-06-02 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đang chờ xử lý', N'11152208@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (137, N'dungdung', 2, CAST(N'2019-06-06 07:00:00.000' AS DateTime), CAST(N'2019-06-06 09:30:00.000' AS DateTime), CAST(N'2019-06-06 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu/edu.vn', N'0912946879', N'Đã chấp nhận', N'11150961@st.neu.edu.vn,11152208@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (138, N'Đăng ký phòng họp', 4, CAST(N'2019-06-11 13:00:00.000' AS DateTime), CAST(N'2019-06-11 14:00:00.000' AS DateTime), CAST(N'2019-06-11 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11152208@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (139, N'Đăng ký phòng họp', 5, CAST(N'2019-06-06 10:00:00.000' AS DateTime), CAST(N'2019-06-06 21:00:00.000' AS DateTime), CAST(N'2019-06-06 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11150961@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (140, N'Đăng ký phòng họp', 7, CAST(N'2019-06-09 09:00:00.000' AS DateTime), CAST(N'2019-06-09 15:00:00.000' AS DateTime), CAST(N'2019-06-09 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chuyển', N'11150961@st.neu.edu.vn', 2, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (142, N'Đăng ký phòng họp', 3, CAST(N'2019-06-17 10:00:00.000' AS DateTime), CAST(N'2019-06-17 10:30:00.000' AS DateTime), CAST(N'2019-06-17 00:00:00.000' AS DateTime), N'Nguyen Xuan Dung', N'11150961@st.neu.edu.vn', N'0912946879', N'Đã chấp nhận', N'11152208@st.neu.edu.vn,11152294@st.neu.edu.vn', 2, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (143, N'Đăng ký phòng họp', 10, CAST(N'2019-06-19 12:30:00.000' AS DateTime), CAST(N'2019-06-19 16:00:00.000' AS DateTime), CAST(N'2019-06-19 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đã chuyển', N'11152208@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (144, N'Viện CNTTKT chuẩn bị', 5, CAST(N'2019-06-22 14:00:00.000' AS DateTime), CAST(N'2019-06-22 16:00:00.000' AS DateTime), CAST(N'2019-06-22 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đã chấp nhận', N'11152208@st.neu.edu.vn,11152294@st.neu.edu.vn', 3, N'Họp hội đồng')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (145, N'Viện CNTTKT chuẩn bị', 5, CAST(N'2019-06-23 10:30:00.000' AS DateTime), CAST(N'2019-06-23 19:00:00.000' AS DateTime), CAST(N'2019-06-23 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đã chấp nhận', N'11152208@st.neu.edu.vn,11150961@st.neu.edu.vn', 4, N'Họp hội nghị')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (146, N'Viện CNTTKT chuẩn bị', 9, CAST(N'2019-06-23 15:30:00.000' AS DateTime), CAST(N'2019-06-23 18:00:00.000' AS DateTime), CAST(N'2019-06-23 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đã chuyển', N'11152208@st.neu.edu.vn,11152294@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (147, N'Viện CNTTKT chuẩn bị', 9, CAST(N'2019-06-23 15:00:00.000' AS DateTime), CAST(N'2019-06-23 18:00:00.000' AS DateTime), CAST(N'2019-06-23 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đang chờ xử lý', N'11152208@st.neu.edu.vn,11150961@st.neu.edu.vn', 4, N'Họp chuyên đề')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (148, N'Viện CNTTKT chuẩn bị', 5, CAST(N'2019-07-06 12:30:00.000' AS DateTime), CAST(N'2019-07-06 13:00:00.000' AS DateTime), CAST(N'2019-07-06 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đang chờ xử lý', N'11152208@st.neu.edu.vn', 2, N'Họp bàn giao công việc')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (149, N'Viện CNTTKT chuẩn bị', 3, CAST(N'2019-07-04 14:00:00.000' AS DateTime), CAST(N'2019-07-04 16:30:00.000' AS DateTime), CAST(N'2019-07-04 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đang chờ xử lý', N'11152294@st.neu.edu.vn', 4, N'Họp giao ban')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (150, N'Viện CNTTKT chuẩn bị', 4, CAST(N'2019-07-07 12:00:00.000' AS DateTime), CAST(N'2019-07-07 17:00:00.000' AS DateTime), CAST(N'2019-07-07 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đang chờ xử lý', N'11152208@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (151, N'Viện CNTTKT chuẩn bị', 6, CAST(N'2019-07-07 12:00:00.000' AS DateTime), CAST(N'2019-07-07 15:30:00.000' AS DateTime), CAST(N'2019-07-07 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'0912946879', N'Đang chờ xử lý', N'11152294@st.neu.edu.vn', 3, N'Họp đơn giản là họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (152, N'dungdung', 9, CAST(N'2019-07-07 07:00:00.000' AS DateTime), CAST(N'2019-07-07 09:30:00.000' AS DateTime), CAST(N'2019-07-07 00:00:00.000' AS DateTime), N'Dũng', N'11150961@st.neu/edu.vn', N'0912946879', N'Đã chấp nhận', N'11152208@st.neu.edu.vn', 4, N'Họp ')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (154, N'Họp hội đồng', 8, CAST(N'2019-07-07 10:00:00.000' AS DateTime), CAST(N'2019-07-07 09:00:00.000' AS DateTime), CAST(N'2019-07-07 00:00:00.000' AS DateTime), N'fsd', N'phaichisophan@gmail.com', N'0912946879', N'Đã chấp nhận', N'11152294@st.neu.edu.vn', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (155, N'Họp hội đồng', 2, CAST(N'2019-07-05 07:00:00.000' AS DateTime), CAST(N'2019-07-05 09:00:00.000' AS DateTime), CAST(N'2019-07-05 00:00:00.000' AS DateTime), N'Dũng', N'drm1997bn@gmail.com', N'5435435345', N'Đã chấp nhận', N'11152294@st.neu.edu.vn', 3, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (159, N'Viện CNTTKT chuẩn bị', 5, CAST(N'2019-07-09 11:30:00.000' AS DateTime), CAST(N'2019-07-09 16:00:00.000' AS DateTime), CAST(N'2019-07-09 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'5435435345', N'Đang chờ xử lý', N'11152294@st.neu.edu.vn', 3, N'Họp báo cáo')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (160, N'Họp giao ban Ban Giám hiệu.', 3, CAST(N'2019-07-12 08:00:00.000' AS DateTime), CAST(N'2019-07-12 09:00:00.000' AS DateTime), CAST(N'2019-07-12 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Ban Giám hiệu, cùng các đ/c: Đồng (Chủ tịch CĐ trường); Dũng (P.TH); Ngọc (P.TCCB).', 3, N'Họp giao ban Ban Giám hiệu.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (161, N'Họp giao ban tuần.', 3, CAST(N'2019-07-12 09:00:00.000' AS DateTime), CAST(N'2019-07-12 10:00:00.000' AS DateTime), CAST(N'2019-07-12 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Đ/c Đạt (Bí thư ĐU), Ban Giám hiệu, cùng các đ/c: Đồng (Chủ tịch CĐ Trường); Dũng (P.TH); Ngọc (P.TCCB); Triệu (P.QLĐT); Thành (P.QLKH); Tùng (P.HTQT); Dũng (P.TTPC); Chi (P.TCKT); Trung (P.QTTB); Nghĩa (P.TT).', 3, N'Họp giao ban tuần.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (162, N'Họp Hội đồng tuyển sinh đại học hệ chính quy khóa 61 năm 2019.', 3, CAST(N'2019-07-12 10:00:00.000' AS DateTime), CAST(N'2019-07-12 11:00:00.000' AS DateTime), CAST(N'2019-07-12 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Ban Giám hiệu, thành viên Hội đồng tuyển sinh theo Quyết định số 1046/QĐ-ĐHKTQD ngày 12/12/2018 của Hiệu trưởng.', 3, N'Họp Hội đồng tuyển sinh đại học hệ chính quy khóa 61 năm 2019.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (163, N'P.QLĐT chuẩn bị tài liệu', 2, CAST(N'2019-07-12 11:00:00.000' AS DateTime), CAST(N'2019-07-12 12:00:00.000' AS DateTime), CAST(N'2019-07-12 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), Đ/c Hoa (Phó Hiệu trưởng), cùng các đ/c: Triệu, Tạo, Đức, Bình, Cường, Sơn (P.QLĐT); Nghĩa (P.TT); Dũng, ....', 3, N'Họp chuẩn bị cho Lễ bế giảng và phát bằng tốt nghiệp Đại học chính quy cho sinh viên (đợt 2/2019).')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (164, N'P.QLĐT chuẩn bị tài liệu', 2, CAST(N'2019-07-12 14:00:00.000' AS DateTime), CAST(N'2019-07-12 15:00:00.000' AS DateTime), CAST(N'2019-07-12 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), Đ/c Hoa (Phó Hiệu trưởng), cùng các đ/c: Triệu, Đức, Hoàng (P.QLĐT); Trung, Trinh (P.QTTB); Thủy (TT.ƯDCNTT); ...', 3, N'Họp Tổ công tác xây dựng TKB năm học 2019-2020 (toàn trường).')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (165, N'Họp giao ban các công trình cải tạo giảng đường, ký túc xá.', 1, CAST(N'2019-07-13 08:30:00.000' AS DateTime), CAST(N'2019-07-13 10:30:00.000' AS DateTime), CAST(N'2019-07-13 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'c@gmail.com', 4, N'Họp giao ban các công trình cải tạo giảng đường, ký túc xá.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (166, N'P.TCCB chuẩn bị tài liệu', 2, CAST(N'2019-09-17 08:00:00.000' AS DateTime), CAST(N'2019-09-17 09:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Ban Giám hiệu , cùng các đ/c: Nhượng, Thúy, Tú, Hải Anh, Nhung (P.TCCB); Chi (P.TC-KT); Đồng (VP.Đ-ĐT); Triệu (P.QLĐT); Dũng (P.TH); Trung (P.QTTB); Thủy (TT.UDCNTT); Thành (V.ĐTSĐH); Toại (P.KT&ĐBCLGD); Tùng (P.HTQT); Dũng (P.TT-PC).', 3, N'Họp triển khai tổ công tác chuẩn bị tài liệu phục vụ đoàn kiểm tra của Bộ Giáo dục và Đào tạo.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (167, N'Đ/c Thọ (Phó Hiệu trưởng), cùng đại diện lãnh đạo các đơn vị: P. TCCB, P. TT-PC, P. KT& ĐBCLGD, P.TCKT, K. Ngoại ngữ, TT. ĐTTX và các đồng chí có giấy mời.', 1, CAST(N'2019-09-17 08:00:00.000' AS DateTime), CAST(N'2019-09-17 08:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Đ/c Thọ (Phó Hiệu trưởng), cùng đại diện lãnh đạo các đơn vị: P. TCCB, P. TT-PC, P. KT& ĐBCLGD, P.TCKT, K. Ngoại ngữ, TT. ĐTTX và các đồng chí có giấy mời.', 48, N'Trung tâm ĐTTX Báo cáo Ban Giám hiệu về việc xây dựng quy định kiểm tra, đánh giá chuẩn đầu ra ngoại ngữ của sinh viên hệ Từ xa.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (168, N'P.QTTB chuẩn bị tài liệu', 3, CAST(N'2019-09-17 08:30:00.000' AS DateTime), CAST(N'2019-09-17 09:00:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Cường (Phó Hiệu trưởng), cùng các thành viên Thường trực Tổ công tác rà soát Phòng làm việc và lãnh đạo Trung tâm Thông tin Thư viện.', 4, N'Ban Giám hiệu làm việc với Trung tâm Thông tin Thư viện về phòng làm việc của Trung tâm.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (169, N'P.TH chuẩn bị tài liệu', 2, CAST(N'2019-09-17 09:00:00.000' AS DateTime), CAST(N'2019-09-17 09:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Ban Giám hiệu, cùng các đ/c: Dũng (P.TH); Nhượng (P.TCCB); Triệu (P.QLĐT); Thành (V.ĐTSĐH); Thành (P.QLKH); Chi (P.TCKT); Trung (P.QTTB) và toàn thể cán bộ viên chức Khoa Kinh tế và Quản lý Nguồn nhân lực.', 3, N'	Ban Giám hiệu làm việc với Khoa Kinh tế và Quản lý Nguồn nhân lực.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (170, N'ĐTN - HSV chuẩn bị tài liệu', 4, CAST(N'2019-09-17 09:30:00.000' AS DateTime), CAST(N'2019-09-17 10:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Thọ (Phó Hiệu trưởng), cùng đại diện lãnh đạo các đơn vị: P.TH, P.TT, Đoàn TN - HSV; P.CTTT&QLSV và đại diện các doanh nghiệp, báo chí, truyền thông quan tâm.', 48, N'Họp báo Ngày hội Tuổi trẻ - NEU YOUTH FESTIVAL 2019.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (171, N'P.QTTB chuẩn bị tài liệu', 3, CAST(N'2019-09-17 10:00:00.000' AS DateTime), CAST(N'2019-09-17 11:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Cường (Phó Hiệu trưởng), cùng các thành viên Thường trực Tổ công tác rà soát Phòng làm việc và lãnh đạo Phòng Quản trị thiết bị.', 4, N'Ban Giám hiệu làm việc với Phòng Quản trị thiết bị về phòng làm việc của đơn vị.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (172, N'Tổ Thư ký chuẩn bị tài liệu', 3, CAST(N'2019-09-17 14:00:00.000' AS DateTime), CAST(N'2019-09-17 15:00:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Thọ (Phó Hiệu trưởng), cùng các thành viên Hội đồng khoa học, sáng kiến và Tổ thư ký theo Quyết định số 863/QĐ-ĐHKTQD ngày 20/8/2019 của Hiệu trưởng.', 48, N'Họp Hội đồng khoa học, sáng kiến trường.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (173, N'P.HTQT chuẩn bị tài liệu', 2, CAST(N'2019-09-17 14:30:00.000' AS DateTime), CAST(N'2019-09-17 15:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), cùng các đ/c: Tùng, Q.Anh (P.HTQT); Chi (P.TCKT); Dũng (P. TH); Nhượng (P.TCCB), và đại diện lãnh đạo các đơn vị: K.MT.BĐKH &ĐT, K.DL & KS, V.TM & KTQT, Tạp chị KTPT, V.QTKD, TT.TT&TV, V. KTKT; V. NHTC; TT Nghiên cứu tư vấn KT&KD, P.QLKH, K. Marketing, K. Toán kinh tế.', 3, N'Phòng Hợp tác Quốc tế Báo cáo Hiệu trưởng kế hoạch các đoàn đi công tác nước ngoài năm 2020 của Nhà trường.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (174, N'P.TH chuẩn bị tài liệu', 2, CAST(N'2019-09-17 15:30:00.000' AS DateTime), CAST(N'2019-09-17 16:30:00.000' AS DateTime), CAST(N'2019-09-17 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Ban Giám hiệu, cùng các đ/c: Dũng (P.TH); Nhượng (P.TCCB); Triệu (P.QLĐT); Thành (V.ĐTSĐH); Thành (P.QLKH); Chi (P.TCKT); Trung (P.QTTB) và toàn thể cán bộ viên chức Khoa Kế hoạch phát triển.', 3, N'Ban Giám hiệu làm việc với Khoa Kế hoạch phát triển.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (175, N'P.TCCB chuẩn bị tài liệu', 2, CAST(N'2019-09-18 08:00:00.000' AS DateTime), CAST(N'2019-09-18 09:30:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), cùng Trưởng các đơn vị chức năng, tập thể lãnh đạo mở rộng K.KTH, V.CSC & QL và đ/c: Thúy, Tú (P.TCCB).', 3, N'Thông báo Quyết định sáp nhập Viện chính sách công & QL về Khoa Kinh tế học.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (177, N'Tổ công tác chuẩn bị tài liệu', 3, CAST(N'2019-09-18 08:30:00.000' AS DateTime), CAST(N'2019-09-18 09:30:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Thọ (Phó Hiệu trưởng), cùng các thành viên Tổ công tác theo Quyết định của Hiệu trưởng.', 48, N'Họp Tổ công tác rà soát hoạt động của các Trung tâm.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (178, N'P.HTQT chuẩn bị tài liệu', 5, CAST(N'2019-09-18 09:00:00.000' AS DateTime), CAST(N'2019-09-18 10:00:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), cùng các đ/c: Trường, Thu, Linh (K.MT.BĐKH &ĐT);Tùng (P.HTQT); đại diện lãnh đạo các đơn vị: P.QLKH, P.TT.', 3, N'Tiếp và làm việc với TS. James Kendell, Phó Chủ tịch cấp cao của Trung Tâm nghiên cứu Năng lượng Châu Á Thái Bình Dương (APERC).')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (179, N'P.QLĐT chuẩn bị tài liệu', 1, CAST(N'2019-09-18 09:00:00.000' AS DateTime), CAST(N'2019-09-18 10:00:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Đ/c Hoa (Phó Hiệu trưởng), cùng các đ/c: Triệu, Tạo, Đức, H.Hà, H.Giang, Bình (P.QLĐT); Dũng (P.TH); Chi (P.TC-KT); Nghĩa (P.TT); Trung (P.QTTB).', 47, N'Phòng QLĐT báo cáo BGH về công tác chuẩn bị tổ chức HNTK công tác tuyển sinh ĐHCQ năm 2019 và triển khai KH năm 2020.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (180, N'P.TCCB chuẩn bị tài liệu', 2, CAST(N'2019-09-18 09:30:00.000' AS DateTime), CAST(N'2019-09-18 10:30:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), cùng Trưởng các đơn vị chức năng, tập thể lãnh đạo mở rộng Phòng QTTB và TT.DV&HTĐT và đ/c: Thúy, Hải Anh (P.TCCB).', 3, N'Thông báo Quyết định chuyển nhiệm vụ khai thác, cung cấp nước từ Phòng Quản trị thiết bị về Trung tâm Dịch vụ và Hỗ trợ đào tạo.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (181, N'K.MT, BĐKH&ĐT chuẩn bị tài liệu', 4, CAST(N'2019-09-18 09:30:00.000' AS DateTime), CAST(N'2019-09-18 11:30:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Thọ (Phó Hiệu trưởng), cùng toàn thể CBGV K.MT, BĐKH&ĐT, K. BĐS &KTTN, đại biểu có giấy mời và các đại biểu quan tâm.', 48, N'Tọa đàm khoa học KTNL ứng phó với Biến đổi khí hậu, Dự báo cung cầu năng lượng khu vực APEC đến năm 2050 và hàm ý cho Việt Nam.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (182, N'P.KT&ĐBCLGD chuẩn bị tài liệu', 1, CAST(N'2019-09-18 10:30:00.000' AS DateTime), CAST(N'2019-09-18 11:30:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/C Hoa (Phó Hiệu trưởng), cùng các đ/c: Triệu (P.QLĐT); Nhượng (P.TCCB); Dũng (P.TH); Dũng (P.TTPC); Hà (P.CTCT&QLSV); Thành (V.SĐH); Quang (K.ĐHTC); Ngọc (V.ĐTTT,CLC&POHE); Thủy (TT.ƯDCNTT) và lãnh đạo, chuyên viên P.KT&ĐBCLGD.', 47, N'Họp triển khai việc điều chỉnh, bổ sung Quy chế tổ chức thi kết thúc học phần.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (183, N'P.QLĐT chuẩn bị tài liệu', 1, CAST(N'2019-09-18 14:00:00.000' AS DateTime), CAST(N'2019-09-18 15:00:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Hoa (Phó Hiệu trưởng), cùng các đ/c: Triệu, Tạo, Đức, H.Giang, Cường, Minh, Lê Hà (P.QLĐT), đại diện lãnh đạo và trợ lý Khoa/Viện đào tạo.', 47, N'Phổ biến và tập huấn quy trình xét công nhận tốt nghiệp hệ ĐHCQ; VB2-CQ đợt 3 năm 2019.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (184, N'V. QTKD chuẩn bị tài liệu', 3, CAST(N'2019-09-18 15:00:00.000' AS DateTime), CAST(N'2019-09-18 16:00:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đ/c Chương (Hiệu trưởng), cùng các thành viên Hội đồng tuyển sinh theo Quyết định số 531/QĐ-ĐHKTQD ngày 20/5/2019 của Hiệu trưởng.', 3, N'Họp Hội đồng tuyển sinh EMBA Khoá 18 đợt 2 năm 2019.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (185, N'P.TCCB chuẩn bị tài liệu', 4, CAST(N'2019-09-18 15:30:00.000' AS DateTime), CAST(N'2019-09-18 17:30:00.000' AS DateTime), CAST(N'2019-09-18 00:00:00.000' AS DateTime), N'Pham Minh. Hoan', N'hoanpm@neu.edu.vn', N'0949263666', N'Đang chờ xử lý', N'Đảng ủy, Ban Giám hiệu, Chủ tịch Hội đồng trường. Chủ tịch Công đoàn trường, Đoàn TN, Hội CCB, Trưởng các đơn vị trong trường, viên chức được bổ nhiệm chức vụ quản lý, viên chức có quyết định thôi giữ chức vụ quản lý từ tháng 4/2019.', 3, N'Lễ Công bố Quyết định bổ nhiệm cán bộ quản lý.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (186, N'P.TH chuẩn bị tài liệu', 2, CAST(N'2019-09-19 08:00:00.000' AS DateTime), CAST(N'2019-09-19 07:30:00.000' AS DateTime), CAST(N'2019-09-19 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Ban Giám hiệu, cùng các đ/c: Dũng (P.TH); Nhượng (P.TCCB); Triệu (P.QLĐT); Thành (V.ĐTSĐH); Thành (P.QLKH); Chi (P.TCKT); Trung (P.QTTB) và toàn thể cán bộ viên chức Viện Quản trị kinh doanh.', 3, N'Ban Giám hiệu làm việc với Viện Quản trị kinh doanh.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (187, N'P.TH chuẩn bị tài liệu', 2, CAST(N'2019-09-19 10:00:00.000' AS DateTime), CAST(N'2019-09-19 12:00:00.000' AS DateTime), CAST(N'2019-09-19 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Ban Giám hiệu, cùng các đ/c: Dũng (P.TH); Nhượng (P.TCCB); Triệu (P.QLĐT); Thành (V.ĐTSĐH); Thành (P.QLKH); Chi (P.TCKT); Trung (P.QTTB) và toàn thể cán bộ viên chức Khoa Luật.', 3, N'Ban Giám hiệu làm việc với Khoa Luật.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (188, N'TT.UDCNTT chuẩn bị tài liệu', 3, CAST(N'2019-09-19 14:00:00.000' AS DateTime), CAST(N'2019-09-19 15:00:00.000' AS DateTime), CAST(N'2019-09-19 00:00:00.000' AS DateTime), N'Phạm Minh Hoàn', N'hoanpm@neu.edu.vn', N'0949263666', N'Đã chấp nhận', N'Ban Giám hiệu, cùng đại diện lãnh đạo các đơn vị: P.TH, P.TCCB, P.TCKT, P.QLKH,P.QTTB, P.KT&ĐBCLGD, V.ĐTSĐH, P. QLĐT, TT.ĐTTX, K.ĐHTC, V. ĐTTT-CLC & POHE, V.ĐTQT và các đ/c :Tuấn, Hoàn, Tâm (V. CNTT&KTS); Thủy, Nghị, Xuân Hương, Mạnh Cường (TT.UDCNTT).', 3, N'Triển khai kế hoạch ứng dụng phần mềm tổng thể.')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (189, N'không', 2, CAST(N'2019-11-03 16:00:00.000' AS DateTime), CAST(N'2019-11-03 18:00:00.000' AS DateTime), CAST(N'2019-11-03 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', N'098847387585', N'Đang chờ xử lý', N'a@gmail.com,c@gmail.com', 4, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (190, N'không', 2, CAST(N'2019-11-08 07:00:00.000' AS DateTime), CAST(N'2019-11-08 14:30:00.000' AS DateTime), CAST(N'2019-11-08 00:00:00.000' AS DateTime), N'Dũng', N'phaichisophan@gmail.com', N'0909749372', N'Đã chấp nhận', N'b@gmail.com', 47, N'Họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (191, N'không ok ffg      f', 10, CAST(N'2019-12-18 13:30:00.000' AS DateTime), CAST(N'2019-12-18 16:00:00.000' AS DateTime), CAST(N'2019-12-18 00:00:00.000' AS DateTime), N'Dungx SS', N'drm1997bn@gmail.com', NULL, N'Đã chuyển', N'd@gmail.com,c@gmail.com,bdt@gmail.com', 4, N'Họp thôi nhesssssssss ')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (192, N'không ok', 4, CAST(N'2019-11-10 17:00:00.000' AS DateTime), CAST(N'2019-11-10 20:00:00.000' AS DateTime), CAST(N'2019-11-10 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', NULL, N'Đang chờ xử lý', N'b@gmail.com,c@gmail.com', 47, N'Họp để họp')
INSERT [dbo].[LichDangKy] ([ID], [TieuDe], [IDPhong], [ThoiGianBatDau], [ThoiGianKetThuc], [NgayDangKy], [TenNguoiDangKy], [Email], [SoDienThoai], [TinhTrang], [ThanhPhan], [IdLanhDao], [NoiDungCuocHop]) VALUES (193, N'không', 4, CAST(N'2020-02-20 15:30:00.000' AS DateTime), CAST(N'2020-02-20 18:30:00.000' AS DateTime), CAST(N'2020-02-20 00:00:00.000' AS DateTime), N'Dũng Nguyễn Xuân', N'dxdragon97bn@live.com', NULL, N'Đang chờ xử lý', N', PGS.TS Phạm Hồng Chương (b@gmail.com)', 3, N'Họp virus EncoV')
SET IDENTITY_INSERT [dbo].[LichDangKy] OFF
SET IDENTITY_INSERT [dbo].[LichThietBi] ON 

INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (3, 13, 3, 2, N'Đã trả', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (4, 13, 2, 1, N'Đã trả', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (7, 14, 2, 1, N'Đã trả', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (8, 15, 2, 1, N'Đã trả', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (9, 16, 3, 5, N'Đã cho thuê', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (10, 16, 2, 4, N'Đã cho thuê', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (11, 16, 1, 2, N'Đã cho thuê', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (12, 17, 1, 1, N'Đã cho thuê', N'Dũng')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (13, 34, 1, 2, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (14, 37, 1, 1, N'Đã cho thuê', N'Dũng Nguyễn Xuân')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (15, 37, 2, 1, N'Đã cho thuê', N'Dũng Nguyễn Xuân')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (16, 47, 1, 1, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (17, 53, 1, 1, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (18, 103, 2, 3, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (19, 103, 1, 1, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (20, 111, 1, NULL, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (21, 112, 2, 2, N'Hỏng', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (22, 112, 1, 1, N'Đã cho thuê', N'Nguyen Xuan Dung')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (23, 113, 1, 2, N'Đã cho thuê', N'Phan Van Khai')
INSERT [dbo].[LichThietBi] ([ID], [IDLichDangKy], [IDThietBi], [SoLuongThue], [TinhTrang], [NguoiThue]) VALUES (24, 117, 1, 2, N'Đã cho thuê', N'Nguyen Xuan Dung')
SET IDENTITY_INSERT [dbo].[LichThietBi] OFF
SET IDENTITY_INSERT [dbo].[LoaiPhong] ON 

INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (1, N'Đặc biệt')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (2, N'Phòng đa năng')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (4, N'Phòng họp')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (5, N'Phòng tiếp khách')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (6, N'Phòng hội thảo lớn')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (7, N'Phòng hội thảo nhỏ')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (8, N'Phòng hội thảo')
INSERT [dbo].[LoaiPhong] ([ID], [TenLoaiPhong]) VALUES (9, N'Hội trường')
SET IDENTITY_INSERT [dbo].[LoaiPhong] OFF
SET IDENTITY_INSERT [dbo].[Mails] ON 

INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (139, N'XacNhanDaDangKy.html', 0)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (140, N'fromAdmin.html', 1)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (141, N'changeRoom.html', 2)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (142, N'notAccept.html', 3)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (143, N'requestToAdmin.html', 4)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (144, N'toMembers.html', 5)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (145, N'phaichisophan@gmail.com', 6)
INSERT [dbo].[Mails] ([ID], [TenMail], [ValueOfMail]) VALUES (146, N'drm1997bn', 7)
SET IDENTITY_INSERT [dbo].[Mails] OFF
SET IDENTITY_INSERT [dbo].[Phong] ON 

INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (1, N'Phòng họp A', 1, 4)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (2, N'Phòng họp B', 1, 4)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (3, N'Phòng họp C', 1, 4)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (4, N'Phòng hội thảo', 2, 8)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (5, N'Phòng tiếp khách', 1, 5)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (6, N'B101', 4, 8)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (7, N'B102', 4, 8)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (8, N'B103', 4, 8)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (9, N'B104', 4, 8)
INSERT [dbo].[Phong] ([ID], [TenPhong], [IDKhuNha], [IDLoaiPhong]) VALUES (10, N'A1', 5, 9)
SET IDENTITY_INSERT [dbo].[Phong] OFF
SET IDENTITY_INSERT [dbo].[ThietBi] ON 

INSERT [dbo].[ThietBi] ([ID], [TenThietBi], [SoLuong]) VALUES (1, N'Máy chiếu', 100)
INSERT [dbo].[ThietBi] ([ID], [TenThietBi], [SoLuong]) VALUES (2, N'Micro', 100)
INSERT [dbo].[ThietBi] ([ID], [TenThietBi], [SoLuong]) VALUES (3, N'Video confering', 10)
SET IDENTITY_INSERT [dbo].[ThietBi] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[LichDangKy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LichDangKy_dbo.LanhDao_IdLanhDao] FOREIGN KEY([IdLanhDao])
REFERENCES [dbo].[LanhDao] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LichDangKy] CHECK CONSTRAINT [FK_dbo.LichDangKy_dbo.LanhDao_IdLanhDao]
GO
ALTER TABLE [dbo].[LichDangKy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LichDangKy_dbo.Phong_IDPhong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[Phong] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LichDangKy] CHECK CONSTRAINT [FK_dbo.LichDangKy_dbo.Phong_IDPhong]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Phong_dbo.KhuNha_IDKhuNha] FOREIGN KEY([IDKhuNha])
REFERENCES [dbo].[KhuNha] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_dbo.Phong_dbo.KhuNha_IDKhuNha]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Phong_dbo.LoaiPhong_IDLoaiPhong] FOREIGN KEY([IDLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_dbo.Phong_dbo.LoaiPhong_IDLoaiPhong]
GO
/****** Object:  StoredProcedure [dbo].[Sp_BaoCaoTheoThang]    Script Date: 2/18/2020 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_BaoCaoTheoThang] @thang varchar(50)
AS
BEGIN
	select TenPhong as TenPhong,
    ( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Monday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Monday,
	( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Tuesday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Tuesday,
	( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Wednesday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Wednesday,
	( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Thursday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Thursday,
	( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Friday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Friday,
	( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Saturday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Saturday,
	( select COUNT(*) from LichDangKy where DATENAME(weekday,NgayDangKy)='Sunday' and IDPhong =Phong.ID and DATENAME(MONTH,NgayDangKy)=@thang) as Sunday,
       count(*) as TongSo
from Phong inner join LichDangKy
on Phong.ID =LichDangKy.IDPhong 
where DATENAME(MONTH,NgayDangKy)=@thang
group by Phong.TenPhong,LichDangKy.IDPhong,Phong.ID
END

GO
