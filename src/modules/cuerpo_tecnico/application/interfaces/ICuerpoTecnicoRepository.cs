using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public interface ICuerpoTecnicoRepository
{
  void Add(CuerpoMedico entity);
  void Update(CuerpoMedico entity);
  void Remove(CuerpoMedico entity);
  Task<IEnumerable<CuerpoMedico?>> GetAllAsync();
  Task<CuerpoMedico?> GetByIdAsync(int id);
  Task<CuerpoMedico?> GetByNameAsync(string nombre);
  Task SaveAsync();
    void Add(CuerpoTecnico cuerpoTecnico);
}
