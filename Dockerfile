# Usa la imagen oficial del SDK de .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Crear usuario y grupo no root
RUN useradd -m -d /home/appuser -s /bin/bash -u 1000 appuser

# Crear el directorio de trabajo y asignar permisos
WORKDIR /app
RUN mkdir -p /app && chown -R appuser:appuser /app

# Cambiar al usuario no root
USER appuser

# Exponer el puerto de la aplicación
EXPOSE 80

# Mantiene el contenedor en modo interactivo
CMD ["bash"]
