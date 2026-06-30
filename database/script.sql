-- Script de creación de base de datos y tablas para RentAHouse
-- Target: SQL Server

-- 1. Crear la base de datos RentaDepartamentos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'RentaDepartamentos')
BEGIN
    CREATE DATABASE RentaDepartamentos;
END
GO

USE RentaDepartamentos;
GO

-- 2. Eliminar la tabla Departamentos si ya existe para asegurar que se cree con el esquema correcto
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departamentos]') AND type in (N'U'))
BEGIN
    DROP TABLE Departamentos;
END
GO

-- 3. Crear la tabla Departamentos
CREATE TABLE Departamentos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Direccion NVARCHAR(250) NOT NULL,
    Colonia NVARCHAR(100) NOT NULL,
    Ciudad NVARCHAR(100) NOT NULL,
    Habitaciones INT NOT NULL,
    Banios DECIMAL(3, 1) NOT NULL, -- Permite medios baños (ej. 1.5, 2.5)
    PrecioRenta DECIMAL(18, 2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL, -- e.g., 'Disponible', 'Rentado', 'Mantenimiento'
    Arrendatario NVARCHAR(100) NULL, -- Nullable
    FechaInicioRenta DATETIME NULL -- Nullable
);
GO
