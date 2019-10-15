FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS builder
WORKDIR /app
COPY . .
RUN cd ./APIModeloDDD/APIModeloDDD.presentation.webapi
RUN dotnet restore
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/samples:aspnetapp
WORKDIR /app
COPY --from=builder /out .
ENTRYPOINT ["dotnet", "APIModeloDDD.presentation.webapi.dll"]
EXPOSE 80