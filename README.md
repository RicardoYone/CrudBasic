# CRUD de Productos - Angular + C# + SQL Server

Este proyecto es una aplicación CRUD completa para la gestión de productos, desarrollada con Angular en el frontend y C# en el backend, utilizando SQL Server como base de datos.

## 🚀 Descripción del Proyecto

### ¿Qué es un CRUD?
CRUD es el acrónimo de **Create, Read, Update, Delete** (Crear, Leer, Actualizar, Eliminar). Es un conjunto de operaciones básicas que permiten gestionar datos en una aplicación. Este proyecto implementa estas operaciones para administrar productos.

## 🛠️ Tecnologías Utilizadas

### Frontend
- **Angular** - Framework de desarrollo web
- **Standalone Components** - Arquitectura moderna de Angular sin módulos

### Backend
- **C# (.NET)** - Lenguaje de programación y framework
- **CQRS Pattern** - Patrón de diseño para separar operaciones de lectura y escritura
- **Entity Framework** - ORM para interactuar con la base de datos

### Base de Datos
- **SQL Server** - Sistema de gestión de bases de datos relacional

## 📋 Funcionalidades

### Autenticación
- Sistema de inicio de sesión
- **Credenciales de acceso:**
  - Usuario: `ricardo`
  - Contraseña: `ricardo`
- **JWT Token:** Al autenticarse, se genera un token que se utiliza para todas las operaciones subsecuentes
- **Seguridad:** Las contraseñas se encriptan y desencriptan de forma segura en el backend

### Gestión de Productos
Una vez autenticado, el usuario es redirigido a la sección de productos donde puede:
- ✅ **Ver** todos los productos
- ➕ **Agregar** nuevos productos
- ✏️ **Actualizar** productos existentes
- 🗑️ **Eliminar** productos

*Todas las operaciones requieren el token JWT obtenido en el login*

## 🔧 Instalación y Configuración

### Requisitos Previos
- Node.js y npm
- .NET SDK
- SQL Server

### 1. Configurar la Base de Datos

En la raíz del repositorio encontrarás el archivo `DataBase.sql`. Ejecuta este script en SQL Server para crear automáticamente la base de datos con tablas y datos de prueba.

```sql
-- Ejecutar el archivo DataBase.sql en SQL Server Management Studio
-- o mediante sqlcmd
```

### 2. Configurar el Backend

```bash
cd Backend
dotnet restore
dotnet run
```

### 3. Configurar el Frontend

```bash
cd Frontend
npm install
ng serve
```

La aplicación estará disponible en `http://localhost:4200`

## 📁 Estructura del Proyecto

```
proyecto/
│
├── Frontend/           # Aplicación Angular (Standalone)
│   ├── src/
│   └── angular.json
│
├── Backend/           # API en C# con CQRS
│   ├── Controllers/
│   ├── Commands/
│   ├── Queries/
│   └── Models/
│
└── DataBase.sql       # Script de base de datos
```

## 🏗️ Arquitectura

### Frontend (Angular)
- Componentes standalone para mejor modularidad
- Servicios para comunicación con el backend
- Guards para protección de rutas
- **Interceptor HTTP:** Maneja todas las respuestas del backend con formato estandarizado
  - `statusCode`: Código de estado de la operación
  - `messageError`: Mensaje de error (si aplica)
  - `data`: Datos de respuesta

### Backend (C#)
- **CQRS Pattern:** Separación clara entre comandos (escritura) y consultas (lectura)
- **Entity Framework:** Mapeo objeto-relacional para interactuar con SQL Server
- **Autenticación JWT:** Sistema de tokens para operaciones seguras
- **Encriptación de contraseñas:** Las contraseñas se encriptan y desencriptan de forma segura
- API RESTful para operaciones CRUD con respuestas estandarizadas

## 📝 Notas Adicionales

### Formato de Respuestas del Backend
Todas las respuestas del backend siguen un formato estandarizado:
```json
{
  "statusCode": 200,
  "messageError": "",
  "data": { /* datos de respuesta */ }
}
```
Este formato es manejado automáticamente por el interceptor HTTP en el frontend.

### Seguridad
- Las contraseñas se encriptan antes de almacenarse en la base de datos
- Sistema de desencriptación para validación de credenciales
- Autenticación mediante JWT token
- El token se incluye automáticamente en todas las peticiones protegidas

### Consideraciones
- El script `DataBase.sql` incluye datos de prueba para facilitar el testing
- Las credenciales de acceso son de demostración y deben cambiarse en producción
- El patrón CQRS permite escalar la aplicación de manera eficiente

## 📄 Licencia

Este proyecto está bajo la Licencia MIT.

---

⭐ Si te gusta este proyecto, no olvides darle una estrella en GitHub
