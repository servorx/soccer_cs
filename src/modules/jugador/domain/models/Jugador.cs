using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Prng;
using soccer.modules.equipo.domain;

namespace soccer_cs.models;

public class Jugador : Persona
{
  public string? Posicion { get; set; }
  public int NumeroDorsal { get; set; }
  public string? PieHabil { get; set; }
  public float ValorMercado { get; set; }
  // relaciones de clases foraneas, persona
  public int PersonaId { get; set; }
  public Persona? Persona { get; set; }
  // estas son relaciones de uno a muchos 
  public ICollection<EstadisticaJugador>? EstadisticaJugadors { get; set; }
  public ICollection<EquipoJugador>? EquipoJugadors { get; set; }
  public ICollection<Transferencia>? Transferencias { get; set; }
  public Jugador(string? nombre, string? apellido, int edad, string? nacionalidad, int documento_identidad, string? genero,
    string? posicion, int numeroDorsal, string? pieHabil, float valorMercado)
    : base(nombre, apellido, edad, nacionalidad, documento_identidad, genero)
  {
    // Atributos especificos de Jugador 
    Posicion = posicion;
    NumeroDorsal = numeroDorsal;
    PieHabil = pieHabil;
    ValorMercado = valorMercado;
  }
  public Jugador() { }
  public override string ToString()
  {
    return $"{Nombre} {Apellido} - {Posicion} (Dorsal: {NumeroDorsal}, Valor: {ValorMercado})";
  }
}
