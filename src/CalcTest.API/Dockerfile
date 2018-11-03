#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["CalcTest.API/CalcTest.API.csproj", "src/CalcTest.API/"]
COPY ["CalcTest.Service/CalcTest.Service.csproj", "src/CalcTest.Service/"]
COPY ["CalcTest.Crosscutting/CalcTest.Crosscutting.csproj", "src/CalcTest.Crosscutting/"]
COPY ["CalcTest.Domain/CalcTest.Domain.csproj", "src/CalcTest.Domain/"]
COPY ["CalcTest.IoC/CalcTest.IoC.csproj", "src/CalcTest.IoC/"]
RUN dotnet restore "src/CalcTest.API/CalcTest.API.csproj"
COPY . .
WORKDIR "/src/CalcTest.API"
RUN dotnet build "CalcTest.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalcTest.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalcTest.API.dll"]