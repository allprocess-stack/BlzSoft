# Análisis Completo del Proyecto BlzSoft

> Sistema de pesaje para balanzas industriales — COMERSA INGENIERÍA E.I.R.L.
> WinForms (.NET Framework 4.8) + SQL Server + OpenCvSharp (cámaras RTSP) + ReportViewer RDLC

---

## Tabla de Contenido

1. [Resumen Ejecutivo](#resumen-ejecutivo)
2. [Stack Tecnológico](#stack-tecnológico)
3. [Arquitectura General](#arquitectura-general)
4. [Flujo de Funcionamiento](#flujo-de-funcionamiento)
5. [Estructura del Proyecto](#estructura-del-proyecto)
6. [Módulos y Formularios](#módulos-y-formularios)
7. [Modelos de Datos](#modelos-de-datos)
8. [Diagrama de Base de Datos](#diagrama-de-base-de-datos)
9. [Acceso a Datos (BD*)](#acceso-a-datos-bd)
10. [Configuración Externa](#configuración-externa)
11. [Comunicación Serial con Balanzas](#comunicación-serial-con-balanzas)
12. [Integración con Cámaras RTSP](#integración-con-cámaras-rtsp)
13. [Sistema de Reportes RDLC](#sistema-de-reportes-rdlc)
14. [Autenticación y Roles](#autenticación-y-roles)
15. [Problemas Conocidos](#problemas-conocidos)

---

## Resumen Ejecutivo

BlzSoft es una aplicación WinForms para gestión de pesaje vehicular en balanzas industriales. Cubre el ciclo completo: registro de entrada → pesaje → salida → reporte. Se comunica en tiempo real con indicadores de peso vía puerto serial, captura fotos desde cámaras IP por RTSP, y genera reportes imprimibles en formato RDLC.

---

## Stack Tecnológico

| Componente | Tecnología |
|---|---|
| Lenguaje | C# 7.3+ |
| Framework | .NET Framework 4.8 |
| UI | Windows Forms |
| Base de datos | SQL Server (2014+) |
| ORM | No — SQL directo (ADO.NET) |
| Cámaras | OpenCvSharp 4.13.0 (wrapper OpenCV) |
| Reportes | Microsoft ReportViewer 2016 (RDLC) |
| Comunicación serial | System.IO.Ports (SerialPort) |
| Gestión de paquetes | NuGet |

---

## Arquitectura General

El proyecto NO sigue una arquitectura por capas formal. La estructura actual es:

```
Capa Única (Mezcla de UI + Lógica + Datos)
   ├── Modelos POCO: Registro, Empresa, Producto, Usuario
   ├── Acceso a Datos: BDregistros, BDempresas, BDproductos, BDuser (estáticos)
   ├── Configuración: ConnFile, ConfigCamara (estáticos, archivos planos)
   └── UI: ~35 formularios WinForms
```

No hay interfaces, inyección de dependencias, ni separación de lógica de negocio. La comunicación entre formularios usa campos estáticos públicos.

---

## Flujo de Funcionamiento

### 1. Inicio de Sesión
```
Program.Main()
  └─ Application.Run(new Login())
       └─ Ingresa credenciales → BDuser.login() o backdoor "root/systemconfig"
            └─ Main.admin (bool estático) controla permisos
                 └─ Show() del formulario Main
```

### 2. Registro de Entrada (Pesaje Inicial)
```
Main.btnEntrada_Click()
  └─ Valida peso disponible (timeoutSerial)
  └─ w_inputEvent.ShowDialog()
       ├─ Carga AutoComplete (clientes, placas, choferes, productos)
       ├─ Calcula ID y número de guía automáticos
       ├─ Timer actualiza peso desde Main.PesoStr cada 200ms
       └─ btnGuardar_Click (async void)
            ├─ Toma foto (TomarFotoAsync → OpenCvSharp VideoCapture RTSP)
            ├─ Crea objeto Registro
            └─ BDregistros.AddRE() → INSERT
                 └─ Si checkbox reporte activo → w_inputReport.ShowDialog()
```

### 3. Registro de Salida (Pesaje Final)
```
Main.btnSalida_Click()
  └─ BDregistros.IDlist() → busca registros con Estado="ENTRADA"
  └─ w_outputEvent(id).ShowDialog()
       ├─ txtPlaca_TextChanged → update_ticket() → BDregistros.LastCheckIn(placa)
       ├─ Timer actualiza peso y calcula peso neto en vivo
       └─ btnGuardar_Click (async void)
            ├─ Toma foto de salida (TomarFotoAsync)
            ├─ PesoNeto = |PesoOut - PesoIn|
            └─ BDregistros.Mod() → UPDATE completo del registro
                 └─ Si reporte activo → w_outputReport.ShowDialog()
```

### 4. Gestión de Clientes (CRUD)
```
wCliente.ShowDialog()
  ├─ btnBusqueda → BDempresas.BuscarEmpresas(tipo, subtipo, empresa, ruc)
  ├─ btnNewClient → w_clientAdd → BDempresas.AddEmpresa()
  ├─ btnModificar → w_clientMod(id) → BDempresas.ModEmpresa()
  ├─ btnEliminar → w_clienteDel(id) → BDempresas.DeleteEmpresa()
  └─ btnReportar → w_clienteReport (RDLC)
```

### 5. Gestión de Productos (CRUD)
```
wProductos.ShowDialog()
  ├─ update_grid → BDproductos.BuscarProductos()
  ├─ btnAgregar → w_productoNew → BDproductos.AddProduct()
  ├─ btnModificar → w_productoMod(id) → BDproductos.Mod()
  ├─ btnEliminar → BDproductos.Delete()
  └─ btnReportar → w_productoReport (RDLC)
```

### 6. Consolidado / Búsqueda Avanzada
```
wConsolidado.ShowDialog()
  ├─ 3 modos de búsqueda:
  │   ├─ General (por tipo/subtipo de empresa)
  │   ├─ Por Cliente (cliente + placa)
  │   └─ Específica (columna + valor)
  ├─ Opcional: filtro por intervalo de fechas
  ├─ update_grid → DataSource = listaRegistros
  └─ btnReportar → w_consolidadoReport (RDLC)
```

### 7. Administración de Operadores
```
wOperadores.ShowDialog()
  ├─ DataGridView con todos los usuarios
  ├─ btnAgregar → w_operadorAdd → BDuser.Add()
  ├─ btnModificar → w_operadorMod(id) → BDuser.Mod()
  └─ btnEliminar → BDuser.Delete()
```

### 8. Configuraciones
```
wConnectionBD → ConnFile: servidor, BD, usuario, password SQL
w_Camara → ConfigCamara: user, password, ip, rtsp, rutas de fotos
wFormatos → Formato de guía: prefijo + máscara de dígitos
```

---

## Estructura del Proyecto

```
BlzSoft/
├── Program.cs                  # Entry point, Mutex anti-multi-instancia
├── Login.cs                     # Login con backdoor root/systemconfig
├── Main.cs                      # Form principal, lectura serial, peso en vivo
│
├── Modelos/
│   ├── Empresa.cs               # POCO: id, tipo, subtipo, empresa, ruc, dirreccion...
│   ├── Producto.cs              # POCO: id, producto, descripcion
│   ├── Registro.cs              # POCO (21 props): Id, Guia, Estado, Placa...
│   └── Usuario.cs               # POCO + 5 estáticos (IDlog, NOMBRElog...)
│
├── Acceso a Datos/
│   ├── BDconnection.cs          # SqlConnection estático (lee ConnFile en cada call)
│   ├── BDregistros.cs           # CRUD Registros (17 métodos, SQL inyectable)
│   ├── BDempresas.cs            # CRUD Empresas (10 métodos, SQL inyectable)
│   ├── BDproductos.cs           # CRUD Productos (9 métodos, SQL inyectable)
│   └── BDuser.cs                # CRUD Usuarios (7 métodos, SQL inyectable)
│
├── Configuración/
│   ├── ConnFile.cs              # Config serial + BD (archivo plano "CfgBalanza")
│   └── ConfigCamara.cs          # Config cámara RTSP (archivo plano "ConfigCamara")
│
├── Formularios CRUD/
│   ├── wCliente.cs              # ABM clientes con DataGridView
│   ├── w_clientAdd.cs           # Form nuevo cliente
│   ├── w_clientMod.cs           # Form modificar cliente
│   ├── w_clienteDel.cs          # Form confirmar eliminación
│   ├── w_clienteInfo.cs         # VACÍO — sin usar
│   ├── wProductos.cs             # ABM productos
│   ├── w_productoNew.cs         # Nuevo producto (static flag)
│   ├── w_productoMod.cs         # Modificar producto (static flag)
│   ├── wOperadores.cs           # ABM operadores
│   ├── w_operadorAdd.cs         # Nuevo operador
│   └── w_operadorMod.cs         # Modificar operador
│
├── Formularios de Pesaje/
│   ├── wInputRegister.cs         # Grid registros de entrada
│   ├── w_inputEvent.cs           # Evento de entrada (peso, foto, guardar)
│   ├── w_inputDel.cs             # Confirmar eliminación entrada
│   ├── w_inputMod.cs             # Modificar registro de entrada
│   ├── wOutputRegister.cs        # Grid registros de salida
│   ├── w_outputEvent.cs         # Evento de salida (peso, foto, guardar)
│   ├── w_outputDel.cs           # Confirmar eliminación salida
│   ├── wConsolidado.cs          # Búsqueda avanzada/consolidado
│   └── w_infoRegistro.cs        # Info detallada de un registro
│
├── Formularios de Cámara/
│   ├── w_Camara.cs              # Configuración de cámara RTSP
│   └── w_ViewCamara.cs          # Vista previa en vivo (bucle infinito ThreadPool)
│
├── Formularios de Reporte (7 uds)/
│   ├── w_inputReport.cs         # Reporte de entrada
│   ├── w_outputReport.cs        # Reporte de salida completo
│   ├── w_outputPartialReport.cs # Reporte de salida parcial
│   ├── w_clienteReport.cs       # Reporte de clientes
│   ├── w_consolidadoReport.cs   # Reporte consolidado
│   ├── w_inforegReport.cs       # Reporte info registro
│   └── w_productoReport.cs      # Reporte productos
│
├── Helpers/
│   ├── VarRPT1.cs               # Variables para reporte clientes
│   ├── VarRPT2.cs               # Variables para reporte entrada/salida
│   └── VarRPT3.cs               # Variables para reporte consolidado
│
├── Reportes RDLC (8 udp)/
│   ├── rep_cliente.rdlc
│   ├── ReportClientes.rdlc
│   ├── ReportConsolidado.rdlc
│   ├── ReportInfoReg.rdlc
│   ├── ReportIngreso.rdlc
│   ├── ReportOutput.rdlc
│   ├── ReportProductos.rdlc
│   └── ReportSalida.rdlc
│
├── Formularios Varios/
│   ├── Form1.cs                 # VACÍO — sin usar
│   ├── wConnectionBD.cs         # Configurar conexión BD
│   ├── wCreditos.cs             # Acerca de / créditos
│   └── wFormatos.cs             # Formato de guía (prefijo, dígitos)
│
└── SqlServerTypes/
    └── Loader.cs                # Carga SQL Server Spatial (msvcr120.dll)
```

---

## Modelos de Datos

### Registro (21 propiedades)
```csharp
Id (int), Guia (string), Estado (string), Placa (string),
Cliente (string), Ruc (string), Chofer (string), Producto (string),
Origen (string), Destino (string), GuiaRemision (string),
PesoIn (string), PesoOut (string), PesoNeto (string),
Modo (string), Observacion (string),
FechaEntrada (string), FechaSalida (string),
Usuario (string), RutaFotoEntrada (string), RutaFotoSalida (string)
```

### Empresa (12 propiedades)
```csharp
id (int), tipo (string), subtipo (string), empresa (string),
ruc (string), dirreccion (string), telefono (string),
contacto (string), correo (string), informacion (string),
fechacreacion (string), usuario (string)
```

### Producto (3 propiedades)
```csharp
id (int), producto (string), descripcion (string)
```

### Usuario (5 propiedades de instancia + 5 estáticas)
```csharp
// Instancia
id (int), nombre (string), user (string), password (string), tipo (string)
// Estáticas (sesión actual)
static IDlog, NOMBRElog, USERlog, PASSWORDlog, TIPOlog
```

---

## Diagrama de Base de Datos

### Tabla `Registros`
| Columna | Tipo | Descripción |
|---|---|---|
| Id | int (PK) | Auto-incremental |
| Guia | varchar(20) | Número de ticket/guía |
| Estado | varchar(20) | ENTRADA / SALIDA |
| Placa | varchar(50) | Placa del vehículo |
| Cliente | varchar(100) | Nombre del cliente |
| Ruc | varchar(20) | RUC del cliente |
| Chofer | varchar(150) | Nombre del conductor |
| Producto | varchar(100) | Producto transportado |
| Origen | varchar(100) | Lugar de origen |
| Destino | varchar(100) | Lugar de destino |
| GuiaRemision | varchar(100) | Nro guía de remisión |
| Pesoln | varchar(20) | Peso de entrada (Kg) |
| PesoOut | varchar(20) | Peso de salida (Kg) |
| PesoNeto | varchar(20) | Peso neto (Kg) |
| Modo | varchar(20) | manual / automatico |
| Observacion | varchar(300) | Observaciones |
| FechaEntrada | datetime | Fecha y hora de entrada |
| FechaSalida | datetime | Fecha y hora de salida |
| Usuario | varchar(50) | Operador que registró |
| RutaFotoEntrada | varchar(100) | Ruta archivo foto entrada |
| RutaFotoSalida | varchar(100) | Ruta archivo foto salida |

### Tabla `Empresas`
| Columna | Tipo |
|---|---|
| Id | int (PK) |
| Tipo | varchar(50) |
| SubTipo | varchar(50) |
| Empresa | varchar(100) |
| Ruc | varchar(20) |
| Dirreccion | varchar(100) |
| Telefono | varchar(20) |
| Contacto | varchar(100) |
| Correo | varchar(100) |
| Informacion | varchar(200) |
| FechaCreacion | datetime |
| Usuario | varchar(50) |

### Tabla `Productos`
| Columna | Tipo |
|---|---|
| Id | int (PK) |
| Producto | varchar(100) |
| Descripcion | varchar(200) |

### Tabla `Usuarios`
| Columna | Tipo |
|---|---|
| Id | int (PK) |
| Nombre | varchar(50) |
| Usuario | varchar(50) |
| Password | varchar(50) |
| Tipo | varchar(20) |

---

## Acceso a Datos (BD*)

### BDconnection.cs
- Abre conexión SQL Server con credenciales desde `ConnFile`
- **Problema**: Llama a `ConnFile.Load()` (lectura de disco) en cada `ObtenerConexion()`

### BDregistros.cs (21 métodos)
| Método | Función | SQL |
|---|---|---|
| `readList(reader)` | Mapea DataReader → List\<Registro\> (21 cols) | — |
| `readRegistro(reader)` | Mapea DataReader → un Registro (21 cols) | — |
| `Buscar(cliente, placa)` | Búsqueda por cliente y placa | SELECT con LIKE |
| `Buscar(cliente, placa, estado)` | Búsqueda con filtro estado | SELECT con LIKE |
| `Buscar(cliente, placa, estado, fechas, evento)` | Búsqueda con intervalo fechas | EXEC search_registro_interval |
| `AddRE(p)` | Insertar nuevo registro | INSERT INTO |
| `Delete(id)` | Eliminar por ID | DELETE |
| `Info(pId)` | Obtener un registro por ID | SELECT |
| `LastCheckIn(placa)` | Última entrada activa por placa | SELECT TOP 1 |
| `Mod(p)` | Modificar registro completo | UPDATE |
| `IDlist()` | IDs de registros con estado ENTRADA | SELECT ID |
| `Guialist()` | Guías de registros con estado ENTRADA | SELECT Guia |
| `NextId()` | Próximo ID | EXEC next_id |
| `LastGuia()` | Última guía registrada | SELECT TOP 1 Guia |
| `HysGeneral(tipo, subtipo)` | Búsqueda por tipo de empresa | SELECT con subquery |
| `HysGeneral(tipo, subtipo, fechas)` | Búsqueda por tipo + fechas | SELECT con subquery + fechas |
| `PlacasList(cliente)` | Placas distintas por cliente | SELECT DISTINCT |
| `PlacasList()` | Todas las placas | SELECT DISTINCT |
| `ChoferesList()` | Todos los choferes | SELECT DISTINCT |
| `PlacasListIN()` | Placas en estado ENTRADA | SELECT DISTINCT |
| `ClientByPlaca(placa)` | Cliente asociado a placa | SELECT TOP 1 |
| `HysSearch(clase, search)` | Búsqueda por columna dinámica | SELECT con LIKE (columna inyectable) |
| `HysSearch(clase, search, fechas)` | Búsqueda columna dinámica + fechas | SELECT con LIKE + fechas |

### BDempresas.cs (10 métodos)
| Método | Función | SQL |
|---|---|---|
| `BuscarEmpresas(tipo, subtipo, empresa, ruc)` | Búsqueda con filtros | EXEC search_empresas |
| `ClientList()` | Lista de nombres de empresas | SELECT Empresa |
| `IdList()` | Lista de IDs | SELECT Id |
| `AddEmpresa(p)` | Insertar empresa | INSERT INTO |
| `ModEmpresa(p)` | Modificar empresa | EXEC edit_empresa |
| `DeleteEmpresa(id)` | Eliminar empresa | DELETE |
| `InfoEmpresa(Int64)` | Info por ID | SELECT * |
| `InfoEmpresa(string)` | Info por nombre | SELECT * con LIKE |
| `LastId()` | Último ID | SELECT TOP 1 Id |
| `Client(id)` | Nombre de empresa por ID | SELECT Empresa |

### BDproductos.cs (7 métodos)
| Método | Función | SQL |
|---|---|---|
| `BuscarProductos(name)` | Por nombre | SELECT con LIKE |
| `BuscarProductos(id)` | Por ID | SELECT |
| `BuscarProductos()` | Todos | SELECT |
| `ProductsList()` | Lista nombres | SELECT Producto |
| `AddProduct(p)` | Insertar | INSERT INTO |
| `Info(pId)` | Info por ID | SELECT |
| `Mod(p)` | Modificar | EXEC edit_producto |
| `Delete(id)` | Eliminar | DELETE |

### BDuser.cs (6 métodos)
| Método | Función | SQL |
|---|---|---|
| `login(user, pass)` | Autenticación | SELECT con usuario y password |
| `Buscar()` | Todos los usuarios | SELECT |
| `Add(p)` | Insertar | INSERT INTO |
| `Info(pId)` | Info por ID | SELECT |
| `Mod(id, p)` | Modificar | UPDATE |
| `Delete(id)` | Eliminar | DELETE |

---

## Configuración Externa

### ConnFile.cs — Archivo "CfgBalanza"
Formato: archivo plano con 8 líneas en orden fijo:
```
L1: COM (puerto serie)
L2: INDICADOR (modelo de balanza)
L3: SERVIDOR (SQL Server host)
L4: BD (base de datos)
L5: userAccess (usuario SQL)
L6: password (contraseña SQL)
L7: formatGuiaPrefijo (ej: "BZ")
L8: formatGuiaDigits (ej: "D5")
```

### ConfigCamara.cs — Archivo "ConfigCamara"
Formato: archivo plano con 6 líneas en orden fijo:
```
L1: user (usuario RTSP)
L2: password (contraseña RTSP)
L3: ip (IP de la cámara)
L4: rtsp (puerto RTSP)
L5: rutaFotoEntrada (carpeta destino)
L6: rutaFotoSalida (carpeta destino)
```

### Variables estáticas globales en Main.cs:
```csharp
Main.Trama, Main.PesoStr, Main.IndType, Main.timeoutSerial,
Main.usuario, Main.userType, Main.admin, Main.resetGuia
```

### Variables estáticas globales en Usuario.cs:
```csharp
Usuario.IDlog, Usuario.NOMBRElog, Usuario.USERlog,
Usuario.PASSWORDlog, Usuario.TIPOlog
```

---

## Comunicación Serial con Balanzas

### Modelos de indicador soportados:
| Índice | Modelo | ReceivedBytesThreshold | NewLine |
|---|---|---|---|
| 0 | Flintec TransCELL TI1520 | 14 | \x0A |
| 1 | Flintec FT11 | 36 | \x0D |
| 2 | XK D9 (genérico chino) | 13 | \x03 |
| 3 | Precia Molen | 49 | \x0A |

### Flujo de lectura serial:
```
serialPort1_DataReceived()
  ├─ ReadWeight_TransCell()     (índice 0)
  ├─ ReadWeight_FT11()         (índice 1)
  ├─ ReadWeight_XKR()          (índice 2)
  └─ ReadWeight_PreciaMolen()  (índice 3)

     └─ Parsea trama → timeoutSerial = 0 → Main.PesoStr = valor

timer1_Tick (cada 200ms)
  └─ timeoutSerial++ (si >10 muestra "no Data")
  └─ Actualiza txtSerialData.Text = PesoStr + " Kg"
```

### Timeout:
- `timeoutSerial` incrementa en cada Tick (200ms)
- Si timeoutSerial > 10 → 2 segundos sin datos → muestra "no Data"
- Los formularios w_inputEvent y w_outputEvent bloquean guardado si timeoutSerial > 10

---

## Integración con Cámaras RTSP

### Configuración de conexión:
```
rtsp://{user}:{password}@{ip}:{rtsp}/cam/realmonitor?channel=1&subtype=0
```

### Captura de foto (w_inputEvent / w_outputEvent):
```
TomarFotoAsync(id)
  └─ Task.Run(() => TomarFoto(id))
       └─ new VideoCapture(url)
            └─ capture.Read(frame) → frame.SaveImage(ruta)
  └─ Timeout: 3s (entrada), 5s (salida)
```

### Vista previa en vivo (w_ViewCamara):
```
Task.Run con while(cameraActiva):
  ├─ capture.Read(frame)
  ├─ BitmapConverter.ToBitmap(frame)
  └─ Invoke → viewImg.Image = image
  └─ Thread.Sleep(10)
```

---

## Sistema de Reportes RDLC

### Reportes implementados (8 archivos RDLC):

| Reporte | Formulario | Variables |
|---|---|---|
| ReportIngreso.rdlc | w_inputReport | VarRPT2 (pesoNeto) |
| ReportSalida.rdlc | w_outputReport | VarRPT2 (pesoNeto, pesoTara, pesoBruto) |
| ReportOutput.rdlc | w_outputPartialReport | VarRPT2 |
| ReportClientes.rdlc | w_clienteReport | VarRPT1 (numRegistros, Fecha, Usuario, Tipo) |
| ReportConsolidado.rdlc | w_consolidadoReport | VarRPT3 (fin, fout, opt1, opt2, option) |
| ReportInfoReg.rdlc | w_inforegReport | VarRPT2 |
| ReportProductos.rdlc | w_productoReport | — |
| rep_cliente.rdlc | — | — |

### Variables de reporte:
```csharp
class VarRPT1 { numRegistros (int), Fecha (string), Usuario (string), Tipo (string) }
class VarRPT2 { pesoNeto (double), pesoTara (string), pesoBruto (string) }
class VarRPT3 { fin (string), fout (string), opt1 (string), opt2 (string), option (string) }
```

### Flujo de impresión:
```
1. Formulario A llena lista<T> y variables
2. Crea instancia del formulario reporte
3. Asigna: windowReport.dataREG = lista; windowReport.datos.Add(var)
4. ShowDialog() → ReportViewer.LocalReport.DataSources + ReportViewer.RefreshReport()
```

---

## Autenticación y Roles

### Proceso de login:
```
txtUser/pass → btnIngresar_Click
  ├── Si user != "root" → BDuser.login(usuario, password)
  │     └── SELECT con usuario y password (texto plano, SQL inyectable)
  │     └── Si 1 fila → carga estáticos Main.usuario, Main.userType, Main.admin
  └── Si user == "root" && pass == "systemconfig"
        └── BACKDOOR: acceso admin sin BD
        └── Main.admin = true; Main.userType = "Programmer"
```

### Roles:
| Tipo | Acceso |
|---|---|
| Admin | Operadores, Formatos, Eliminar |
| Operador | Solo pesaje consulta |
| root (backdoor) | Admin + configuración servidor |

---

## Problemas Conocidos

### 🔴 CRÍTICOS

| # | Problema | Archivo | Línea |
|---|---|---|---|
| 1 | **Inyección SQL masiva**: todos los métodos BD usan `string.Format()` concatenando input del usuario. ~40 métodos vulnerables a SQL injection. | BDregistros.cs, BDempresas.cs, BDproductos.cs, BDuser.cs | Todas |
| 2 | **Puerta trasera hardcodeada**: user "root" + pass "systemconfig" otorga admin sin BD. | Login.cs | 62-70 |
| 3 | **async void en Guardar**: excepción no manejada crashea el proceso completo. | w_inputEvent.cs, w_outputEvent.cs | 146, 107 |
| 4 | **Bucle infinito en ThreadPool**: `while(cameraActiva) + Thread.Sleep(10)` sin límite ni mecanismo de parada seguro. | w_ViewCamara.cs | 50-76 |
| 5 | **Contraseñas en texto plano** en archivos `CfgBalanza` y `ConfigCamara`, y en BD `Usuarios.Password`. | ConnFile.cs, ConfigCamara.cs, BDuser.cs | — |
| 6 | **NullReferenceException en LastGuia()**: `ExecuteScalar()` puede ser null si tabla vacía. | BDregistros.cs | 303 |
| 7 | **PesoStr no thread-safe**: variable estática sin lock/volatile; race condition entre hilo serial y UI. | Main.cs | 19 |

### 🟠 ALTOS

| # | Problema | Archivo | Línea |
|---|---|---|---|
| 8 | **Archivos de configuración frágiles**: sin claves, orden fijo. Cambio de orden rompe todo. | ConnFile.cs, ConfigCamara.cs | — |
| 9 | **ConnFile.Load() en cada conexión BD**: I/O redundante. | BDconnection.cs | 17 |
| 10 | **Sin manejo de errores en métodos BD**: la mayoría sin try-catch. | BD*.cs | — |
| 11 | **TomarFoto() sin try-catch**: si la cámara no responde, lanza excepción no manejada. | w_inputEvent.cs, w_outputEvent.cs | 108, 237 |
| 12 | **Thread.Sleep(2000) en ThreadPool**: bloquea thread del pool. | Main.cs | 141-153 |
| 13 | **Autorización del lado del cliente**: Main.admin es bool estático modificable en memoria. | Main.cs | 24 |
| 14 | **Form1.cs vacío** | Form1.cs | — |
| 15 | **w_clienteInfo.cs vacío** | w_clienteInfo.cs | — |
| 16 | **Constructores privados no usados** | Empresa.cs:29, Usuario.cs:28 | — |
| 17 | **Columnas de consulta fuera de sincronía**: las consultas BD procesaban datos en órden de columnas incorrecto (faltaban Origen, Destino, GuiaRemision), lo que provocaba InvalidCastException en w_outputEvent | BDregistros.cs | readList, readRegistro |

### 🟡 MEDIOS

| # | Problema |
|---|---|
| 18 | **Código duplicado**: TomarFoto() duplicado, AutoComplete duplicado, 4 lectores de peso similares |
| 19 | **Sin interfaces ni abstracciones**: acoplamiento directo a clases estáticas |
| 20 | **15+ variables estáticas mutables**: estado global imposible de testear |
| 21 | **UI bloqueante**: operaciones BD en hilo UI |
| 22 | **Sin data binding**: DataGridView llenado manual |
| 23 | **Comunicación entre forms frágil**: campos estáticos públicos (w_productoNew.flag) |
| 24 | **Inconsistencias**: Empresa.id vs Registro.Id; "dirreccion" (typo) |

---

## Últimas Correcciones Aplicadas

1. **`BDregistros.cs`**: Corregidos los métodos `readList()` y `readRegistro()` para mapear las 21 columnas de la tabla `Registros` en el orden correcto (incluyendo `Origen`, `Destino`, `GuiaRemision`), usando `Convert.ToString(reader.GetValue(index))` para columnas tipo `datetime`.
2. **`Registro.cs`**: Añadidas las propiedades `Origen`, `Destino`, `GuiaRemision`.
3. **`BDregistros.cs`**: Actualizados los INSERT y UPDATE en `AddRE()` y `Mod()` para incluir las columnas faltantes con índices correctos.