﻿FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app

RUN ["dotnet", "restore", "--source", "https://api.nuget.org/v3/index.json", "--source", "https://www.myget.org/F/devwarsztaty-basser/api/v3/index.json", "--no-cache"]
RUN ["dotnet", "build"]

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS https://*:5000

ENTRYPOINT ["dotnet", "run"]