using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.torneo.domain.models;

namespace soccer_cs.src.modules.torneo.application.interfaces;
public interface ITorneoRepository
{
  void Add(Torneo entity);
  void Update(Torneo entity);
  void Remove(Torneo entity);
  Task<IEnumerable<Torneo?>> GetAllAsync();
  Task<Torneo?> GetByIdAsync(int id);
  Task<Torneo?> GetByNameAsync(string nombre);
  Task SaveAsync();
}
