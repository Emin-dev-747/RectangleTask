#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rubiconmp-RectangleTask.Web/Rubiconmp-RectangleTask.API.csproj", "Rubiconmp-RectangleTask.Web/"]
COPY ["Rubiconmp-RectangleTask.Application/Rubiconmp-RectangleTask.Application.csproj", "Rubiconmp-RectangleTask.Application/"]
COPY ["Rubiconmp-RectangleTask.Data/Rubiconmp-RectangleTask.Data.csproj", "Rubiconmp-RectangleTask.Data/"]
RUN dotnet restore "./Rubiconmp-RectangleTask.Web/Rubiconmp-RectangleTask.API.csproj"
COPY . .
WORKDIR "/src/Rubiconmp-RectangleTask.Web"
RUN dotnet build "./Rubiconmp-RectangleTask.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rubiconmp-RectangleTask.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rubiconmp-RectangleTask.API.dll"]