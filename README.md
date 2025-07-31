# ⚽ Sistema de Gestión de Fútbol en Consola – C#

Autor: Ángel David Pinzón Serrano

## 📘 Descripción

Este proyecto es un sistema de consola desarrollado en C# que permite la **gestión integral de fútbol competitivo**, incluyendo la administración de torneos, equipos, jugadores, transferencias y estadísticas deportivas.

Está diseñado como una herramienta educativa para consolidar habilidades en programación orientada a objetos (POO), así como la aplicación de los principios **SOLID**, dentro de un entorno estructurado y modular.

---

## 🎯 Objetivos del Proyecto

- Aplicar principios fundamentales de la **Programación Orientada a Objetos (POO)**.
- Diseñar un sistema modular, reutilizable y escalable utilizando los **principios SOLID**.
- Integrar estructuras de datos como listas, diccionarios y colecciones dinámicas.
- Desarrollar habilidades para la construcción de **sistemas interactivos de consola**.
- Implementar flujos de trabajo con menús, submenús y lógica de navegación.
- Consolidar las bases de la programación profesional en C# con enfoque educativo.

---

## 🛠️ Tecnologías Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET 9.0
- **Entorno de Desarrollo:** Visual Studio Code
- **Paradigmas:** POO, SOLID, Modularidad, Bajo acoplamiento
- **Tipo de aplicación:** Aplicación de consola

---

## 🧩 Funcionalidades Principales

### 🏆 Torneos
- Crear torneo
- Buscar torneo por nombre o ID
- Eliminar torneo
- Actualizar información del torneo


### 🏟️ Equipos
- Registrar nuevos equipos
- Añadir cuerpo técnico
- Añadir cuerpo médico
- Inscribir equipos al torneo
- Gestionar jugadores por equipo
- Notificar transferencias realizadas
- Abandonar un torneo

### 🧍 Jugadores
- Registrar jugador
- Buscar jugador
- Editar datos del jugador
- Eliminar jugador

### 🔄 Transferencias
- Compra de jugadores entre equipos
- Préstamo temporal de jugadores

### 📈 Estadísticas
- Listar jugadores con más asistencias por torneo
- Equipos con más goles en contra por torneo
- Jugadores más caros por equipo
- Jugadores con edad mayor al promedio del equipo

---

## 🧭 Estructura del Menú Principal
0. Registro torneos
1. Registro de equipos
2. Registros jugadores
3. Transferencias (compra, prestamo)
4. Estadisticas
5. Salir del programa 


### Submenús
Cada sección cuenta con su respectivo submenú con acciones CRUD y específicas, por ejemplo:
12
**Torneos:**
- 0.1 Crear torneo
- 0.2 Buscar torneo
- 0.3 Eliminar torneo
- 0.4 Actualizar torneo
- 0.5 Regresar al menú principal

**Equipos**
- 1.1 Registrar equipo
- 1.2 Registrar cuerpo tecnico 
- 1.3 Registrar cuerpo medico
- 1.4 Inscripcion torneo
- 1.5 Gestionar jugadores por equipo
- 1.6 Transferencia
    - 1.6.1 Comprar jugador
    - 1.6.2 Prestar jugador
    - 1.6.3 Vender jugador
    - 1.6.4 Regresar
- 1.7 Desencribir equipo del torneo
- 1.8 Regresar main menu 

**Jugadores:**
- 2.1 Registrar jugador
- 2.2 Buscar jugador
- 2.3 Editar jugador
- 2.4 Eliminar jugador
- 2.5 Regresar al menú principal

**Estadisticas:**
- 3.1 Jugadores con mas asistencias por torneo 
- 3.2 Equipos con mas goles en contra por torneo
- 3.3 Jugadores mas caros por equipo
- 3.4 Jugadores con edad mayor al promedio de edad del equipo
- 3.5 Regresar main menu
---

