
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY "./ProjectRecipe/ProjectRecipe.csproj" .
RUN dotnet restore "./ProjectRecipe.csproj"

COPY . ./
RUN dotnet publish ProjetoReceita.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ProjectRecipe.dll" ]