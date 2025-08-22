using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.torneo_equipo.domain.models;

namespace soccer_cs.src.modules.torneo.domain.models;

public class Torneo
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Tipo { get; set; }
  public string? Ubicacion { get; set; }
  public DateTime FechaInicio { get; set; }
  public DateTime FechaFinal { get; set; }
  public float? Premio { get; set; }
  // deficion de que forma parte de la fk de TorneoEquipo
  public ICollection<TorneoEquipo> TorneosEquipos { get; set; } = new List<TorneoEquipo>();
  public Torneo(int id, string? nombre, string? tipo, string? ubicacion, DateTime fechaInicio, DateTime fechaFinal, float? premio)
  {
    Id = id;
    Nombre = nombre;
    Tipo = tipo;
    Ubicacion = ubicacion;
    FechaInicio = fechaInicio;
    FechaFinal = fechaFinal;
    Premio = premio;
  }
  public Torneo() { }
  public void MostrarResumen()
  {
    Console.WriteLine($"Torneo: {Nombre}");
    Console.WriteLine($"Ubicación: {Ubicacion}");
    Console.WriteLine($"Fecha de Creación: {FechaInicio}");
    Console.WriteLine($"Fecha final: {FechaFinal}");
    Console.WriteLine($"Premio: {Premio}");
  }
}