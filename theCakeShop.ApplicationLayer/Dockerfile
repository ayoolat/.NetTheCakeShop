#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["theCakeShop.ApplicationLayer/theCakeShop.ApplicationLayer.csproj", "theCakeShop.ApplicationLayer/"]
RUN dotnet restore "theCakeShop.ApplicationLayer/theCakeShop.ApplicationLayer.csproj"
COPY . .
WORKDIR "/src/theCakeShop.ApplicationLayer"
RUN dotnet build "theCakeShop.ApplicationLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "theCakeShop.ApplicationLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "theCakeShop.ApplicationLayer.dll"]