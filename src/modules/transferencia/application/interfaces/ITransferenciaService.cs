using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public interface ITransferenciaService
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
