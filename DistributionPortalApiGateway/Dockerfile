FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

ENV APP_HOME /opt/app
RUN mkdir $APP_HOME
WORKDIR $APP_HOME

COPY DistributionPortalApiGateway/*.csproj $APP_HOME/
RUN cd $APP_HOME && dotnet restore

COPY DistributionPortalApiGateway/ $APP_HOME/
RUN cd $APP_HOME && dotnet build

FROM build AS publish
WORKDIR $APP_HOME
RUN cd $APP_HOME && dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8099
ENV ASPNETCORE_ENVIRONMENT=docker
COPY --from=publish /opt/app/out ./
ENTRYPOINT ["dotnet", "DistributionPortalApiGateway.dll"]