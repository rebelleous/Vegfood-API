#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["VegFoods.Api/VegFoods.Api.csproj", "VegFoods.Api/"]
COPY ["VegFoods.Core/VegFoods.Core.csproj", "VegFoods.Core/"]
COPY ["VegFoods.Services/VegFoods.Services.csproj", "VegFoods.Services/"]
RUN dotnet restore "VegFoods.Api/VegFoods.Api.csproj"
COPY . .
WORKDIR "/src/VegFoods.Api"
RUN dotnet build "VegFoods.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VegFoods.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VegFoods.Api.dll"]
