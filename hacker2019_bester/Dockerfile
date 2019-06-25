FROM microsoft/dotnet:2.1-sdk

WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj  ./
RUN dotnet restore
# copy everything else and build
COPY . ./

RUN dotnet publish -c Release -o out

WORKDIR /app/out

ENTRYPOINT ["dotnet", "hacker2019_bester.dll"]