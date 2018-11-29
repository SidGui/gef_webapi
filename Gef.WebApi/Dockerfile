FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Gef.WebApi/Gef.WebApi.csproj", "Gef.WebApi/"]
RUN dotnet restore "Gef.WebApi/Gef.WebApi.csproj"
COPY . .
WORKDIR "/src/Gef.WebApi"
RUN dotnet build "Gef.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gef.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gef.WebApi.dll"]