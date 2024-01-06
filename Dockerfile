FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

RUN dotnet publish -c Release -r linux-x64 -o out --self-contained

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "TiseShortUrl.dll"]
