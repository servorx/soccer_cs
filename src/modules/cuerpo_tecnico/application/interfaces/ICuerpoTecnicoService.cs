using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public interface ICuerpoTecnicoService
{
  Task<CuerpoMedico?> GetByIdAsync(int id);
  Task<IEnumerable<CuerpoMedico?>> GetAllAsync();
  void Add(CuerpoMedico entity);
  void Remove(CuerpoMedico entity);
  void Update(CuerpoMedico entity);
  Task SaveAsync();
}

