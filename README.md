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
<!-- TODO: revisar todos los menus para tratar de implementar todas las funcionalidades del CRUD que se tienen pensado implementar en todas las entidades -->
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
│   |   |   |   ├── repositories/
|   │   │   │   |   └── CuerpoMedicoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── CuerpoMedicoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── CuerpoMedico.cs

|   |  
|   |
|   │   ├── cuerpo_tecnico/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ICuerpoTecnicoRepository.cs
|   |   |   |   │   └── ICuerpoTecnicoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── CuerpoTecnicoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── CuerpoTecnicoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── CuerpoTecnico.cs
|   |
|   │   ├── equipo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEquipoRepository.cs
|   |   |   |   │   └── IEquipoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── EquipoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── EquipoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Equipo.cs
|   |
|   │   ├── equipo_cuerpo_medico/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEquipoCuerpoMedicoRepository.cs
|   |   |   |   │   └── IEquipoCuerpoMedicoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── EquipoCuerpoMedicoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── EquipoCuerpoMedicoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EquipoCuerpoMedico.cs
|   |
|   │   ├── equipo_cuerpo_tecnico/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEquipoCuerpoTecnicoRepository.cs
|   |   |   |   │   └── IEquipoCuerpoTecnicoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── EquipoCuerpoTecnicoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── EquipoCuerpoTecnicoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EquipoCuerpoTecnico.cs
|   |
|   │   ├── equipo_jugador/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEquipoJugadorRepository.cs
|   |   |   |   │   └── IEquipoJugadorService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── EquipoJugadorRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── EquipoJugadorService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EquipoJugador.cs
|   |
|   │   ├── estadistica_equipo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEstadisticaEquipoRepository.cs
|   |   |   |   │   └── IEstadisticaEquipoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── EstadisticaEquipoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── EstadisticaEquipoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EstadisticaEquipo.cs
|   |
|   │   ├── estadistica_jugador/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IEstadisticaJugadorRepository.cs
|   |   |   |   │   └── IEstadisticaJugadorService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── EstadisticaJugadorRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── EstadisticaJugadorService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── EstadisticaJugador.cs
|   |
|   │   ├── jugador/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IJugadorRepository.cs
|   |   |   |   │   └── IJugadorService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── JugadorRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── JugadorService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Jugador.cs
|   |
|   │   ├── persona/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── IPersonaRepository.cs
|   |   |   |   │   └── IPersonaService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── PersonaRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── PersonaService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Persona.cs
|   |
|   │   ├── torneo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ITorneoRepository.cs
|   |   |   |   │   └── ITorneoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── TorneoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── TorneoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Torneo.cs
|   |
|   │   ├── torneo_equipo/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ITorneoEquipoRepository.cs
|   |   |   |   │   └── ITorneoEquipoService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── TorneoEquipoRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── TorneoEquipoService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── TorneoEquipo.cs
|   |   
|   │   ├── transferencia/
|   │   │   ├── application/
|   |   |   |   ├── interfaces/
|   |   |   |   |   ├── ITransferenciaRepository.cs
|   |   |   |   │   └── ITransferenciaService.cs
│   |   |   |   ├── repositories/
|   │   │   │   |   └── TransferenciaRepository.cs
|   |   |   |   └── services/
|   |   |   |       └── TransferenciaService.cs
|   │   │   ├── domain/
|   |   |   |   └── models/
|   │   │   |       └── Transferencia.cs
|
│   ├── shared/
│   │   ├── context/
│   │   |   └── AppDbContext.cs
│   │   ├── data/
│   │   │   ├── ddl.sql
│   │   ├── helpers/
│   │   │   ├── DbContextFactory.cs
│   |   |   └── MySqlVersionResolver.cs
│   │   ├── utils/
│   │   │   ├── DbInstaller.cs
│   │   │   └── Validaciones.cs
│   
|   ├── ui/       
|   |   ├── MenuCuerpoMedico.cs 
|   |   ├── MenuCuerpoTecnico.cs     
|   |   ├── MenuEquipo.cs   
|   |   ├── MenuEstadistica.cs     
|   |   ├── MenuJugador.cs  
|   |   ├── MenuNotificacion.cs                      
|   |   ├── MenuPersonas.cs 
|   │   ├── MenuPrincipal.cs      # Menú general
|   │   └── MenuTorneos.cs
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
