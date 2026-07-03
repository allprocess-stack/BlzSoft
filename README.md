# BlzSoft — Sistema de Pesaje Vehicular

**BlzSoft** (Balanza Soft) es un sistema de gestión de pesaje vehicular para básculas industriales de camiones. Desarrollado en C# Windows Forms (.NET Framework 4.8), permite registrar el ciclo completo de pesaje de entrada y salida de vehículos, calcular pesos netos, capturar fotografías mediante cámaras IP, y generar reportes imprimibles.

Desarrollado por **COMERSA INGENIERIA E.I.R.L.** — Chala, Caravelí, Arequipa, Perú.

---

## Funcionalidades

### Pesaje
- Comunicación en tiempo real con indicadores de peso vía puerto serie (RS-232)
- Soporte para 4 modelos de indicadores: Flintec TransCELL TI1520, Flintec FT11, XK D9 (genérico), Precia Molen
- Pesaje de entrada: registro de placa, cliente, chofer, producto, peso bruto
- Pesaje de salida: búsqueda por placa, registro de peso de salida, cálculo automático de peso neto
- Captura de fotografías desde cámaras IP RTSP integradas con OpenCV

### Administración de datos maestros
- **Empresas/Clientes**: registro de empresas, RUC, contacto, dirección
- **Productos**: catálogo de productos transportados
- **Operadores/Usuarios**: gestión de usuarios del sistema con roles (Admin/Operador)

### Reportes
- Reportes RDLC (Microsoft ReportViewer) imprimibles:
  - Ticket de ingreso
  - Ticket de salida (completo y parcial)
  - Listado de clientes
  - Listado de productos
  - Reporte consolidado con filtros avanzados

### Seguridad
- Autenticación de usuarios con roles (Admin / Operador)
- Acceso root de respaldo (backdoor) para recuperación del sistema

---

## Tecnologías

| Componente | Tecnología |
|---|---|
| Lenguaje | C# 7.3+ |
| Framework | .NET Framework 4.8 |
| UI | Windows Forms |
| Base de datos | SQL Server (2014+) |
| Acceso a datos | ADO.NET (SQL directo) |
| Cámaras IP | OpenCvSharp 4.13 (OpenCV wrapper) |
| Reportes | Microsoft ReportViewer 2016 (RDLC) |
| Comunicación serie | System.IO.Ports (RS-232) |
| Paquetes | NuGet |

---

## Arquitectura

Aplicación de **una sola capa** (UI + lógica de negocio + acceso a datos en un mismo proyecto). La comunicación entre formularios se realiza mediante campos estáticos compartidos. La configuración del sistema se almacena en archivos planos (`CfgBalanza`, `ConfigCamara`) en el directorio de ejecución.

### Diagrama de flujo básico

```
Login → Main Dashboard (peso en vivo)
         ├── Pesaje de Entrada → captura foto → guarda en BD
         ├── Pesaje de Salida → busca placa → captura foto → calcula neto
         ├── Registros (consulta/modificación)
         ├── Mantenimiento (clientes, productos, operadores)
         ├── Reportes y consolidados
         └── Configuración (BD, cámara, formato tickets)
```

### Base de datos

| Tabla | Descripción |
|---|---|
| `Registros` | Registros de pesaje (entrada/salida) |
| `Empresas` | Clientes y proveedores |
| `Productos` | Catálogo de productos |
| `Usuarios` | Operadores del sistema |

---

## Requisitos del sistema

### Hardware recomendado
- Balanza industrial con indicador de peso y puerto RS-232
- Cámara IP con soporte RTSP (para captura de fotos)
- Computador con Windows 7/10/11

### Software
- Windows 7 SP1 o superior
- .NET Framework 4.8
- SQL Server 2014 o superior
- Microsoft ReportViewer 2016 Runtime (incluido como paquete NuGet)

---

## Instalación

1. Clonar el repositorio:
   ```
   git clone https://github.com/tu-organizacion/BlzSoft.git
   ```

2. Abrir `BlzSoft.sln` en Visual Studio 2019/2022.

3. Restaurar paquetes NuGet:
   ```
   dotnet restore
   ```
   O desde la consola de NuGet:
   ```
   Update-Package -reinstall
   ```

4. Compilar la solución (Build → Build Solution o `Ctrl+Shift+B`).

5. Configurar la conexión a SQL Server y los parámetros de la báscula desde el propio sistema.

---

## Configuración inicial

Al ejecutar por primera vez, configurar:

1. **Conexión BD**: servidor SQL, base de datos, usuario y contraseña
2. **Puerto serie**: COM port y modelo del indicador de peso
3. **Cámara IP**: usuario RTSP, contraseña, IP, puerto, carpetas de fotos
4. **Formato de ticket**: prefijo y máscara de dígitos (ej. "BZ" + "D5" → "BZ-00001")

---

## Uso básico

1. **Iniciar sesión** con credenciales de Administrador u Operador.
2. En el **panel principal** se muestra el peso en vivo de la báscula.
3. **Pesaje de entrada**: ingresar placa, seleccionar cliente/chofer/producto, registrar peso de entrada.
4. **Pesaje de salida**: buscar por placa el registro de entrada, registrar peso de salida; el sistema calcula el peso neto automáticamente.
5. **Reportes**: generar tickets de pesaje o reportes consolidados desde el menú de consultas.

---

## Licencia

Todos los derechos reservados — COMERSA INGENIERIA E.I.R.L.
