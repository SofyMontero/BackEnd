# 🚀 Creación de un Módulo en FacturaE

Este documento guía paso a paso la creación de un nuevo módulo en FacturaE, incluyendo la **DLL**, la **Lambda** y el **proyecto React**.

---

## 📂 1. Creación de la Carpeta del Módulo

Antes de comenzar, crea la carpeta principal del módulo en la ubicación correspondiente:

```sh
mkdir [ModuleName]
cd [ModuleName]
```

Ejemplo para un módulo llamado **Nomina**:

```sh
mkdir Nomina
cd Nomina
```

---

## 🏗️ 2. Creación de la DLL

Generamos la biblioteca de clases con .NET:

```sh
dotnet new classlib -n FacturaE.[ModuleName] -f net8.0
```

Ejemplo:

```sh
dotnet new classlib -n FacturaE.Nomina -f net8.0
```

---

## ⚡ 3. Creación de la Lambda

Creamos el proyecto **Serverless** con una API mínima de .NET:

```sh
dotnet new serverless.AspNetCoreMinimalAPI -n FacturaE.[ModuleName].Lambda
```

Ejemplo:

```sh
dotnet new serverless.AspNetCoreMinimalAPI -n FacturaE.Nomina.Lambda
```

---

## 🛠️ 4. Creación de la Solución

Creamos la solución que contendrá los proyectos del módulo:

```sh
dotnet new sln -n [ModuleName]
```

Ejemplo:

```sh
dotnet new sln -n Nomina
```

### 📌 4.1 Agregar los proyectos a la solución

```sh
dotnet sln add .\FacturaE.[ModuleName]\FacturaE.[ModuleName].csproj
dotnet sln add .\FacturaE.[ModuleName].Lambda\FacturaE.[ModuleName].Lambda.csproj
dotnet sln add ..\Common\FacturaE.Common\FacturaE.Common.csproj
```

Ejemplo:

```sh
dotnet sln add .\FacturaE.Nomina\FacturaE.Nomina.csproj
dotnet sln add .\FacturaE.Nomina.Lambda\FacturaE.Nomina.Lambda.csproj
dotnet sln add ..\Common\FacturaE.Common\FacturaE.Common.csproj
```

### 📌 4.2 Agregar referencias entre proyectos

```sh
dotnet add .\FacturaE.[ModuleName]\FacturaE.[ModuleName].csproj reference ..\Common\FacturaE.Common\FacturaE.Common.csproj
dotnet add .\FacturaE.[ModuleName].Lambda\FacturaE.[ModuleName].Lambda.csproj reference .\FacturaE.[ModuleName]\FacturaE.[ModuleName].csproj
```

Si es necesario, también agregar:

```sh
dotnet add .\FacturaE.[ModuleName].Lambda\FacturaE.[ModuleName].Lambda.csproj reference ..\Common\FacturaE.Common\FacturaE.Common.csproj
```

---

## 🏗️ 5. Configuración Inicial del Módulo

1. **Configurar Dependency Injection**
2. **Configurar el Journal** (Processor en la Lambda y Writer)
3. **Configurar el Service Base** del módulo
4. **Configurar el `Program.cs` de la Lambda**
5. **Configurar el `serverless.template`**
6. **Configurar el `aws-lambda-tools-defaults.json`** para el ambiente `dev`
7. **Configurar el `launch.json`** con la sección del módulo
8. **Configurar la `tasks.json`** con el deploy del módulo

---

## 🛠️ 6. Construcción y Restauración

Ejecutar el siguiente comando para limpiar, restaurar y compilar el código:

```sh
dotnet clean; dotnet restore; dotnet build;
```

---

## 🎨 7. Creación del Proyecto React

Creamos el proyecto React con Vite y TypeScript:

```sh
npm create vite@latest [ProyectName] -- --template react-ts
```

Ejemplo:

```sh
npm create vite@latest facturae.nomina.react -- --template react-ts
```

Renombrar el proyecto a formato **PascalCase** (FacturaE.Nomina.React).

---

## 📦 8. Instalación de Dependencias

1. Agregar la librería común de React:

```sh
npm i ..\..\Common\FacturaE.Common.React.Library\
```

2. Instalar dependencias del proyecto:

```sh
npm i
```

3. Instalar dependencias obligatorias:

```sh
npm i tailwindcss-animate
```

4. Instalar dependencias de desarrollo:

```sh
npm i -D tailwindcss postcss autoprefixer
```

---

## 🔧 9. Configuración del Proyecto React

### 9.1 Actualizar `index.html`

Asegurar que los metadatos y configuraciones sean correctos.

### 9.2 Actualizar archivos de configuración

Copiar y ajustar los siguientes archivos:

- `tsconfig.json`
- `vite.config.ts`
- `postcss.config.js`
- `tailwind.config.js`

### 9.3 Copiar archivos de emisión

Copiar los archivos de emisión desde un módulo existente y adaptarlos según sea necesario.

### 9.4 Configurar el enrutamiento

Actualizar los archivos `main.tsx` y `App.tsx`, asegurándose de modificar los **imports** de rutas según el nuevo módulo.
