using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;

namespace soccer_cs.src.modules.cuerpo_tecnico.application.interfaces;

public interface ICuerpoTecnicoService
{
  Task AgregarCuerpoTecnicoAsync(CuerpoTecnico cuerpoTecnico);
  Task ActualizarCuerpoTecnicoAsync(int id, CuerpoTecnico cuerpoTecnico);
  Task EliminarCuerpoTecnicoAsync(int id);
  Task<IEnumerable<CuerpoTecnico?>> MostrarCuerpoTecnicosAsync();
  Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorIdAsync(int id);
  Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorNombreAsync(string nombre);
  Task RegistrarCuerpoTecnicoEquipoAsync(int id_cuerpo_tecnico, int id_equipo);
  Task EliminarCuerpoTecnicoEquipoAsync(int id_cuerpo_tecnico, int id_equipo);
}

