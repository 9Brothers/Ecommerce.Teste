# Ecommerce.Teste
Teste para a empresa de E-Commerce


### Instruções
Para executar o projeto sem grandes problemas, execute os passos abaixo, mas para isso tenha o Docker e dotnet core sdk instalados na sua máquina.

Não se preocupe, o processo é bem demorado da primeira vez.

- Abra o terminal (Powershell, Prompt, Bash...);
- Vá até o diretório **./Presentation/Usuarios.Presentation.Api** e execute o comando **dotnet publish -c Release -o Publish**;
- Caso esteja rodando alguma aplicação que usa a porta 1433 (sql), por favor, pare-a pois será executado um container do SQL Server no comando abaixo;
- Digite: **docker-compose up** ou **sudo docker-compose up** caso esteja utilizando linux;
- Acesse o banco de dados usando o usuário **SA** e senha **yourStrong(!)Password**;
- Após a criação dos containers, rode os arquivos sql dentro da pasta **./Infrastructure/Usuarios/Infrastructure.SqlServer/SQL**;
- Acesse http://localhost:4200 para visualizar o projeto.

Não se preocupe caso não apareça os novos cadastros, o cache está configurado para 1 minuto, após esse tempo, aparecerá normalmente

Qualquer dúvida, podem entrar em contato comigo pelo **(11) 98725-8313**