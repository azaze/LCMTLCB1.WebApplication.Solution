#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LCMTLCB1WebApplication/LCMTLCB1WebApplication.csproj", "LCMTLCB1WebApplication/"]
RUN dotnet restore "LCMTLCB1WebApplication/LCMTLCB1WebApplication.csproj"
COPY . .
WORKDIR "/src/LCMTLCB1WebApplication"
RUN dotnet build "LCMTLCB1WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LCMTLCB1WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LCMTLCB1WebApplication.dll"]