#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Project.Recipes.Web/Project.Recipes.Web.csproj", "Project.Recipes.Web/"]
COPY ["Project.Recipes.Persistence/Project.Recipes.Persistence.csproj", "Project.Recipes.Persistence/"]
COPY ["Project.Recipes.Application/Project.Recipes.Application.csproj", "Project.Recipes.Application/"]
COPY ["Project.Recipes.Domain/Project.Recipes.Domain.csproj", "Project.Recipes.Domain/"]
RUN dotnet restore "Project.Recipes.Web/Project.Recipes.Web.csproj"
COPY . .
WORKDIR "/src/Project.Recipes.Web"
RUN dotnet build "Project.Recipes.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.Recipes.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.Recipes.Web.dll"]