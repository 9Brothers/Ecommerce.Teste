CREATE OR REPLACE FUNCTION dbo.psUsuario(
	_UsuarioId dbo."Usuarios".UsuarioId%type,
	_UsuarioGuid dbo."Usuarios".UsuarioGuid%type
)
RETURNS TABLE(
    Guid dbo."Usuarios".UsuarioGuid%type,
    Nome dbo."Usuarios".Nome%type,
    Nascimento dbo."Usuarios".Nascimento%type,
    Email dbo."Usuarios".Email%type,
    Senha dbo."Usuarios".Senha%type,
    Ativo dbo."Usuarios".Ativo%type,
    CriadoEm dbo."Usuarios".CriadoEm%type,
    AtualizadoEm dbo."Usuarios".AtualizadoEm%type,
    Id dbo."Sexos".SexoId%type,
    Descricao dbo."Sexos".Descricao%type
)
AS $$
BEGIN	
	RETURN QUERY 
    SELECT         
        U.UsuarioGuid AS Guid,
        U.Nome,
        U.Nascimento,
        U.Email,
        U.Senha,
        U.Ativo,
        U.CriadoEm,
        U.AtualizadoEm,
        S.SexoId AS Id,
        S.Descricao
    FROM dbo."Usuarios" U
    INNER JOIN dbo."Sexos" S ON U.SexoId = S.SexoId
    WHERE _UsuarioId IS NOT NULL AND U.UsuarioId = _UsuarioId
	OR _UsuarioGuid IS NOT NULL AND U.UsuarioGuid = _UsuarioGuid;
    
END;$$
LANGUAGE plpgsql;