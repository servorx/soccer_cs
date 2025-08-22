using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.domain.models;

public class Transferencia
{
  public int Id { get; set; }
  public string? TipoTransferencia { get; set; }
  public float? ValorTransferencia { get; set; }
  public DateTime FechaTransferencia { get; set; }
  // relaciones con fk
  public int IdJugador { get; set; }
  public int IdEquipoOrigen { get; set; }
  public int IdEquipoDestino { get; set; }
  public Jugador? Jugador { get; set; }
  public Equipo? EquipoOrigen { get; set; }
  public Equipo? EquipoDestino { get; set; }
  public Transferencia(
      int idJugador,
      int idEquipoOrigen,
      int idEquipoDestino,
      string? tipoTransferencia,
      float valorTransferencia,
      DateTime fechaTransferencia)
    {
      IdJugador = idJugador;
      IdEquipoOrigen = idEquipoOrigen;  
      IdEquipoDestino = idEquipoDestino;
      TipoTransferencia = tipoTransferencia;
      ValorTransferencia = valorTransferencia;
      FechaTransferencia = fechaTransferencia;
    }
  public Transferencia() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Transferencia ID: {Id}");
    Console.WriteLine($"Jugador ID: {IdJugador} - Nombre: {Jugador?.Persona?.Nombre} {Jugador?.Persona?.Apellido}");
    Console.WriteLine($"Equipo Origen ID: {IdEquipoOrigen} - Nombre: {EquipoOrigen?.Nombre}");
    Console.WriteLine($"Equipo Destino ID: {IdEquipoDestino} - Nombre: {EquipoDestino?.Nombre}");
    Console.WriteLine($"Tipo de Transferencia: {TipoTransferencia}");
    Console.WriteLine($"Valor de Transferencia: {ValorTransferencia:C}");
    Console.WriteLine($"Fecha de Transferencia: {FechaTransferencia.ToShortDateString()}");
  }
}
