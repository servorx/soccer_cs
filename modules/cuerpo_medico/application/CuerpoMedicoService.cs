using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;

public class CuerpoMedicoService : IGenericRepository<CuerpoMedico>
{
  List<CuerpoMedico> cuerpoMedicos = new List<CuerpoMedico>();

  public void Crear(CuerpoMedico entity)
  {
    cuerpoMedicos.Add(entity);
  }

  // TODO: no entiendo nada 
  public void Actualizar(CuerpoMedico entity)
  {
    var index = cuerpoMedicos.FindIndex(cm => cm.Id == entity.Id);
    if (index != -1)
    {
      cuerpoMedicos[index] = entity;
    }
  }

  public void Eliminar(int id)
  {
    var entity = cuerpoMedicos.FirstOrDefault(cm => cm.Id == id);
    if (entity != null)
    {
      cuerpoMedicos.Remove(entity);
    }
  }
}
