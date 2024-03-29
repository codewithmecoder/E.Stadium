FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7788

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY E.Stadium.sln ./
COPY data ./

COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore -v n
COPY . ./
RUN dotnet build -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "E.Stadium.Api/E.Stadium.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:7788
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E.Stadium.Api.dll"]