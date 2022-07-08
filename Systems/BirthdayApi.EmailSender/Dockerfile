#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/BirthdayApi.EmailSender/BirthdayApi.EmailSender.csproj", "Systems/BirthdayApi.EmailSender/"]
COPY ["Data/BirthdayApi.Context/BirthdayApi.Context.csproj", "Data/BirthdayApi.Context/"]
COPY ["Data/BirthdayApi.Domain/BirthdayApi.Domain.csproj", "Data/BirthdayApi.Domain/"]
COPY ["Services/BirthdayApi.Settings/BirthdayApi.Settings.csproj", "Services/BirthdayApi.Settings/"]
COPY ["Shared/BirthdayApi.Common/BirthdayApi.Common.csproj", "Shared/BirthdayApi.Common/"]
COPY ["Services/BirthdayApi.RabbitMqService/BirthdayApi.RabbitMqService.csproj", "Services/BirthdayApi.RabbitMqService/"]
COPY ["Services/BirthdayApi.EmailService/BirthdayApi.EmailService.csproj", "Services/BirthdayApi.EmailService/"]
RUN dotnet restore "Systems/BirthdayApi.EmailSender/BirthdayApi.EmailSender.csproj"
COPY . .
WORKDIR "/src/Systems/BirthdayApi.EmailSender"
RUN dotnet build "BirthdayApi.EmailSender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirthdayApi.EmailSender.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BirthdayApi.EmailSender.dll"]