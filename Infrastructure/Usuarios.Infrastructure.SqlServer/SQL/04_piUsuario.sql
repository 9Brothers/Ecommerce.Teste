USE UsuariosDb

-- Create a new stored procedure called 'piUsuario' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'piUsuario'
)
DROP PROCEDURE dbo.piUsuario
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.piUsuario
    @Nome NVARCHAR(100),
    @Nascimento DATETIME,
    @SexoId TINYINT,
    @Email NVARCHAR(100),
    @Senha NVARCHAR(100)
-- add more stored procedure parameters here
AS
    DECLARE @CriadoEm DATETIME = GETDATE()
    DECLARE @AtualizadoEm DATETIME = @CriadoEm
    
    -- body of the stored procedure
    INSERT INTO Usuarios VALUES (NEWID(), @Nome, @Nascimento, @Email, @Senha, 1, @SexoId, @CriadoEm, @AtualizadoEm)

    SELECT SCOPE_IDENTITY();
GO