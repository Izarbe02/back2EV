
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildApp
    WORKDIR /src
    
    COPY . /src
    
    WORKDIR /src
    
    RUN dotnet restore "back2EV.csproj"
    
    RUN dotnet publish "back2EV.csproj" -c Release -o /app --no-restore
    
    FROM mcr.microsoft.com/dotnet/aspnet:8.0
    WORKDIR /application
    
    COPY --from=buildApp /app ./
    
    EXPOSE 80
    
    ENTRYPOINT ["dotnet", "back2EV.dll"]
    