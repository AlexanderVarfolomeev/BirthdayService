#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Systems/BirthdayApi.Identity/BirthdayApi.Identity.csproj", "Systems/BirthdayApi.Identity/"]
COPY ["Data/BirthdayApi.Context/BirthdayApi.Context.csproj", "Data/BirthdayApi.Context/"]
COPY ["Data/BirthdayApi.Domain/BirthdayApi.Domain.csproj", "Data/BirthdayApi.Domain/"]
COPY ["Services/BirthdayApi.Settings/BirthdayApi.Settings.csproj", "Services/BirthdayApi.Settings/"]
COPY ["Systems/BirthdayApi.Api/BirthdayApi.Api.csproj", "Systems/BirthdayApi.Api/"]
COPY ["Services/BirthdayApi.BirthdayService/BirthdayApi.BirthdayService.csproj", "Services/BirthdayApi.BirthdayService/"]
COPY ["Shared/BirthdayApi.Common/BirthdayApi.Common.csproj", "Shared/BirthdayApi.Common/"]
COPY ["Services/BirthdayApi.AccountService/BirthdayApi.AccountService.csproj", "Services/BirthdayApi.AccountService/"]
RUN dotnet restore "Systems/BirthdayApi.Identity/BirthdayApi.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/BirthdayApi.Identity"
RUN dotnet build "BirthdayApi.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirthdayApi.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BirthdayApi.Identity.dll"]