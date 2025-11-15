FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY Shop.Web/bin/Release/net9.0/publish/ .
ENTRYPOINT ["dotnet", "Shop.Web.dll"]