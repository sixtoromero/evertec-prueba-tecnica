USE [master]
GO
/****** Object:  Database [evertec]    Script Date: 16/01/2023 4:30:57 ******/
CREATE DATABASE [evertec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'evertec', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\evertec.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'evertec_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\evertec_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [evertec] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [evertec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [evertec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [evertec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [evertec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [evertec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [evertec] SET ARITHABORT OFF 
GO
ALTER DATABASE [evertec] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [evertec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [evertec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [evertec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [evertec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [evertec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [evertec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [evertec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [evertec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [evertec] SET  DISABLE_BROKER 
GO
ALTER DATABASE [evertec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [evertec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [evertec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [evertec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [evertec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [evertec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [evertec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [evertec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [evertec] SET  MULTI_USER 
GO
ALTER DATABASE [evertec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [evertec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [evertec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [evertec] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [evertec] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [evertec] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [evertec] SET QUERY_STORE = OFF
GO
USE [evertec]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](150) NOT NULL,
	[Apellidos] [nvarchar](150) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Foto] [nvarchar](150) NOT NULL,
	[Estado_Civil] [bit] NOT NULL,
	[Tiene_Hermanos] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](150) NULL,
	[Apellidos] [nvarchar](150) NULL,
	[Correo] [nvarchar](150) NULL,
	[Contrasena] [nvarchar](250) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspClientesInsert]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspClientesInsert]
	@Nombres NVARCHAR(250)
	,@Apellidos NVARCHAR(250)
	,@Fecha_Nacimiento DATE
	,@Foto NVARCHAR(250)
	,@Estado_Civil BIT
	,@Tiene_Hermanos BIT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		INSERT INTO  [dbo].[Clientes] (
			Nombres
			,Apellidos
			,Fecha_Nacimiento
			,Foto
			,Estado_Civil
			,Tiene_Hermanos
		) VALUES (
			@Nombres
			,@Apellidos
			,@Fecha_Nacimiento
			,@Foto
			,@Estado_Civil
			,@Tiene_Hermanos
		)		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspClientesUpdate]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClientesUpdate]
	@Id INT
	,@Nombres NVARCHAR(250)
	,@Apellidos NVARCHAR(250)
	,@Fecha_Nacimiento DATE
	,@Foto NVARCHAR(250)
	,@Estado_Civil BIT
	,@Tiene_Hermanos BIT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
		UPDATE [dbo].[Clientes] SET
			Nombres = @Nombres
			,Apellidos = @Apellidos
			,Fecha_Nacimiento = @Fecha_Nacimiento
			,Foto = @Foto
			,Estado_Civil = @Estado_Civil
			,Tiene_Hermanos = @Tiene_Hermanos
		WHERE Id = @Id
		
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelClientes]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelClientes]
	@Id INT	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DELETE FROM [dbo].[Clientes] WHERE Id = @Id

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDelUsuarios]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDelUsuarios]
	@Id INT	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DELETE FROM [dbo].[Usuarios] WHERE Id = @Id

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetClientes]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetClientes]
AS
SELECT 
	Id
	,Nombres
	,Apellidos
	,Fecha_Nacimiento
	,Foto
	,Estado_Civil
	,Tiene_Hermanos
FROM [dbo].[Clientes]


GO
/****** Object:  StoredProcedure [dbo].[UspgetClientesByID]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetClientesByID]
	@IdCliente INT
AS
SELECT 
	Id
	,Nombres
	,Apellidos
	,Fecha_Nacimiento
	,Foto
	,Estado_Civil
	,Tiene_Hermanos
FROM [dbo].[Clientes] WHERE Id = @IdCliente
 
GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuarios]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuarios]
AS
SELECT 
	Id
	,Nombres
	,Apellidos
	,Correo
	,Contrasena
FROM [dbo].[Usuarios]


GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuariosByID]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuariosByID]
	@Id INT
AS
SELECT 
	Id
	,Nombres
	,Apellidos
	,Correo
	,Contrasena
FROM [dbo].[Usuarios] WHERE Id = @Id
 
GO
/****** Object:  StoredProcedure [dbo].[UspgetUsuariosByUserName]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetUsuariosByUserName]
	@Correo nvarchar(150),
	@Contrasena nvarchar(150)
AS
SELECT 
	Id
	,Nombres
	,Apellidos
	,Correo
	,Contrasena
FROM [dbo].[Usuarios] WHERE Correo = @Correo and Contrasena = @Contrasena
 
GO
/****** Object:  StoredProcedure [dbo].[uspUsuariosInsert]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsuariosInsert]
	@Nombres NVARCHAR(150)
	,@Apellidos NVARCHAR(150)	
	,@Correo NVARCHAR(150)	
	,@Contrasena NVARCHAR(250)	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		INSERT INTO  [dbo].[Usuarios] (
			Nombres
			,Apellidos
			,Correo
			,Contrasena
		) VALUES (
			@Nombres
			,@Apellidos
			,@Correo			
			,@Contrasena
		)		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuariosUpdate]    Script Date: 16/01/2023 4:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsuariosUpdate]
	@Id INT
	,@Nombres NVARCHAR(150)
	,@Apellidos NVARCHAR(150)	
	,@Correo NVARCHAR(150)	
	,@Contrasena NVARCHAR(250)	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		
		
		UPDATE [dbo].[Usuarios] SET
			Nombres = @Nombres
			,Apellidos = @Apellidos
			,Correo = @Correo						
			,Contrasena = @Contrasena
		WHERE Id = @Id
		
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
USE [master]
GO
ALTER DATABASE [evertec] SET  READ_WRITE 
GO
