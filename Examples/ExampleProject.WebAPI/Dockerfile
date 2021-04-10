#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Examples/ExampleProject.WebAPI/ExampleProject.WebAPI.csproj", "Examples/ExampleProject.WebAPI/"]
COPY ["Examples/ExampleProject.App/ExampleProject.App.csproj", "Examples/ExampleProject.App/"]
COPY ["Examples/ExampleProject.BLL/ExampleProject.BLL.csproj", "Examples/ExampleProject.BLL/"]
COPY ["Examples/ExampleProject.DAL/ExampleProject.DAL.csproj", "Examples/ExampleProject.DAL/"]
COPY ["Core/Core.DAL/Core.DAL.csproj", "Core/Core.DAL/"]
COPY ["Core/Core.BLL/Core.BLL.csproj", "Core/Core.BLL/"]
RUN dotnet restore "Examples/ExampleProject.WebAPI/ExampleProject.WebAPI.csproj"
COPY . .
WORKDIR "/src/Examples/ExampleProject.WebAPI"
RUN dotnet build "ExampleProject.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExampleProject.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExampleProject.WebAPI.dll"]
