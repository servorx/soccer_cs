using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;

public class EstadisticaEquipo
{
  public int Id { get; set; }
  public int? EquipoId { get; set; }
  public int PartidosGanados { get; set; }
  public int PartidosEmpatados { get; set; }
  public int PartidosPerdidos { get; set; }
  public int GolesAFavor { get; set; }
  public int GolesEnContra { get; set; }

  public EstadisticaEquipo(int id, int? equipoId,
    int partidosGanados, int partidosEmpatados, int partidosPerdidos,
    int golesAFavor, int golesEnContra)
  {
    Id = id;
    EquipoId = equipoId;
    PartidosGanados = partidosGanados;
    PartidosEmpatados = partidosEmpatados;
    PartidosPerdidos = partidosPerdidos;
    GolesAFavor = golesAFavor;
    GolesEnContra = golesEnContra;
  }

  public EstadisticaEquipo() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Partidos Ganados: {PartidosGanados}, Empatados: {PartidosEmpatados}, Perdidos: {PartidosPerdidos}");
    Console.WriteLine($"Goles a Favor: {GolesAFavor}, Goles en Contra: {GolesEnContra}");
  }
}
