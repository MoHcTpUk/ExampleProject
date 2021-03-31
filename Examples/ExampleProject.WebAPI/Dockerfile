#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ExampleProject.WebAPI/ExampleProject.WebAPI.csproj", "ExampleProject.WebAPI/"]
RUN dotnet restore "ExampleProject.WebAPI/ExampleProject.WebAPI.csproj"
COPY . .
WORKDIR "/src/ExampleProject.WebAPI"
RUN dotnet build "ExampleProject.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExampleProject.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExampleProject.WebAPI.dll"]