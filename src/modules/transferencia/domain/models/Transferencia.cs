using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules.equipo.domain;

namespace soccer_cs.models;

public class Transferencia
{
  public int Id { get; set; }
  public string? TipoTransferencia { get; set; }
  public decimal ValorTransferencia { get; set; }
  public DateTime FechaTransferencia { get; set; }
  // relaciones con fk
  public int JugadorId { get; set; }
  public Jugador? Jugador { get; set; }
  public int EquipoOrigenId { get; set; }
  public Equipo? EquipoOrigen { get; set; }
  public int EquipoDestinoId { get; set; }
  public Equipo? EquipoDestino { get; set; }
  public Transferencia(
      int jugadorId,
      int equipoOrigenId,
      int equipoDestinoId,
      string? tipoTransferencia,
      decimal valorTransferencia,
      DateTime fechaTransferencia)
    {
      JugadorId = jugadorId;
      EquipoOrigenId = equipoOrigenId;
      EquipoDestinoId = equipoDestinoId;
      TipoTransferencia = tipoTransferencia;
      ValorTransferencia = valorTransferencia;
      FechaTransferencia = fechaTransferencia;
    }
  public Transferencia() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Transferencia ID: {Id}");
    Console.WriteLine($"Jugador ID: {JugadorId} - Nombre: {Jugador?.Nombre} {Jugador?.Apellido}");
    Console.WriteLine($"Equipo Origen ID: {EquipoOrigenId} - Nombre: {EquipoOrigen?.Nombre}");
    Console.WriteLine($"Equipo Destino ID: {EquipoDestinoId} - Nombre: {EquipoDestino?.Nombre}");
    Console.WriteLine($"Tipo de Transferencia: {TipoTransferencia}");
    Console.WriteLine($"Valor de Transferencia: {ValorTransferencia:C}");
    Console.WriteLine($"Fecha de Transferencia: {FechaTransferencia.ToShortDateString()}");
  }
}
