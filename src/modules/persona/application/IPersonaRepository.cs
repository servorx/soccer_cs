using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.infrastructure.data;
using soccer_cs;

namespace soccer_cs.application;

public interface IPersonaRepository : IGenericRepository<Persona>
{
  List<Persona> ObtenerTodasLasPersonas();
}
