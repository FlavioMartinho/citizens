FROM microsoft/dotnet:2.2-sdk

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_URLS=http://*:5000

EXPOSE 5000

WORKDIR /var/www/citizensapp

CMD ["/bin/bash", "-c", "dotnet restore && dotnet watch run"]
