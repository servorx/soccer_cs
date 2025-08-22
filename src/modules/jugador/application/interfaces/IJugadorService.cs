using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.jugador.application.interfaces;
public interface IJugadorService
{
  Task AgregarJugadorAsync(Jugador jugador);
  Task ActualizarJugadorAsync(int id, Jugador jugador);
  Task EliminarJugadorAsync(int id);
  Task<IEnumerable<Jugador?>> MostrarJugadorsAsync();
  Task<Jugador?> ObtenerJugadorPorIdAsync(int id);
  Task<Jugador?> ObtenerJugadorPorNombreAsync(string nombre);
}