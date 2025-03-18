# Usa la imagen oficial del SDK de .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Exponer el puerto de la aplicación
EXPOSE 80

# Mantiene el contenedor en modo interactivo
CMD ["bash"]
