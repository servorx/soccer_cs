using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;

public interface IPersonaService
{
  // como tal muchos de estos metodos son innecesarios pero se usan para realizar un copy paste para todas las entidades debido al CRUD basico
  void CrearPersona();
  void EditarPersona();
  void EliminarPersona();
  void MostrarPersonas();
  void MostrarPersonaPorId(int id);
}