## 🧱 Estructura General del Proyecto
```code
/soccer_cs/
│
├── Program.cs
├── soccer_csharp.csproj
├── soccer_csharp.sln
├── README.md
├── .gitignore
│
├── Modules/                         # Cada módulo es una funcionalidad completa (slice vertical)
│   ├── cuerpo_medico/
│   │   ├── Domain/
│   │   |   └── CuerpoMedico.cs
│   │   ├── Application/
│   │   │   ├── ICuerpoMedicoService.cs
│   │   │   ├── ICuerpoMedicoRepository.cs
│   │   │   └── CuerpoMedicoService.cs
│   │   ├── Infrastructure/
│   |   |   └── CuerpoMedicoRepository.cs
|
│   ├── cuerpo_tecnico/
│   │   ├── Domain/
│   │   |   └── CuerpoTecnico.cs
│   │   ├── Application/
│   │   │   ├── ICuerpoTecnicoService.cs
│   │   │   ├── ICuerpoTecnicoRepository.cs
│   │   │   └── CuerpoTecnicoService.cs
│   │   ├── Infrastructure/
│   |   |   └── CuerpoTecnicoRepository.cs
│   
│   ├── equipo/
│   │   ├── Domain/
│   │   |   └── Equipo.cs
│   │   ├── Application/
│   │   │   ├── IEquipoService.cs
│   │   │   ├── IEquipoRepository.cs
│   │   │   └── EquipoService.cs
│   │   ├── Infrastructure/
│   │   │   └── EquipoRepository.cs
│
│   ├── estadisitca_equipo/
│   │   ├── Domain/
│   │   |   └── EstadisticaEquipo.cs
│   │   ├── Application/
│   │   │   ├── IEstadisticaEquipoService.cs
│   │   │   ├── IEstadisticaEquipoRepository.cs
│   │   │   └── EstadisticaEquipoService.cs
│   │   ├── Infrastructure/
│   │   │   └── EstadisticaEquipoRepository.cs
|
│   ├── estadisitca_jugador/
│   │   ├── Domain/
│   │   |   └── EstadisticaJugador.cs
│   │   ├── Application/
│   │   │   ├── IEstadisticaJugadorService.cs
│   │   │   ├── IEstadisticaJugadorRepository.cs
│   │   │   └── EstadisticaJugadorService.cs
│   │   ├── Infrastructure/
│   │   │   └── EstadisticaJugadorRepository.cs
|
│   ├── jugador/
│   │   ├── Domain/
│   │   |   └── Jugador.cs
│   │   ├── Application/
│   │   │   ├── IJugadorService.cs
│   │   │   ├── IJugadorRepository.cs
│   │   │   └── JugadorService.cs
│   │   ├── Infrastructure/
│   │   │   └── JugadorRepository.cs
|
│   ├── persona/
│   │   ├── Domain/
│   │   |   └── Persona.cs
│   │   ├── Application/
│   │   │   ├── IPersonaService.cs
│   │   │   ├── IPersonaRepository.cs
│   │   │   └── PersonaService.cs
│   │   ├── Infrastructure/
│   │   │   └── PersonaRepository.cs
|
│   ├── torneo/
│   │   ├── Domain/
│   │   |   └── Torneo.cs
│   │   ├── Application/
│   │   │   ├── ITorneoService.cs
│   │   │   ├── ITorneoRepository.cs
│   │   │   └── TorneoService.cs
│   │   ├── Infrastructure/
│   │   │   └── TorneoRepository.cs
|
│   ├── transferencia/
│   │   ├── Domain/
│   │   |   └── Transferencia.cs
│   │   ├── Application/
│   │   │   ├── ITransferenciaService.cs
│   │   │   ├── ITransferenciaRepository.cs
│   │   │   └── TransferenciaService.cs
│   │   ├── Infrastructure/
│   │   │   └── TransferenciaRepository.cs
|
├── Infrastructure/
│   ├── data/
│   │   ├── MySqlDbContext.cs
|   |   ├── ConexionSingleton.cs
|   |   ├── IDbFactory.cs
|   |   ├── IGenericRepository.cs
│   │   └── ddl.sql
│   └── Utils/
│       ├── IdGenerator.cs
│       └── Validaciones.cs
│
├── ui/       
|   ├── MenuEquipos.cs   
|   ├── MenuEstadisticas.cs     
|   ├── MenuJugadores.cs  
|   ├── MenuNotificaciones.cs                      
│   ├── MenuPrincipal.cs      # Menú general
│   └── MenuTorneos.cs
```


---

## 🧠 Principios Aplicados

### ✅ Programación Orientada a Objetos (POO)
- **Clases y Objetos**: modelado de entidades reales (jugadores, equipos, torneos).
- **Encapsulamiento**: acceso controlado a través de propiedades y métodos.
- **Herencia**: clases derivadas como `Jugador`, `Tecnico`, `Medico` a partir de `Persona`.
- **Polimorfismo**: métodos comunes sobrescritos según el rol.
- **Abstracción**: ocultar detalles de implementación al usuario.


---
## ✅ Consideraciones Técnicas

- El sistema está preparado para trabajar exclusivamente en memoria (no usa bases de datos).
- Se aplican validaciones para entradas del usuario (fechas, nombres, duplicados).
- Arquitectura separada por capas: presentación (consola), dominio (entidades), lógica de negocio (servicios).


---

## 🚀 Instrucciones de Ejecución

1. Clona el repositorio:

```bash
git clone https://github.com/servorx/soccer_csharp.git

dotnet run
