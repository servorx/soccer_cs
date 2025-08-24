using soccer_cs.src.modules.domain.models;
using soccer_cs.src.modules.equipo_jugador.domain.models;
using soccer_cs.src.modules.estadistica_jugador.domain.models;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.jugador.domain.models;

public class Jugador
{
  public int Id { get; set; }
  public int IdPersona { get; set; }
  public string? Posicion { get; set; }
  public int NumeroDorsal { get; set; }
  public string? PieHabil { get; set; }
  public decimal ValorMercado { get; set; }
  // relaciones de clases foraneas, persona
  public Persona Persona { get; set; } = null!;
  // estas son relaciones de uno a muchos 
  public ICollection<EstadisticaJugador>? EstadisticaJugadors { get; set; }
  public ICollection<EquipoJugador>? EquipoJugadors { get; set; }
  public ICollection<Transferencia>? Transferencias { get; set; }
  public Jugador(int id, int idPersona, string? posicion, int numeroDorsal, string? pieHabil, decimal valorMercado)
  {
    // Atributos especificos de Jugador 
    IdPersona = idPersona;
    Posicion = posicion;
    NumeroDorsal = numeroDorsal;
    PieHabil = pieHabil;
    ValorMercado = valorMercado;
  }
  public Jugador() { }
  public override string ToString()
  {
    return $"{Persona?.Nombre} {Persona?.Apellido} - {Posicion} (Dorsal: {NumeroDorsal}, Valor: {ValorMercado})";
  }
}
