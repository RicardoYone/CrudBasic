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

### Gestión de Productos
Una vez autenticado, el usuario es redirigido a la sección de productos donde puede:
- ✅ **Ver** todos los productos
- ➕ **Agregar** nuevos productos
- ✏️ **Actualizar** productos existentes
- 🗑️ **Eliminar** productos

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

### Backend (C#)
- **CQRS Pattern:** Separación clara entre comandos (escritura) y consultas (lectura)
- **Entity Framework:** Mapeo objeto-relacional para interactuar con SQL Server
- API RESTful para operaciones CRUD

## 📝 Notas Adicionales

- El script `DataBase.sql` incluye datos de prueba para facilitar el testing
- Las credenciales de acceso son de demostración y deben cambiarse en producción
- El patrón CQRS permite escalar la aplicación de manera eficiente

## 📄 Licencia

Este proyecto está bajo la Licencia MIT.

---

⭐ Si te gusta este proyecto, no olvides darle una estrella en GitHub
