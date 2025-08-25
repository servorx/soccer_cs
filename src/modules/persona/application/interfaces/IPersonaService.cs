using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.persona.application.interfaces;

// este archivo es el puerto de entrada de la aplicacion. declara las operaciones del servicio que usará tu aplicación para interactuar con el repositorio.
public interface IPersonaService
{
  Task<Persona> AgregarPersonaAsync(Persona persona);
  Task ActualizarPersonaAsync(int id, Persona persona);
  Task EliminarPersonaAsync(int id);
  Task<Persona?> ObtenerPersonaPorIdAsync(int id);
  Task<IEnumerable<Persona>> GetAllPersonasAsync();
}
