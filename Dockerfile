# Usa uma imagem base do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia todos os outros arquivos e compila a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usa uma imagem mais leve para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta para o Docker
EXPOSE 80

# Define o comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "TstCompras.dll"]
