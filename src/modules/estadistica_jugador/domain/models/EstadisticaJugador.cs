using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.estadistica_jugador.domain.models;
public class EstadisticaJugador
{
  public int Id { get; set; }
  public int Goles { get; set; }
  public int Asistencias { get; set; }
  public int PartidosJugados { get; set; }
  public decimal Estatura { get; set; }
  public decimal Peso { get; set; }
  public int TarjetasAmarillas { get; set; }
  public int TarjetasRojas { get; set; }
  public DateTime FechaCreacion { get; set; }
  // relaciones con las claves foraneas, en este caos de uno a muchos
  public int IdJugador { get; set; }
  public Jugador? Jugador { get; set; }
  public EstadisticaJugador(
    int goles, int asistencias, int partidosJugados, decimal estatura, decimal peso,
    int tarjetasAmarillas, int tarjetasRojas, DateTime fechaCreacion)
  {
    Goles = goles;
    Asistencias = asistencias;
    PartidosJugados = partidosJugados;
    Estatura = estatura;
    Peso = peso;
    TarjetasAmarillas = tarjetasAmarillas;
    TarjetasRojas = tarjetasRojas;
    FechaCreacion = fechaCreacion;
  }
  public EstadisticaJugador() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Goles: {Goles}, Asistencias: {Asistencias}, Partidos Jugados: {PartidosJugados}");
    Console.WriteLine($"Estatura: {Estatura} m, Peso: {Peso} kg");
    Console.WriteLine($"Tarjetas Amarillas: {TarjetasAmarillas}, Tarjetas Rojas: {TarjetasRojas}");
  }
}
