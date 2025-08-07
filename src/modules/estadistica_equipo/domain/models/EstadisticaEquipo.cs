using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules.equipo.domain;

namespace soccer_cs;

public class EstadisticaEquipo
{
  public int Id { get; set; }
  public int PartidosGanados { get; set; }
  public int PartidosEmpatados { get; set; }
  public int PartidosPerdidos { get; set; }
  public int GolesAFavor { get; set; }
  public int GolesEnContra { get; set; }
  public DateTime FechaCreacion { get; set; }
  // relaciones foraneas, en este caso de uno a muchos
  public int EquipoId { get; set; }
  public Equipo? Equipo { get; set; }
  public EstadisticaEquipo(
    int partidosGanados, int partidosEmpatados, int partidosPerdidos,
    int golesAFavor, int golesEnContra, DateTime fechaCreacion)
  {
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
