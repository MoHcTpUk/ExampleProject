#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ExampleProject.ConsoleApp/ExampleProject.ConsoleApp.csproj", "ExampleProject.ConsoleApp/"]
COPY ["ExampleProject.App/ExampleProject.App.csproj", "ExampleProject.App/"]
COPY ["ExampleProject.BLL/ExampleProject.BLL.csproj", "ExampleProject.BLL/"]
COPY ["ExampleProject.DAL/ExampleProject.DAL.csproj", "ExampleProject.DAL/"]
RUN dotnet restore "ExampleProject.ConsoleApp/ExampleProject.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/ExampleProject.ConsoleApp"
RUN dotnet build "ExampleProject.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExampleProject.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExampleProject.ConsoleApp.dll"]