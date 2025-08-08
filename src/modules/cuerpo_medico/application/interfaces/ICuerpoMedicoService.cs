using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public interface ICuerpoMedicoService
{
  Task AddCuerpoMedicoAsync(CuerpoMedico cuerpoMedico);
  Task UpdateCuerpoMedicoAsync(int id, CuerpoMedico cuerpoMedico);
  Task RemoveCuerpoMedicoAsync(int id);
  Task<CuerpoMedico?> GetCuerpoMedicoById(int id);
  Task<IEnumerable<CuerpoMedico?>> GetAllCuerpoMedicos();
}
