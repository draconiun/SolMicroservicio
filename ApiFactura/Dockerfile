FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV CnnBd="Data Source=srvventasaaron.database.windows.net;Initial Catalog=dbVentas;User ID=galaxy;Password = A123456789123$;"
ENV UrlSeguridad="http://104.41.231.198:8081/"
ENV ApiNameSeguridad="apifactura"
ENV BusUrl="Endpoint=sb://busgalaxyaaron.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=39uqcbg+zkiLJ0NC/9D8D6rGH49cA8+fNwspceR0q8Y="
ENV BusTopic="pedidosender"
ENV BusSuscriptor="facturasql"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/ApiFactura.dll"]