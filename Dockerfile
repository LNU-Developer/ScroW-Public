FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 7000

ENV ASPNETCORE_URLS=http://+:7000
ENV ASPNETCORE_ENVIRONMENT ASPNETCORE_ENVIRONMENT

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
# COPY ["./src/Core/ScroW.Domain/ScroW.Domain.csproj", "src/Core/ScroW.Domain/"]
COPY ["./src/Core/ScroW.Application/ScroW.Application.csproj", "src/Core/ScroW.Application/"]
COPY ["./src/Infrastructure/ScroW.Infrastructure/ScroW.Infrastructure.csproj", "src/Infrastructure/ScroW.Infrastructure/"]
# COPY ["./src/Infrastructure/ScroW.Persistence/ScroW.Persistence.csproj", "src/Infrastructure/ScroW.Persistence/"]
COPY ["./src/Api/ScroW.Api/ScroW.Api.csproj", "src/Api/ScroW.Api/"]

COPY nuget.config .
RUN dotnet restore "src/Api/ScroW.Api/ScroW.Api.csproj"
COPY . .
WORKDIR /src
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScroW.Api.dll"]
