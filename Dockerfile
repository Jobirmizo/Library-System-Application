FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Library-System-Application.csproj", "./"]
RUN dotnet restore "Library-System-Application.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Library-System-Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library-System-Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library-System-Application.dll"]
