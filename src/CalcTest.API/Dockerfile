FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/CalcTest.API/CalcTest.API.csproj", "src/CalcTest.API/"]
COPY ["src/CalcTest.Service/CalcTest.Service.csproj", "src/CalcTest.Service/"]
COPY ["src/CalcTest.Crosscutting/CalcTest.Crosscutting.csproj", "src/CalcTest.Crosscutting/"]
COPY ["src/CalcTest.Domain/CalcTest.Domain.csproj", "src/CalcTest.Domain/"]
COPY ["src/CalcTest.IoC/CalcTest.IoC.csproj", "src/CalcTest.IoC/"]
RUN dotnet restore "src/CalcTest.API/CalcTest.API.csproj"
COPY . .
WORKDIR "/src/src/CalcTest.API"
RUN dotnet build "CalcTest.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalcTest.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalcTest.API.dll"]