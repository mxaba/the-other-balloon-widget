ARG REPO=mcr.microsoft.com/dotnet
FROM $REPO/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM $REPO/sdk:5.0-buster-slim AS build
ENV BuildingDocker true
WORKDIR /src
COPY ["the-other-balloon-widget.csproj", ""]
RUN dotnet restore "the-other-balloon-widget.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "the-other-balloon-widget.csproj" -c Release -o /app/build

FROM node:12-alpine as build-node
WORKDIR ClientApp
COPY ClientApp/package.json .
COPY ClientApp/package-lock.json .
RUN npm install
COPY ClientApp/ .
RUN npm run-script build

FROM build AS publish
RUN dotnet publish "the-other-balloon-widget.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build-node /ClientApp/build ./ClientApp/build
CMD ASPNETCORE_URLS=http://*:$PORT dotnet the-other-balloon-widget.dll