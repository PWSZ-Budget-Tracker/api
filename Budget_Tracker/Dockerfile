FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
#COPY ["Budget_Tracker/Budget_Tracker.csproj", "Budget_Tracker/"]
COPY . Budget_Tracker/
RUN dotnet restore "Budget_Tracker/Budget_Tracker.csproj"
COPY . .
WORKDIR "/src/Budget_Tracker"
RUN dotnet build "Budget_Tracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Budget_Tracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Budget_Tracker.dll"]