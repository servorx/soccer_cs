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
  // tengo que experimentar con esto pero basicamente es la composicion de anidarlo con otras listas como cuerpo tecnico, cuerpo medico y jugadores
  public List<Jugador?> Jugadores { get; set; } = new();
  public List<CuerpoTecnico?> CuerpoTecnico { get; set; } = new();
  public List<CuerpoMedico?> CuerpoMedico { get; set; } = new();
  public List<Torneo?> TorneosInscritos { get; set; } = new();
  public List<EstadisticaEquipo?> EstadisticaEquipos { get; set; } = new();

  public Equipo(int id, string? nombre, string? ciudad, string? pais, string? estadio, string? tipoEquipo, int? cantidadTitulos, List<Jugador?> jugadores, List<CuerpoTecnico?> cuerpoTecnico, List<CuerpoMedico?> cuerpoMedico, List<Torneo?> torneosInscritos, List<EstadisticaEquipo?> estadisticaEquipos)
  {
    Id = id;
    Nombre = nombre;
    Ciudad = ciudad;
    Pais = pais;
    Estadio = estadio;
    TipoEquipo = tipoEquipo;
    CantidadTitulos = cantidadTitulos;
    Jugadores = jugadores;
    CuerpoTecnico = cuerpoTecnico;
    CuerpoMedico = cuerpoMedico;
    TorneosInscritos = torneosInscritos;
    EstadisticaEquipos = estadisticaEquipos;
  }
  public Equipo() { }
  public override string ToString()
  {
    return $"🏟️ Equipo: {Nombre} | Ciudad: {Ciudad}, País: {Pais} | Estadio: {Estadio}\n" +
          $"🏆 Títulos ganados: {CantidadTitulos}\n" +
          $"👥 Jugadores: {Jugadores.Count} | 🎓 Técnicos: {CuerpoTecnico.Count} | 🏥 Médicos: {CuerpoMedico.Count}\n" +
          $"📋 Torneos inscritos: {TorneosInscritos.Count}";
  }
}
