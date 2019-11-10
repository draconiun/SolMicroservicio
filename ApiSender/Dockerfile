FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV UrlSeguridad="http://23.102.34.16:8081/"
ENV ApiNameSeguridad="apisender"
ENV BusUrl="Endpoint=sb://busgalaxyayma.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=QhhQ9HUihfGSsrgx4sBw//ya7M8CSGb/DvlMW/ftjfk="
ENV BusTopic="pedidosender"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/ApiSender.dll"]