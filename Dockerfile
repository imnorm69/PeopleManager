# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Restore first, using just the csproj, so this layer is cached unless
# dependencies change (avoids a full restore on every source edit).
COPY PeopleManager/PeopleManager.csproj PeopleManager/
RUN dotnet restore PeopleManager/PeopleManager.csproj

COPY PeopleManager/ PeopleManager/
RUN dotnet publish PeopleManager/PeopleManager.csproj -c Release -o /app/publish --no-restore

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Kestrel listens on this port inside the container (see docker-compose.yml
# for the host-side port mapping). The app reads DatabasePath itself
# (see docker-compose.yml) to locate the SQLite file.
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "PeopleManager.dll"]
