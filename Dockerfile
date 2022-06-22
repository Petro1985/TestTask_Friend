FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5265
ENV ASPNETCORE_URLS="http://*:5265"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestTask_Friend/TestTask_Friend.csproj", "TestTask_Friend/"]
COPY ["TestTask_Friend.DAL/TestTask_Friend.DAL.csproj", "TestTask_Friend.DAL/"]
RUN dotnet restore "TestTask_Friend/TestTask_Friend.csproj"
COPY . .
WORKDIR "/src/TestTask_Friend"
RUN dotnet build "TestTask_Friend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTask_Friend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask_Friend.dll"]
