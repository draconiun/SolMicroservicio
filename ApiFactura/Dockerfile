FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV CnnBd="Data Source=srvventasayma.database.windows.net;Initial Catalog=dbVentas;User ID=galaxy;Password = A123456789123$;"
ENV UrlSeguridad="http://23.102.34.16:8081/"
ENV ApiNameSeguridad="apifactura"
ENV BusUrl="Endpoint=sb://busgalaxyayma.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=QhhQ9HUihfGSsrgx4sBw//ya7M8CSGb/DvlMW/ftjfk="
ENV BusTopic="pedidosender"
ENV BusSuscriptor="facturasql"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/ApiFactura.dll"]