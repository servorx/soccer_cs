using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.equipo_jugador.domain.models;

public class EquipoJugador
{
  public int IdEquipo { get; set; }
  public int IdJugador { get; set; }
  public Equipo? Equipo { get; set; }
  public Jugador? Jugador { get; set; }
  public DateTime FechaInicio { get; set; }
  public DateTime FechaFin { get; set; }
}
