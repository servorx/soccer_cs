using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;

// este archivo es el puerto de entrada de la aplicacion. declara las operaciones del servicio que usará tu aplicación para interactuar con el repositorio.
public interface IPersonaService
{
  // como tal muchos de estos metodos son innecesarios pero se usan para realizar un copy paste para todas las entidades debido al CRUD basico
  void CrearPersona(Persona persona);
  List<Persona> ObtenerPersonas();
  void EditarPersona();
  void EliminarPersona();
}
