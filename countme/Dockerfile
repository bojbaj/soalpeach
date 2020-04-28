FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CountMe/CountMe.csproj", "./"]
RUN dotnet restore "./CountMe.csproj"
COPY ./CountMe/ .
WORKDIR "/src/."
RUN dotnet build "CountMe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CountMe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CountMe.dll"]
