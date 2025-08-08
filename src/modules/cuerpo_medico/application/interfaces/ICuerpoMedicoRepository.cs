using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Tls;

namespace soccer_cs;

public interface ICuerpoMedicoRepository
{
  Task<CuerpoMedico?> GetByIdAsync(int id);
  Task<IEnumerable<CuerpoMedico?>> GetAllAsync();
  void Add(CuerpoMedico entity);
  void Remove(CuerpoMedico entity);
  void Update(CuerpoMedico entity);
  Task SaveAsync();
}
