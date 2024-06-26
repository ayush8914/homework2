#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Homework2/Homework2.csproj", "Homework2/"]
RUN dotnet restore "Homework2/Homework2.csproj"
COPY . .
WORKDIR "/src/Homework2"
RUN dotnet build "Homework2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Homework2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod 777 /app/wwwroot
RUN chmod 777 /app/wwwroot/blackboard
RUN chmod 777 /app/wwwroot/posted_assignments
RUN chmod 777 /app/wwwroot/submitted_assignments
ENTRYPOINT ["dotnet", "Homework2.dll"]