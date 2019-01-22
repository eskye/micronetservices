FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Learn.MicroServices.MovieStore/Learn.MicroServices.MovieStore.csproj Learn.MicroServices.MovieStore/
RUN dotnet restore Learn.MicroServices.MovieStore/Learn.MicroServices.MovieStore.csproj
COPY . .
WORKDIR /src/Learn.MicroServices.MovieStore
RUN dotnet build Learn.MicroServices.MovieStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Learn.MicroServices.MovieStore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Learn.MicroServices.MovieStore.dll"]
