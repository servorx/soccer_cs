using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs.models;

public class Transferencia
{
  public int Id { get; set; }
  public int JugadorId { get; set; }
  public string? EquipoOrigen { get; set; }
  public string? EquipoDestino { get; set; }
  public string? TipoTransferencia { get; set; }
  public float ValorTransferencia { get; set; }
  public Transferencia(int id, int jugadorId, string? equipoOrigen, string? equipoDestino, string? tipoTransferencia, float valorTransferencia)
  {
    Id = id;
    JugadorId = jugadorId;
    EquipoOrigen = equipoOrigen;
    EquipoDestino = equipoDestino;
    TipoTransferencia = tipoTransferencia;
    ValorTransferencia = valorTransferencia;
  }
  public Transferencia() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Transferencia ID: {Id}");
    Console.WriteLine($"Jugador ID: {JugadorId}");
    Console.WriteLine($"Equipo Origen: {EquipoOrigen}");
    Console.WriteLine($"Equipo Destino: {EquipoDestino}");
    Console.WriteLine($"Tipo de Transferencia: {TipoTransferencia}");
    Console.WriteLine($"Valor de Transferencia: {ValorTransferencia:C}");
  }
}
