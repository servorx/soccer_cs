using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public interface ICuerpoTecnicoRepository
{
  void Add(CuerpoTecnico entity);
  void Update(CuerpoTecnico entity);
  void Remove(CuerpoTecnico entity);
  Task<IEnumerable<CuerpoTecnico?>> GetAllAsync();
  Task<CuerpoTecnico?> GetByIdAsync(int id);
  Task<CuerpoTecnico?> GetByNameAsync(string nombre);
  Task SaveAsync();
}
