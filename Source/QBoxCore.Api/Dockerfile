FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY QBoxCore.Api/QBoxCore.Api.csproj QBoxCore.Api/
COPY QBoxCore.Api.DTO/QBoxCore.Api.DTO.csproj QBoxCore.Api.DTO/
RUN dotnet restore QBoxCore.Api/QBoxCore.Api.csproj
COPY . .
WORKDIR /src/QBoxCore.Api
RUN dotnet build QBoxCore.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish QBoxCore.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QBoxCore.Api.dll"]
