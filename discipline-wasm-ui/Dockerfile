FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish ./discipline-wasm-ui.sln -c Release -o out

FROM nginx:alpine AS runtime
WORKDIR /usr/share/nginx/html
COPY --from=build-env /app/out/wwwroot .
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80