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




<!-- TODO hacer la validacion de que la base de datos sea creada por defecto y si noh, crearla -->