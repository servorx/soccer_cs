using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.torneo.domain.models;

namespace soccer_cs.src.modules.torneo_equipo.domain.models;

public class TorneoEquipo
{
  public int IdTorneo { get; set; }
  public int IdEquipo { get; set; }
  public Equipo? Equipo { get; set; }
  public Torneo? Torneo { get; set; }
  public TorneoEquipo(int idTorneo, int idEquipo)
  {
    IdTorneo = idTorneo;
    IdEquipo = idEquipo;
  }
  public TorneoEquipo() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"TorneoEquipo ID: {IdTorneo} - {IdEquipo}");
    Console.WriteLine($"Equipo ID: {IdEquipo} - Nombre: {Equipo?.Nombre}");
    Console.WriteLine($"Torneo ID: {IdTorneo} - Nombre: {Torneo?.Nombre}");
  }
}
