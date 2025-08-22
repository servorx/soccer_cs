using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;

namespace soccer_cs.src.modules.cuerpo_tecnico.application.interfaces;
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
