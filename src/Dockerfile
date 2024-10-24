# Используем образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /src

# Копируем csproj и восстанавливаем зависимости
COPY ["DeliveryService/DeliveryService.csproj", "DeliveryService/"]
RUN dotnet restore "DeliveryService/DeliveryService.csproj"

# Копируем всё и собираем приложение
COPY . .
WORKDIR "/src/DeliveryService"
RUN dotnet build "DeliveryService.csproj" -c Release -o /app/build

# Создаем финальный образ на основе .NET Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app

# Копируем собранное приложение из предыдущего этапа
COPY --from=build /app/build .

# Указываем точку входа приложения
ENTRYPOINT ["dotnet", "DeliveryService.dll"]