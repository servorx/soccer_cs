mirar si debo de crear un metodo especifico para mantener la sincronia entre clases, digamos, si quiero asignar un jugador al equipo debo de asegurarme de que se agrege a la lista jugadores de equipo y a su vez, agregarlo a la lista global de jugadores en appdata
```c#
public static void AsignarJugadorAEquipo(Jugador jugador, Equipo equipo)
{
  equipo.Jugadores.Add(jugador);
  jugador.EquipoActual = equipo.Nombre;
  if (!AppData.Jugadores.Contains(jugador))
    AppData.Jugadores.Add(jugador);
}
```
porque si no hago lo del codigo de arriba me toca hacer esto manualmente
```c#
// Agregas jugador a AppData
AppData.Jugadores.Add(nuevoJugador);

// Pero no lo agregaste al equipo
equipo.Jugadores.Add(nuevoJugador); // tienes que hacerlo tú mismo
```



```code
/soccer_csharp/
│
├── Program.cs
├── soccer_csharp.csproj
├── soccer_csharp.sln
├── README.md
│
├── Modules/                         # Cada módulo es una funcionalidad completa (slice vertical)
│   ├── Jugadores/
│   │   ├── Domain/
│   │   │   ├── Entities/
│   │   │   │   └── Jugador.cs
│   │   │   └── ValueObjects/
│   │   │       └── Posicion.cs
│   │   ├── Application/
│   │   │   ├── Interfaces/
│   │   │   │   ├── Services/IJugadorService.cs
│   │   │   │   └── Repositories/IJugadorRepository.cs
│   │   │   └── Services/JugadorService.cs
│   │   ├── Infrastructure/
│   │   │   └── Persistence/JugadorRepository.cs
│   │   └── UI/MenuJugadores.cs
│
│   ├── Equipos/
│   │   ├── Domain/...
│   │   ├── Application/...
│   │   ├── Infrastructure/...
│   │   └── UI/MenuEquipos.cs
│
│   ├── Torneos/
│   │   ├── Domain/...
│   │   ├── Application/...
│   │   ├── Infrastructure/...
│   │   └── UI/MenuTorneos.cs
│
│   ├── Estadisticas/
│   │   ├── Domain/...
│   │   ├── Application/...
│   │   ├── Infrastructure/...
│   │   └── UI/MenuEstadisticas.cs
│
│   └── Transferencias/
│       ├── Domain/...
│       ├── Application/...
│       ├── Infrastructure/...
│       └── UI/MenuTransferencias.cs
│
├── Infrastructure/
│   ├── Persistence/
│   │   ├── Context/MySqlDbContext.cs
│   │   └── ddl.sql
│   └── Utils/
│       ├── IdGenerator.cs
│       └── Validaciones.cs
│
├── UI/                              # Menú general
│   └── MenuPrincipal.cs
```