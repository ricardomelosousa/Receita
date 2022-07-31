#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Fiap.Project.Recipes.Web/Fiap.Project.Recipes.Web.csproj", "Fiap.Project.Recipes.Web/"]
COPY ["Fiap.Project.Recipes.Persistence/Fiap.Project.Recipes.Persistence.csproj", "Fiap.Project.Recipes.Persistence/"]
COPY ["Fiap.Project.Recipes.Application/Fiap.Project.Recipes.Application.csproj", "Fiap.Project.Recipes.Application/"]
COPY ["Fiap.Project.Recipes.Domain/Fiap.Project.Recipes.Domain.csproj", "Fiap.Project.Recipes.Domain/"]
RUN dotnet restore "Fiap.Project.Recipes.Web/Fiap.Project.Recipes.Web.csproj"
COPY . .
WORKDIR "/src/Fiap.Project.Recipes.Web"
RUN dotnet build "Fiap.Project.Recipes.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.Project.Recipes.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Project.Recipes.Web.dll"]