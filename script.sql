USE [master]
GO
/****** Object:  Database [QLQAo]    Script Date: 6/19/2021 12:35:53 PM ******/
CREATE DATABASE [QLQAo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLQAo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLQAo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLQAo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLQAo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLQAo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLQAo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLQAo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLQAo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLQAo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLQAo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLQAo] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLQAo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLQAo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLQAo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLQAo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLQAo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLQAo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLQAo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLQAo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLQAo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLQAo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLQAo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLQAo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLQAo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLQAo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLQAo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLQAo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLQAo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLQAo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLQAo] SET  MULTI_USER 
GO
ALTER DATABASE [QLQAo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLQAo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLQAo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLQAo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLQAo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLQAo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLQAo', N'ON'
GO
ALTER DATABASE [QLQAo] SET QUERY_STORE = OFF
GO
USE [QLQAo]
GO
/****** Object:  Table [dbo].[Acount]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acount](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_Acount] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHDNhap]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHDNhap](
	[MaCTHDNhap] [nvarchar](50) NOT NULL,
	[MaHDNhap] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CTHDNhap] PRIMARY KEY CLUSTERED 
(
	[MaCTHDNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHDThanhToan]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHDThanhToan](
	[MaCTHDThanhToan] [nvarchar](50) NOT NULL,
	[MaHD] [nvarchar](50) NULL,
	[MaHang] [nvarchar](50) NULL,
	[SL] [int] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CTHDThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaCTHDThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HDNhap]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDNhap](
	[MaHDNhap] [nvarchar](50) NOT NULL,
	[MaThuongHieu] [nvarchar](50) NULL,
	[TongTien] [float] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[MaNhanVien] [nvarchar](50) NULL,
	[NgayNhap] [date] NULL,
 CONSTRAINT [PK_HDNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HDThanhToan]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDThanhToan](
	[MaHD] [nvarchar](50) NOT NULL,
	[MaKH] [nvarchar](50) NULL,
	[CTHD] [nvarchar](50) NULL,
 CONSTRAINT [PK_HDThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLoaiHang] [nvarchar](50) NOT NULL,
	[TenLoaiHang] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiHang] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](50) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[NamSinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[MaSize] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[MaSize] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinHang]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinHang](
	[MaHang] [nvarchar](50) NOT NULL,
	[TenHang] [nvarchar](50) NULL,
	[MaLoaiHang] [nvarchar](50) NULL,
	[MaSize] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[MaThuongHieu] [nvarchar](50) NULL,
	[Anh] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ThongTinHang] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinKH]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinKH](
	[MaKH] [nvarchar](50) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThongTinKH] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 6/19/2021 12:35:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaThuongHieu] [nvarchar](50) NOT NULL,
	[TenThuongHieu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThuongHIeu] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Acount] ([TaiKhoan], [MatKhau]) VALUES (N'admin', N'21232f297a57a5a743894a0e4a801fc3')
GO
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'1', N'COLLECTION')
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'2', N'T-SHIRT')
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'3', N'HOODIE/SWEATER')
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'4', N'ACCESSORIES')
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'5', N'SHORT/PANT')
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'6', N'JACKET')
INSERT [dbo].[LoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'7', N'BAD RABIT')
GO
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'1', N'Hello', N'1', NULL, 100, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'10', N'trung', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'11', N'phuong', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'12', N'hieu', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'2', N'ngoc', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'3', N'hang', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'4', N'thuan', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'5', N'emkhang', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'6', N'fucker', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'7', N'gangter', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'8', N'hieeulon', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ThongTinHang] ([MaHang], [TenHang], [MaLoaiHang], [MaSize], [DonGia], [MaThuongHieu], [Anh], [SoLuong]) VALUES (N'9', N'linh', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ThongTinKH] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [MatKhau]) VALUES (N'10', N'linh', N'1', 1, N'1@gmail.com', N'linh')
INSERT [dbo].[ThongTinKH] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [MatKhau]) VALUES (N'100', N'linh', N'', 0, N'', NULL)
INSERT [dbo].[ThongTinKH] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [MatKhau]) VALUES (N'101', N'linh', N'', 0, N'', NULL)
INSERT [dbo].[ThongTinKH] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [MatKhau]) VALUES (N'102', N'linh', N'', 123, N'', NULL)
INSERT [dbo].[ThongTinKH] ([MaKH], [TenKH], [DiaChi], [SDT], [Email], [MatKhau]) VALUES (N'103', N'linh', N'', 0, N'', NULL)
GO
ALTER TABLE [dbo].[CTHDNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTHDNhap_HDNhap] FOREIGN KEY([MaHDNhap])
REFERENCES [dbo].[HDNhap] ([MaHDNhap])
GO
ALTER TABLE [dbo].[CTHDNhap] CHECK CONSTRAINT [FK_CTHDNhap_HDNhap]
GO
ALTER TABLE [dbo].[CTHDNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTHDNhap_ThongTinHang] FOREIGN KEY([MaHang])
REFERENCES [dbo].[ThongTinHang] ([MaHang])
GO
ALTER TABLE [dbo].[CTHDNhap] CHECK CONSTRAINT [FK_CTHDNhap_ThongTinHang]
GO
ALTER TABLE [dbo].[CTHDThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_CTHDThanhToan_HDThanhToan] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HDThanhToan] ([MaHD])
GO
ALTER TABLE [dbo].[CTHDThanhToan] CHECK CONSTRAINT [FK_CTHDThanhToan_HDThanhToan]
GO
ALTER TABLE [dbo].[CTHDThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_CTHDThanhToan_ThongTinHang] FOREIGN KEY([MaHang])
REFERENCES [dbo].[ThongTinHang] ([MaHang])
GO
ALTER TABLE [dbo].[CTHDThanhToan] CHECK CONSTRAINT [FK_CTHDThanhToan_ThongTinHang]
GO
ALTER TABLE [dbo].[HDNhap]  WITH CHECK ADD  CONSTRAINT [FK_HDNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HDNhap] CHECK CONSTRAINT [FK_HDNhap_NhanVien]
GO
ALTER TABLE [dbo].[HDThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HDThanhToan_ThongTinKH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[ThongTinKH] ([MaKH])
GO
ALTER TABLE [dbo].[HDThanhToan] CHECK CONSTRAINT [FK_HDThanhToan_ThongTinKH]
GO
ALTER TABLE [dbo].[ThongTinHang]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinHang_LoaiHang] FOREIGN KEY([MaLoaiHang])
REFERENCES [dbo].[LoaiHang] ([MaLoaiHang])
GO
ALTER TABLE [dbo].[ThongTinHang] CHECK CONSTRAINT [FK_ThongTinHang_LoaiHang]
GO
ALTER TABLE [dbo].[ThongTinHang]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinHang_Size] FOREIGN KEY([MaSize])
REFERENCES [dbo].[Size] ([MaSize])
GO
ALTER TABLE [dbo].[ThongTinHang] CHECK CONSTRAINT [FK_ThongTinHang_Size]
GO
ALTER TABLE [dbo].[ThongTinHang]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinHang_ThuongHieu] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[ThongTinHang] CHECK CONSTRAINT [FK_ThongTinHang_ThuongHieu]
GO
USE [master]
GO
ALTER DATABASE [QLQAo] SET  READ_WRITE 
GO
