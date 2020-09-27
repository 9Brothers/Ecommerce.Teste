CREATE OR REPLACE FUNCTION dbo.piUsuario(
    _Nome TEXT,
    _Nascimento TIMESTAMP WITHOUT TIME ZONE,
    _SexoId SMALLINT,
    _Email TEXT,
    _Senha TEXT	
)
RETURNS TABLE(
	ResultData TEXT
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
		_Nome, 
		_Nascimento, 
		_Email, 
		_Senha, 
		B'1', 
		CriadoEm, 
		AtualizadoEm, 
		_SexoId
	);
	
	RETURN QUERY
		SELECT CAST(LASTVAL() AS TEXT)  AS ResultData;

EXCEPTION
    WHEN OTHERS THEN
		RETURN QUERY
			SELECT SQLERRM AS ResultData;
			
END;$$