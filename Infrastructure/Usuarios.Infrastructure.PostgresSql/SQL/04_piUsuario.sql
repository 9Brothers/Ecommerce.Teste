CREATE OR REPLACE PROCEDURE dbo.piUsuario(
    Nome dbo."Usuarios".Nome%type,
    Nascimento dbo."Usuarios".Nascimento%type,
    SexoId dbo."Usuarios".SexoId%type,
    Email dbo."Usuarios".Email%type,
    Senha dbo."Usuarios".Senha%type,
	Id INOUT dbo."Usuarios".UsuarioId%type,
	Err INOUT TEXT
)
LANGUAGE plpgsql    
AS $$
DECLARE
	CriadoEm TIMESTAMP = CURRENT_TIMESTAMP;
	AtualizadoEm TIMESTAMP = CriadoEm;
BEGIN
	
	INSERT INTO dbo."Usuarios"(
		UsuarioGuid, 
		Nome, 
		Nascimento, 
		Email,
		Senha,
		Ativo,
		CriadoEm,
		AtualizadoEm,
		SexoId
	) 
	VALUES (
		uuid_generate_v4(), 
		Nome, 
		Nascimento, 
		Email, 
		Senha, 
		B'1', 
		CriadoEm, 
		AtualizadoEm, 
		SexoId
	)
	RETURNING UsuarioId INTO Id;      

EXCEPTION
    WHEN OTHERS THEN
        Err := SQLERRM;    	
		
	COMMIT;
END;$$