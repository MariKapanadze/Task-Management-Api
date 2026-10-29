FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Task_Management_Api/Task_Management_Api.csproj", "Task_Management_Api/"]
RUN dotnet restore "Task_Management_Api/Task_Management_Api.csproj"

COPY . .
WORKDIR /src/Task_Management_Api
RUN dotnet publish "Task_Management_Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Task_Management_Api.dll"]
