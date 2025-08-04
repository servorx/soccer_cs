// TODO: crear todas las clases que me faltan y crear los repositorios que me faltan, y finalizar la conexion con la base de datos



# ✅ TODO – Proyecto `soccer_csharp`

Este documento organiza todas las tareas necesarias para completar el proyecto, dividiéndolas por categorías clave. Sigue este plan paso a paso para mantenerte enfocado y avanzar con claridad.

---

## 1️⃣ ESTRUCTURA GENERAL Y BASE DE DATOS

- [x] Organizar estructura del proyecto en carpeta `src/`
- [x] Separar `shared/` con conexión, helpers y utilidades
- [x] Definir carpeta `ui/` para menú y entrada principal
- [x] Incluir carpeta `infrastructure/` en cada módulo
- [x] Incluir archivo `ddl.sql` para crear base de datos

### Tareas pendientes:
- [x] Crear script SQL `CREATE DATABASE IF NOT EXISTS soccer_csharp;` automático
- [x] Verificar existencia de base de datos antes de insertar datos
- [x] Asegurar integridad referencial (FKs) en el modelo relacional

---

## 2️⃣ MÓDULOS POR ENTIDAD

Cada módulo debe tener:
- `domain/`: entidad y reglas de negocio
- `application/`: servicios e interfaces
- `infrastructure/`: repositorio MySQL
- `ui/`: funcionalidades específicas si aplica

### ⚽ Jugadores
- [x] Entidad `Jugador`
- [x] Servicio `IJugadorService` / `JugadorService`
- [x] Repositorio `JugadorRepository` (MySQL)
- [x] Validaciones básicas
- [ ] Métodos: Crear, Listar, Editar, Eliminar, Buscar
- [ ] Lógica de préstamo, venta y compra

### 🧑‍⚕️ Cuerpo Médico
- [x] Entidad `CuerpoMedico`
- [x] Servicio / Repositorio
- [ ] Validaciones de especialidad y disponibilidad
- [ ] Funcionalidad para asignar a equipos

### 🎓 Cuerpo Técnico
- [x] Entidad `CuerpoTecnico`
- [x] Servicio / Repositorio
- [ ] Relación con equipos y torneos
- [ ] Métodos de edición y eliminación

### 🏟️ Torneo
- [x] Entidad `Torneo`
- [ ] Registrar equipos participantes
- [ ] Validar fechas y categorías

### 📈 Estadísticas
- [x] Entidad `Estadistica`
- [ ] Servicio para registrar estadísticas por partido
- [ ] Automatización según torneo

---

## 3️⃣ CONSOLA / MENÚ UI

- [ ] Menú principal con navegación clara
- [ ] Submenús para: Jugadores, Equipos, Torneos, Cuerpo Técnico/Médico
- [ ] Validaciones de entrada (string, int, fechas)
- [ ] Notificaciones de éxito/error al usuario

---

## 4️⃣ INFRAESTRUCTURA Y SHARED

- [x] Singleton de conexión (`ConexionSingleton`)
- [x] `MySqlDbContext` para manejo centralizado
- [x] Interfaces de repositorio genérico (`IGenericRepository`)
- [ ] Generador de ID si es necesario (`IdGenerator`)
- [x] `Validaciones.cs` centralizadas
- [ ] Agregar DTOs si crece complejidad

---

## 5️⃣ PERSISTENCIA Y ERRORES

- [ ] Manejar errores de conexión y query SQL
- [ ] Validar existencia previa antes de insertar (ej: evitar duplicados)
- [ ] Logs de errores (opcional)

---

## 6️⃣ ARQUITECTURA Y BUENAS PRÁCTICAS

- [x] Usar interfaces para servicios y repositorios
- [x] Mantener lógica de dominio separada de infraestructura
- [ ] Asegurar inversión de dependencias
- [ ] Limpiar dependencias cíclicas

---

## 7️⃣ DOCUMENTACIÓN

- [ ] README técnico del proyecto (arquitectura, dependencias, uso)
- [ ] Instrucciones para compilar y correr
- [ ] Manual de uso (opcional para consola)

---

## 8️⃣ OPTATIVO (mejoras futuras)

- [ ] Usar patrón `Unit of Work`
- [ ] Tests unitarios con `xUnit`
- [ ] Migrar UI a WinForms o Web (MVC o Blazor)
- [ ] Usar Entity Framework (versión avanzada)
- [ ] Internacionalización (ES/EN)

---

## 🚦 PRIORIDADES (Siguiente paso recomendado)

1. [ ] Finaliza CRUD de `Jugador`
2. [ ] Implementa validaciones y mensajes en consola
3. [ ] Crea menú de navegación funcional
4. [ ] Termina conexión a MySQL y verificación de existencia de datos
5. [ ] Repite flujo para las demás entidades



<!-- TODO: revisar todos los menus para tratar de implementar todas las funcionalidades del CRUD que se tienen pensado implementar en todas las entidades (en los menus) --> 