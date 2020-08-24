USE UsuariosDb

-- Create a new stored procedure called 'psUsuario' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES


WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'psUsuario'
)


DROP PROCEDURE dbo.psUsuario
GO
-- Create the stored procedure in the specified schema


CREATE PROCEDURE dbo.psUsuario
    @UsuarioId INT = NULL,
    @UsuarioGuid UNIQUEIDENTIFIER = NULL
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    SELECT 
        UsuarioGuid AS Guid,
        Nome,
        Nascimento,
        Email,
        Senha,
        Ativo,
        CriadoEm,
        AtualizadoEm,
        S.SexoId AS Id,
        S.Descricao
    FROM Usuarios U (NOLOCK)
    INNER JOIN Sexos S (NOLOCK) ON U.SexoId = S.SexoId
    WHERE @UsuarioId IS NOT NULL AND U.UsuarioId = @UsuarioId
    OR @UsuarioGuid IS NOT NULL AND U.UsuarioGuid = @UsuarioGuid    
GO
-- example to execute the stored procedure we just created