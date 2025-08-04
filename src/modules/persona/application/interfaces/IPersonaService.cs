using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;

// este archivo es el puerto de entrada de la aplicacion. declara las operaciones del servicio que usará tu aplicación para interactuar con el repositorio.
public interface IPersonaService
{
  void RegistrarPersona(Persona persona);
  Persona? BuscarPersona(int id);
  List<Persona> ListarPersonas();
  void EditarPersona(Persona persona);
  void EliminarPersona(int id);
}
