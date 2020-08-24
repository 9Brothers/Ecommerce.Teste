FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY ./Publish .

ENTRYPOINT ["dotnet", "Usuarios.Presentation.Api.dll"]