FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 8080

ENV ASPNETCORE_URLS=https://*:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BugTrackerApiBilling/BugTrackerApiBilling.csproj", "BugTrackerApiBilling/"]
RUN dotnet restore "BugTrackerApiBilling/BugTrackerApiBilling.csproj"
COPY . .
WORKDIR "/src/BugTrackerApiBilling"
RUN dotnet build "BugTrackerApiBilling.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BugTrackerApiBilling.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BugTrackerApiBilling.dll"]