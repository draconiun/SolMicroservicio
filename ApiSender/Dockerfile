FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV UrlSeguridad="http://104.41.231.198:8081/"
ENV ApiNameSeguridad="apisender"
ENV BusUrl="Endpoint=sb://busgalaxyaaron.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=39uqcbg+zkiLJ0NC/9D8D6rGH49cA8+fNwspceR0q8Y="
ENV BusTopic="pedidosender"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/ApiSender.dll"]