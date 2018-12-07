FROM microsoft/aspnetcore:2.0
ARG VERSION=local

WORKDIR /opt
COPY opt/netcoreapp2.0 .

EXPOSE 80 
ENTRYPOINT ["dotnet", "OIDCSampleApplication.dll"]
