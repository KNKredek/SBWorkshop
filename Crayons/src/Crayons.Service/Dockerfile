FROM microsoft/aspnetcore:2.0.0

ADD ./artifacts/. app/

ENV ASPNETCORE_URLS="http://+:5000"
ENV ASPNETCORE_ENVIRONMENT production

WORKDIR app

ENTRYPOINT dotnet Crayons.Service.dll
