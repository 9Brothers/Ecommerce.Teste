USE UsuariosDb

-- Create a new table called 'Usuarios' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL
DROP TABLE dbo.Usuarios
GO

-- Create a new table called 'Sexos' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Sexos', 'U') IS NOT NULL
DROP TABLE dbo.Sexos
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Sexos
(
    SexoId TINYINT NOT NULL PRIMARY KEY, -- primary key column
    Descricao [NVARCHAR](15) NOT NULL,    
    -- specify more columns here
);
GO

-- Create the table in the specified schema
CREATE TABLE dbo.Usuarios
(
    UsuarioId INT NOT NULL PRIMARY KEY IDENTITY, -- primary key column
    UsuarioGuid UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Nome NVARCHAR(200) NOT NULL,
    Nascimento DATETIME NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Senha NVARCHAR(MAX) NOT NULL,
    Ativo BIT NOT NUll,
    SexoId TINYINT NOT NULL FOREIGN KEY REFERENCES Sexos(SexoId),
    CriadoEm DATETIME NOT NULL,    
    AtualizadoEm DATETIME NOT NULL
);
GO