using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules.equipo.domain;
using soccer_cs.models;

namespace soccer_cs;
public class EquipoJugador
{
  public int EquipoId { get; set; }
  public Equipo? Equipo { get; set; }

  public int JugadorId { get; set; }
  public Jugador? Jugador { get; set; }

  public DateTime FechaIngreso { get; set; }
}
