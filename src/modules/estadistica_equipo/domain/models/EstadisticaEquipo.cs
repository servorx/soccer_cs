using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;

namespace soccer_cs.src.modules.estadistica_equipo.domain.models;

public class EstadisticaEquipo
{
  public int Id { get; set; }
  public int PartidosJugados { get; set; }
  public int PartidosGanados { get; set; }
  public int PartidosEmpatados { get; set; }
  public int PartidosPerdidos { get; set; }
  public int GolesAFavor { get; set; }
  public int GolesEnContra { get; set; }
  public DateTime? FechaCreacion { get; set; }
  // relaciones foraneas, en este caso de uno a muchos
  public int IdEquipo { get; set; }
  public Equipo? Equipo { get; set; }
  public EstadisticaEquipo(
    int partidosJugados,
    int partidosGanados,
    int partidosEmpatados,
    int partidosPerdidos,
    int golesAFavor,
    int golesEnContra,
    DateTime? fechaCreacion)
  {
    PartidosJugados = partidosJugados;
    PartidosGanados = partidosGanados;
    PartidosEmpatados = partidosEmpatados;
    PartidosPerdidos = partidosPerdidos;
    GolesAFavor = golesAFavor;
    GolesEnContra = golesEnContra;
    FechaCreacion = fechaCreacion;
  }

  public EstadisticaEquipo() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Partidos Ganados: {PartidosGanados}, Empatados: {PartidosEmpatados}, Perdidos: {PartidosPerdidos}");
    Console.WriteLine($"Goles a Favor: {GolesAFavor}, Goles en Contra: {GolesEnContra}");
  }
}
