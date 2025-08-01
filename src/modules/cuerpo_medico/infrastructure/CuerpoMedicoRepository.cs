using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.infrastructure.data;

namespace soccer_cs;

public class CuerpoMedicoRepository : IGenericRepository<CuerpoMedico>, ICuerpoMedicoRepository
{
  private readonly ConexionSingleton _conexion;
  public CuerpoMedicoRepository(string connectionString)
  {
    _conexion = ConexionSingleton.Instancia(conecctionString);
  }
  public void Crear(CuerpoMedico entity)
  {
    // Implementación para crear un cuerpo médico en la base de datos
    throw new NotImplementedException();
  }
  public void Actualizar(CuerpoMedico entity)
  {
    // Implementación para actualizar un cuerpo médico en la base de datos
    throw new NotImplementedException();
  }
  public void Eliminar(int id)
  {
    // Implementación para eliminar un cuerpo médico por ID
    throw new NotImplementedException();
  }
  public List<CuerpoMedico> ObtenerTodosLosCuerposMedicos()
  {
    // Implementación para obtener todos los cuerpos médicos de la base de datos
    throw new NotImplementedException();
  }
}
