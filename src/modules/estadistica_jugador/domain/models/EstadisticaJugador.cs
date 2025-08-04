using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs.models;
public class EstadisticaJugador
{
  public int Id { get; set; }
  // public int? JugadorId { get; set; }
  public int Goles { get; set; }
  public int Asistencias { get; set; }
  public int PartidosJugados { get; set; }
  public float Estatura { get; set; }
  public float Peso { get; set; }
  public int TarjetasAmarillas { get; set; }
  public int TarjetasRojas { get; set; }
  public EstadisticaJugador(int id,
    int goles, int asistencias, int partidosJugados, float estatura, float peso,
    int tarjetasAmarillas, int tarjetasRojas)
  {
    Id = id;
    Goles = goles;
    Asistencias = asistencias;
    PartidosJugados = partidosJugados;
    Estatura = estatura;
    Peso = peso;
    TarjetasAmarillas = tarjetasAmarillas;
    TarjetasRojas = tarjetasRojas;
  }

  public EstadisticaJugador() { }

  public void MostrarResumen()
  {
    Console.WriteLine($"Goles: {Goles}, Asistencias: {Asistencias}, Partidos Jugados: {PartidosJugados}");
    Console.WriteLine($"Estatura: {Estatura} m, Peso: {Peso} kg");
    Console.WriteLine($"Tarjetas Amarillas: {TarjetasAmarillas}, Tarjetas Rojas: {TarjetasRojas}");
  }
}
