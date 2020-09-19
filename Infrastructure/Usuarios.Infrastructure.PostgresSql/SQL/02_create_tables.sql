DO $$
DECLARE
    qtd_linhas INTEGER = 0;
BEGIN
	-- DELETE TABLES
	SELECT count(*) AS qtd FROM information_schema.tables
	INTO qtd_linhas
	WHERE table_schema = 'dbo'
	AND table_name = 'Usuarios';
	
	IF qtd_linhas > 0 THEN
		DROP TABLE dbo."Usuarios";
	END IF;
	
	SELECT count(*) AS qtd FROM information_schema.tables
	INTO qtd_linhas
	WHERE table_schema = 'dbo'
	AND table_name = 'Sexos';
	
	IF qtd_linhas > 0 THEN
		DROP TABLE dbo."Sexos";
	END IF;
	
	-- CREATE TABLE Sexos
	CREATE TABLE IF NOT EXISTS dbo."Sexos"(
		SexoId SMALLINT PRIMARY KEY,
		Descricao VARCHAR(15) NOT NULL
	);

	INSERT INTO dbo."Sexos" VALUES(1, 'Feminino');
	INSERT INTO dbo."Sexos" VALUES(2, 'Masculino');
	
	-- CREATE TABLE Usuarios
	CREATE TABLE IF NOT EXISTS dbo."Usuarios"(
		UsuarioId SERIAL PRIMARY KEY,
		UsuarioGuid UUID NOT NULL,
		Nome VARCHAR(200) NOT NULL,
		Nascimento TIMESTAMP NOT NULL,
		Email VARCHAR(100) NOT NULL,
		Senha TEXT NOT NULL,
		Ativo BIT NOT NUll,
		CriadoEm TIMESTAMP NOT NULL,    
		AtualizadoEm TIMESTAMP NOT NULL,
		SexoId SMALLINT NOT NULL REFERENCES dbo."Sexos"(SexoId)
	);	
END; $$