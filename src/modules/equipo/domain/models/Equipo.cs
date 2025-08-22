using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.modules.domain.models;
using soccer_cs.src.modules.equipo_jugador.domain.models;
using soccer_cs.src.modules.estadistica_equipo.domain.models;
using soccer_cs.src.modules.torneo_equipo.domain.models;

namespace soccer.src.modules.equipo.domain.models;

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
  public ICollection<CuerpoMedico> CuerpoMedicos { get; set; } = null!;
  public ICollection<CuerpoTecnico> CuerpoTecnicos { get; set; }  = null!;
  public ICollection<EquipoJugador> EquipoJugadors { get; set; } = null!;
  public ICollection<EstadisticaEquipo> EstadisticaEquipos { get; set; } = null!;
  public ICollection<TorneoEquipo> TorneosEquipos { get; set; } = null!;
  public ICollection<Transferencia> TransferenciasOrigen { get; set; } = null!;
  public ICollection<Transferencia> TransferenciasDestino { get; set; } = null!;

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
