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

1. Registro torneos
2. Registro de equipos
3. Registros jugadores
4. Registros de cuerpo medico
5. Registros de cuerpo tecnico
6. Transferencias (compra de jugadores)
7. Estadisticas de equipo
8. Estadisitcas de jugadores
9. Salir del programa 


### Submenús
Cada sección cuenta con su respectivo submenú con acciones CRUD y específicas, por ejemplo:

**Torneos:**
- 1.1 Crear torneo
- 1.2 Actualizar torneo
- 1.3 Eliminar torneo
- 1.4 Mostrar todos los torneos
- 1.5 Buscar torneo por id
- 1.6 Buscar torneo por nombre
<!-- (aqui la idea es que muestre todos equipos que existen y que el usuario los seleccione) -->
- 1.7 Registrar equipo a torneo 
- 1.8 Eliminar equipo de torneo
- 1.9 Regresar al menú principal

**Equipos**
- 2.1 Crear equipo
- 2.2 Actualizar equipo
- 2.3 Eliminar equipo
- 2.4 Mostrar todos los equipos
- 2.5 Buscar equipo por id
- 2.6 Buscar equipo por nombre
- 2.7 Buscar jugadores por equipo
<!-- (aqui la idea es que muestre todos Cuerpos medicos que existen y que el usuario los seleccione para anidarlos con el equipo que el usuario quiera) -->
- 2.8 Registrar cuerpo tecnico a equipo 
- 2.9 Registrar cuerpo medico a equipo
- 2.10 Registrar jugadores sin equipo
<!-- (cumpliria la misma funcionalidad que con el menu 2.6 de registrar equipos en el menu de torneos, en este cas mostraria los torneos que son creados, y el usuario le asigna el equipo que desea inscribir.)  -->
- 2.11 Inscripcion torneo 
- 2.12 Desvincular equipo del torneo 
- 2.13 Regresar main menu 

**Jugadores:**
- 3.1 Crear jugador
- 3.2 Actualizar jugador
- 3.3 Eliminar jugador
- 3.4 Mostrar todos los jugadores
- 3.5 Buscar jugador por id
- 3.6 Buscar jugador por nombre
- 3.7 Registrar jugador a equipo (mas de lo mismo, mostrar los equipos creados y hacer que el usuario le asigne un equipo a su jugador)
<!-- TODO: tener en cuenta que las funcionalidades de modificacion del equipo al que pertenece un jugador pueden llegar a ser redundantes debido al menu de transacciones. -->
- 3.8 Regresar al menú principal

**Cuerpo Medico:**
<!-- primero el CRUD basico -->
- 4.1 Crear cuerpo medico
- 4.2 Actualizar cuerpo medico
- 4.3 Eliminar cuerpo medico
<!-- consultas -->
- 4.4 Mostrar todos los cuerpo medicos
- 4.5 Buscar cuerpo medico por id
- 4.6 Buscar cuerpo medico por nombre
<!-- funcionalidades -->
- 4.7 Registrar cuerpo medico a equipo (mas de lo mismo, mostrar los equipos creados y hacer que el usuario le asigne un cuerpo medico a su equipo)
- 4.8 Eliminar cuerpo medico de un equipo (mas de lo mismo, mostrar los equipos creados y hacer que el usuario escoja cual cuerpo medico desea eliminar)
- 4.9 Regresar al menú principal

**Cuerpo Tecnico:**
- 5.1 Crear cuerpo tecnico
- 5.2 Actualizar cuerpo tecnico
- 5.3 Eliminar cuerpo tecnico
- 5.4 Mostrar todos los cuerpo tecnicos
- 5.5 Buscar cuerpo tecnico por id
- 5.6 Buscar cuerpo tecnico por nombre
- 5.7 Registrar cuerpo tecnico a equipo (mas de lo mismo, mostrar los equipos creados y hacer que el usuario le asigne un cuerpo tecnico a su equipo)
- 5.8 Eliminar cuerpo tecnico de un equipo (mas de lo mismo, mostrar los equipos creados y hacer que el usuario escoja cual cuerpo tecnico desea eliminar)
- 5.9 Regresar al menú principal

**Transferencias:**
- 6.1 Realizar transferencia (jugador de un equipo a otro)
    Elegir jugador existente
    Mostrar equipo actual
    Seleccionar equipo destino
    Tipo de transferencia (venta, préstamo)
    Valor
- 6.2 Actualizar transferencia
- 6.3 Eliminar transferencia
- 6.4 Ver historial de todas las trasnferencias
- 6.5 Ver historial de transferencias por jugador
- 6.6 Ver historial de transferencias por equipo
- 6.7 Regresar main menu

**Estadisticas por equipo:**
- 7.1 Equipos con mas partidos ganados
- 7.2 Equipos con mas partidos empatados
- 7.3 Equipos con mas partidos perdidos
- 7.4 Equipos con mas goles a favor
- 7.5 Equipos con mas goles en contra
- 7.6 Mostrar todas las estadisticas de equipo
- 7.7 Regresar main menu

**Estadisticas por jugador:**
- 8.1 Crear estadisticas de jugador
- 8.2 Actualizar estadisticas de jugador
- 8.3 Eliminar estadisticas de jugador
- 8.4 Mostrar todas las estadisticas de jugadores
- 8.5 Mostrar estadisticas de jugador por nombre
- 8.6 Mostrar estadisticas de jugador por id
- 8.7 Jugadores con mas goles
- 8.8 Jugadores con mas partidos jugados
- 8.9 Jugadores mas alto
- 8.10 Jugadores menos pesado
- 8.11 Jugadores con mas tarjetas amarillas
- 8.12 Jugadores con menos tarjetas rojas
- 8.13 Jugadores con edad mayor al promedio de edad del equipo
- 8.14 Regresar main menu


