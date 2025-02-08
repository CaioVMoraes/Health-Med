# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o projeto e restaurar dependências
COPY . .
RUN dotnet restore

# Publicar a aplicação
RUN dotnet publish -c Release -o /app

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app .

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "HealthMed.dll"]