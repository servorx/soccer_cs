using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules.equipo.domain;
using soccer_cs.models;

namespace soccer_cs;

public class TorneoEquipo
{
  public int TorneoId { get; set; }
  public Torneo? Torneo { get; set; }
  public int EquipoId { get; set; }
  public Equipo? Equipo { get; set; }
}