## 🧱 Estructura General del Proyecto

```code
/soccer_cs/
│
├── Program.cs
├── soccer_csharp.csproj
├── soccer_csharp.sln
├── README.md
├── appsettings.json
├── .gitignore
│
├── src/                        
│   ├── modules/
|   │   ├── cuerpo_medico/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ICuerpoMedicoRepository.cs
|   |   |   |   │   └── ICuerpoMedicoService.cs
|   |   |   |   └── services/
|   |   |   |       └── CuerpoMedicoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── CuerpoMedico.cs
|   │   │   ├── instrastructure/
│   |   |   |   └──  repositories/
|   |   |   |       └── CuerpoMedicoRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuCuerpoMedico.cs 
|   |
|   │   ├── cuerpo_tecnico/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ICuerpoTecnicoRepository.cs
|   |   |   |   │   └── ICuerpoTecnicoService.cs
|   |   |   |   └── services/
|   |   |   |       └── CuerpoTecnicoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── CuerpoTecnico.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   |       └── CuerpoTecnicoRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuCuerpoTecnico.cs 
|   |
|   │   ├── equipo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEquipoRepository.cs
|   |   |   |   │   └── IEquipoService.cs
|   |   |   |   └── services/
|   |   |   |       └── EquipoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Equipo.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── EquipoRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuEquipo.cs  
|   |
|   │   ├── equipo_jugador/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEquipoJugadorRepository.cs
|   |   |   |   │   └── IEquipoJugadorService.cs
|   |   |   |   └── services/
|   |   |   |       └── EquipoJugadorService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EquipoJugador.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── EquipoJugadorRepository.cs
|   |
|   │   ├── estadistica_equipo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEstadisticaEquipoRepository.cs
|   |   |   |   │   └── IEstadisticaEquipoService.cs
|   |   |   |   └── services/
|   |   |   |       └── EstadisticaEquipoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EstadisticaEquipo.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── EstadisticaEquipoRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuEstadisticaEquipo.cs 
|   |
|   │   ├── estadistica_jugador/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEstadisticaJugadorRepository.cs
|   |   |   |   │   └── IEstadisticaJugadorService.cs
|   |   |   |   └── services/
|   |   |   |       └── EstadisticaJugadorService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EstadisticaJugador.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── EstadisticaJugadorRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuEstadisticaJugador.cs 
|   |
|   │   ├── jugador/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IJugadorRepository.cs
|   |   |   |   │   └── IJugadorService.cs
|   |   |   |   └── services/
|   |   |   |       └── JugadorService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Jugador.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── JugadorRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuJugador.cs 
|   |
|   │   ├── persona/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IPersonaRepository.cs
|   |   |   |   │   └── IPersonaService.cs
|   |   |   |   └── services/
|   |   |   |       └── PersonaService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Persona.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── PersonaRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuPersona.cs 
|   |
|   │   ├── torneo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ITorneoRepository.cs
|   |   |   |   │   └── ITorneoService.cs
|   |   |   |   └── services/
|   |   |   |       └── TorneoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Torneo.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── TorneoRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuTorneo.cs 
|   |
|   │   ├── torneo_equipo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ITorneoEquipoRepository.cs
|   |   |   |   │   └── ITorneoEquipoService.cs
|   |   |   |   └── services/
|   |   |   |       └── TorneoEquipoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── TorneoEquipo.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── TorneoEquipoRepository.cs
|   |   
|   │   ├── transferencia/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ITransferenciaRepository.cs
|   |   |   |   │   └── ITransferenciaService.cs
|   |   |   |   └── services/
|   |   |   |       └── TransferenciaService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Transferencia.cs
|   │   │   ├── instrastructure/
│   |   |   |   └── repositories/
|   │   │   │       └── TransferenciaRepository.cs
|   |   |   ├── ui/       
|   |   |       └── MenuNotificacion.cs 
|
│   ├── shared/
|   |   ├── configurations/
│   │   |   ├──  CuerpoMedicoConfig.cs
│   │   |   ├──  CuerpoTecnicoConfig.cs
│   │   |   ├──  EquipoConfig.cs
│   │   |   ├──  EquipoCuerpoMedicoConfig.cs
│   │   |   ├──  EquipoCuerpoTecnicoConfig.cs
│   │   |   ├──  EquipoJugadorConfig.cs
│   │   |   ├──  EstadisticaEquipoConfig.cs
│   │   |   ├──  EstadisticaJugadorConfig.cs
│   │   |   ├──  JugadorConfig.cs
│   │   |   ├──  PersonaConfig.cs
│   │   |   ├──  TorneoConfig.cs
│   │   |   ├──  TorneoEquipoConfig.cs
│   │   |   └──  TransferenciaConfig.cs
│   │   ├── context/
│   │   |   └── AppDbContext.cs
│   │   ├── data/
│   │   │   └── ddl.sql
│   │   ├── helpers/
│   │   │   ├── DbContextFactory.cs
│   |   |   └── MySqlVersionResolver.cs
│   │   ├── utils/
│   │   │   ├── DbInstaller.cs
│   │   │   └── Validaciones.cs 
|   ├── ui/
|   │   └── MenuPrincipal.cs      # Menú general
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
