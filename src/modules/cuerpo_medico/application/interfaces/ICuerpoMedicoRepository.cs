using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Tls;
using soccer_cs.src.modules.cuerpo_medico.domain.models;

namespace soccer_cs.src.modules.cuerpo_medico.application.interfaces;

public interface ICuerpoMedicoRepository
{
  void Add(CuerpoMedico entity);
  void Update(CuerpoMedico entity);
  void Remove(CuerpoMedico entity);
  Task<IEnumerable<CuerpoMedico?>> GetAllAsync();
  Task<CuerpoMedico?> GetByIdAsync(int id);
  Task<CuerpoMedico?> GetByNameAsync(string nombre);
  Task SaveAsync();
}
