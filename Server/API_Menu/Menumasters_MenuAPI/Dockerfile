#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Menumasters_MenuAPI/Menumasters_MenuAPI.csproj", "Menumasters_MenuAPI/"]
COPY ["Bussines_MenuAPI/Bussines_MenuAPI.csproj", "Bussines_MenuAPI/"]
COPY ["Bussiness_API_Contract/Bussiness_API_Contract.csproj", "Bussiness_API_Contract/"]
COPY ["DateLayer_Bussiness_Contract/DateLayer_Bussiness_Contract.csproj", "DateLayer_Bussiness_Contract/"]
COPY ["DataLayer_MenuAPI/DataLayer_MenuAPI.csproj", "DataLayer_MenuAPI/"]
COPY ["MenuAPI_Models/MenuAPI_Models.csproj", "MenuAPI_Models/"]

RUN dotnet restore "Menumasters_MenuAPI/Menumasters_MenuAPI.csproj"

COPY . .

RUN dotnet build "Menumasters_MenuAPI/Menumasters_MenuAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Menumasters_MenuAPI/Menumasters_MenuAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Menumasters_MenuAPI.dll"]
