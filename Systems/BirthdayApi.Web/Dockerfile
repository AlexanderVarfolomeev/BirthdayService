FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/BirthdayApi.Web/BirthdayApi.Web.csproj", "Systems/BirthdayApi.Web/BirthdayApi.Web.csproj"]
RUN dotnet restore "Systems/BirthdayApi.Web/BirthdayApi.Web.csproj"
COPY . .
WORKDIR "/src/Systems/BirthdayApi.Web"
RUN dotnet build "BirthdayApi.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirthdayApi.Web.csproj" -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /var/www/web

COPY --from=publish /app/publish/wwwroot .
COPY Systems/BirthdayApi.Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80