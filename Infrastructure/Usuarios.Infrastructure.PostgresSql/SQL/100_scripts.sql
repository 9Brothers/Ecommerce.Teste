DO $$
DECLARE
	id integer := 0;
	err text := '';
BEGIN
	CALL dbo.piusuario(
		'Renilda'::CHARACTER VARYING, 
		'1970-03-23'::TIMESTAMP, 
		1::SMALLINT, 
		'renilda@renilda.com'::CHARACTER VARYING, 
		'1234'::TEXT, 
		id::INTEGER, 
		err::TEXT
	);
	
	SELECT id AS UsuarioId;
END; $$