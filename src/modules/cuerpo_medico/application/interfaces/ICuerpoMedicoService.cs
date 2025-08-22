using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.cuerpo_medico.domain.models;

namespace soccer_cs.src.modules.cuerpo_medico.application.interfaces;

public interface ICuerpoMedicoService
{
  Task AgregarCuerpoMedicoAsync(CuerpoMedico cuerpoMedico);
  Task ActualizarCuerpoMedicoAsync(int id, CuerpoMedico cuerpoMedico);
  Task EliminarCuerpoMedicoAsync(int id);
  Task<IEnumerable<CuerpoMedico?>> MostrarCuerpoMedicosAsync();
  Task<CuerpoMedico?> ObtenerCuerpoMedicoPorIdAsync(int id);
  Task<CuerpoMedico?> ObtenerCuerpoMedicoPorNombreAsync(string nombre);
  Task RegistrarCuerpoMedicoEquipoAsync(int id_cuerpo_medico, int id_equipo);
  Task EliminarCuerpoMedicoEquipoAsync(int id_cuerpo_medico, int id_equipo);
}