using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs.models;

public class Torneo
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Tipo { get; set; }
  public string? Ubicacion { get; set; }
  public string? FechaCreacion { get; set; }
  public int DuracionDias { get; set; }
  public string? Premio { get; set; }
  public List<Equipo?> EquiposParticipantes { get; set; } = new();
  public Torneo(int id, string? nombre, string? tipo, string? ubicacion, string? fechaCreacion, int duracionDias, string? premio, List<Equipo?> equiposParticipantes)
  {
    Id = id;
    Nombre = nombre;
    Tipo = tipo;
    Ubicacion = ubicacion;
    FechaCreacion = fechaCreacion;
    DuracionDias = duracionDias;
    Premio = premio;
    EquiposParticipantes = equiposParticipantes;
  }
  public Torneo() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Torneo: {Nombre}");
    Console.WriteLine($"Ubicación: {Ubicacion}");
    Console.WriteLine($"Fecha de Creación: {FechaCreacion}");
    Console.WriteLine($"Duración: {DuracionDias} días");
    Console.WriteLine($"Premio: {Premio}");
    Console.WriteLine("Equipos Participantes:");
    foreach (var equipo in EquiposParticipantes)
    {
      if (equipo != null)
      {
        Console.WriteLine($"- {equipo.Nombre}");
      }
    }
  }
}