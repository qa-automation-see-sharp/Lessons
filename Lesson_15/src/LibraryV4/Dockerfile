FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Lesson_15/src/LibraryV4/LibraryV4.csproj", "Lesson_15/src/LibraryV4/"]
RUN dotnet restore "Lesson_15/src/LibraryV4/LibraryV4.csproj"
COPY . .
WORKDIR "/src/Lesson_15/src/LibraryV4"
RUN dotnet build "LibraryV4.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LibraryV4.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryV4.dll"]
