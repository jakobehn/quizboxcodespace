FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY QBox.sln ./
COPY QBoxCore.Web/QBoxCore.Web.csproj QBoxCore.Web/
COPY QBoxCore.Api.Client/QBoxCore.Api.Client.csproj QBoxCore.Api.Client/
COPY QBoxCore.Api.DTO/QBoxCore.Api.DTO.csproj QBoxCore.Api.DTO/
COPY QBoxCore.Logging/QBoxCore.Logging.csproj QBoxCore.Logging/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/QBoxCore.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QBoxCore.Web.dll"]
