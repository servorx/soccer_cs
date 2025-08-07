using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules;
using soccer_cs;
using soccer_cs.models;

namespace soccer.modules.equipo.domain;

public class Equipo
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Ciudad { get; set; }
  public string? Pais { get; set; }
  public string? Estadio { get; set; }
  public string? TipoEquipo { get; set; }
  public int? CantidadTitulos { get; set; }
  // relaciones
  public ICollection<CuerpoMedico>? CuerpoMedicos { get; set; }
  public ICollection<CuerpoTecnico>? CuerpoTecnicos { get; set; }
  public ICollection<Jugador>? Jugadors { get; set; }
  public ICollection<EquipoJugador>? EquipoJugadors { get; set; }
  public ICollection<EstadisticaEquipo>? EstadisticaEquipos { get; set; }
  public ICollection<TorneoEquipo>? TorneosEquipos { get; set; }
  public ICollection<Transferencia>? TransferenciasOrigen { get; set; }
  public ICollection<Transferencia>?TransferenciasDestino { get; set; }

  public Equipo(int id, string? nombre, string? ciudad, string? pais, string? estadio, string? tipoEquipo, int? cantidadTitulos)
  {
    Id = id;
    Nombre = nombre;
    Ciudad = ciudad;
    Pais = pais;
    Estadio = estadio;
    TipoEquipo = tipoEquipo;
    CantidadTitulos = cantidadTitulos;
  }
  public Equipo() { }
  public override string ToString()
  {
    return $"🏟️ Equipo: {Nombre} | Ciudad: {Ciudad}, País: {Pais} | Estadio: {Estadio}\n" +
          $"🏆 Títulos ganados: {CantidadTitulos}\n";
  }
}
