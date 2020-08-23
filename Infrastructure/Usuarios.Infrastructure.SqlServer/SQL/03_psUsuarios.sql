USE UsuariosDb

-- Create a new stored procedure called 'psUsuarios' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES


WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'psUsuarios'
)


DROP PROCEDURE dbo.psUsuarios
GO
-- Create the stored procedure in the specified schema


CREATE PROCEDURE dbo.psUsuarios
    @Pagina int = 0    
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    SELECT TOP 50 * FROM (
        SELECT 
            ROW_NUMBER() OVER(ORDER BY UsuarioId) AS RN, 
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
    ) AS U
    WHERE @Pagina * 50 < RN
    ORDER BY U.RN
GO
-- example to execute the stored procedure we just created