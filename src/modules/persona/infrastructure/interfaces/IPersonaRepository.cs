using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.infrastructure.data;
using soccer_cs;

namespace soccer_cs.application;

public interface IPersonaRepository : IGenericRepository<Persona>
{
  // como tal todas estas funcioanlidades son inescesarias pero se usan para realizar un copy paste para todas las entidades
  List<Persona> ObtenerTodasLasPersonas();
  Task<List<Persona>> ObtenerTodasAsync();
  Task<Persona?> ObtenerPorIdAsync(int id);
  Task CrearAsync(Persona persona);
  Task ActualizarAsync(Persona persona);
  Task EliminarAsync(int id);
}
