FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY QBox.sln ./
COPY QBoxCore.Api/QBoxCore.Api.csproj QBoxCore.Api/
COPY QBoxCore.Api.DTO/QBoxCore.Api.DTO.csproj QBoxCore.Api.DTO/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/QBoxCore.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QBoxCore.Api.dll"]
