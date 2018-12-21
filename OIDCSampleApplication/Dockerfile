FROM microsoft/aspnetcore:2.0
ARG VERSION=local

ENV CONFIG_FILE_PATH=/opt/target/Config/config.json

WORKDIR /opt

COPY target/ .  

EXPOSE 80 
ENTRYPOINT ["dotnet", "OIDCSampleApplication.dll"]