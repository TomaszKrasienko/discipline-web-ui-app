FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY discipline-wasm-ui/discipline-wasm-ui.csproj ./discipline-wasm-ui/
RUN dotnet restore ./discipline-wasm-ui/discipline-wasm-ui.csproj --verbosity detailed
COPY . ./
RUN dotnet publish ./discipline-wasm-ui.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "discipline-wasm-ui.dll" ]

ENV ASPNETCORE_ENVIRONMENT="docker"
ENV TZ="Europe/Warsaw"
EXPOSE 80
EXPOSE 443