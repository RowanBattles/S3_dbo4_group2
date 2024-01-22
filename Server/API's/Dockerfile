#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["MenuMasters API/MenuMasters API.csproj", "MenuMasters API/"]
COPY ["Bussiness/Bussiness.csproj", "Bussiness/"]
COPY ["Contract_API_Bussiness/Contract_API_Bussiness.csproj", "Contract_API_Bussiness/"]
COPY ["Contract_Data_Bussiness/Contract_Data_Bussiness.csproj", "Contract_Data_Bussiness/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Models/Models.csproj", "Models/"]

RUN dotnet restore "MenuMasters API/MenuMasters API.csproj"

COPY . .

RUN dotnet build "MenuMasters API/MenuMasters API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MenuMasters API/MenuMasters API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MenuMasters API.dll"]
