FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV UrlSeguridad="http://104.41.231.198:8081/"
ENV ApiNameSeguridad="apihistorico"
ENV BusUrl="Endpoint=sb://busgalaxyaaron.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=39uqcbg+zkiLJ0NC/9D8D6rGH49cA8+fNwspceR0q8Y="
ENV BusTopic="pedidosender"
ENV BusSuscriptor="facturahistorico"
ENV MongoServer="mongodb://facturadbaaron:jjKKULL0y4mz7xlQ4ogRF6bS9AfYEf0XeqypiClhAdJ3QKebiLV9lJYNUjcBfLopLoOYtQ9NOsn9FppOLBXH5w==@facturadbaaron.documents.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@facturadbaaron@&retryWrites=false"
ENV MongoDbname="ventasdb"
ENV MongoColName="factura"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/ApiHistorico.dll"]