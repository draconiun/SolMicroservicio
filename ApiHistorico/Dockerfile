FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV UrlSeguridad="http://23.102.34.16:8081/"
ENV ApiNameSeguridad="apihistorico"
ENV BusUrl="Endpoint=sb://busgalaxyayma.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=QhhQ9HUihfGSsrgx4sBw//ya7M8CSGb/DvlMW/ftjfk="
ENV BusTopic="pedidosender"
ENV BusSuscriptor="facturahistorico"
ENV MongoServer="mongodb://facturadbayma:T6lQxZpOjAub63UOMvRkPmZsBruR7mxd81yQF9DZOnk0jggNPfSXVVgVX6KLZvBWRC4XrxpzhTlKnLVmAecS4g==@facturadbayma.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@facturadbayma@&retryWrites=false"
ENV MongoDbname="ventasdb"
ENV MongoColName="factura"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/ApiHistorico.dll"]