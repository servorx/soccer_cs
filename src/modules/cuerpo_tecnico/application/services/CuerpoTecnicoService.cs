using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public class CuerpoTecnicoService : ICuerpoTecnicoService
{
    // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly ICuerpoTecnicoRepository _cuerpoTecnicoRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  public CuerpoTecnicoService(ICuerpoTecnicoRepository cuerpoTecnicoRepository) =>_cuerpoTecnicoRepository = cuerpoTecnicoRepository;
  public async Task AgregarCuerpoTecnicoAsync(CuerpoTecnico cuerpoTecnico)
  {
    _cuerpoTecnicoRepository.Add(cuerpoTecnico);
    await _cuerpoTecnicoRepository.SaveAsync();
  }
  public async Task ActualizarCuerpoTecnicoAsync(int id, CuerpoTecnico cuerpoTecnico)
  {
    var existingCuerpoTecnico = await _cuerpoTecnicoRepository.GetByIdAsync(id);
    if (existingCuerpoTecnico != null)
    {
      existingCuerpoTecnico.Nombre = cuerpoTecnico.Nombre;
      existingCuerpoTecnico.Id = cuerpoTecnico.Id;
      _cuerpoTecnicoRepository.Update(existingCuerpoTecnico);
      await _cuerpoTecnicoRepository.SaveAsync();
    }
  }
  public async Task EliminarCuerpoTecnicoAsync(int id)
  {
    var cuerpoTecnico = await _cuerpoTecnicoRepository.GetByIdAsync(id);
    if (cuerpoTecnico != null)
    {
      _cuerpoTecnicoRepository.Remove(cuerpoTecnico);
      await _cuerpoTecnicoRepository.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<CuerpoTecnico?>> MostrarCuerpoTecnicosAsync() => await _cuerpoTecnicoRepository.GetAllAsync();
  public async Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorIdAsync(int id) => await _cuerpoTecnicoRepository.GetByIdAsync(id);
  public async Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorNombreAsync(string nombre) => await _cuerpoTecnicoRepository.GetByNameAsync(nombre); 
  // estas son las partes de las funcionalidades donde se manipulan los datos con otras entitdades y sus relaciones
  public async Task RegistrarCuerpoTecnicoEquipoAsync(int id_cuerpo_tecnico, int id_equipo)
  {
    var cuerpo_tecnico = await _cuerpoTecnicoRepository.GetByIdAsync(id_cuerpo_tecnico);
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    cuerpo_tecnico.EquipoId = id_equipo;
    _cuerpoTecnicoRepository.Update(cuerpo_tecnico);
  }
  public async Task EliminarCuerpoTecnicoEquipoAsync(int id_cuerpo_tecnico, int id_equipo)
  {
    var cuerpo_tecnico = await _cuerpoTecnicoRepository.GetByIdAsync(id_cuerpo_tecnico);
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    cuerpo_tecnico.EquipoId = null;
    _cuerpoTecnicoRepository.Update(cuerpo_tecnico);
  }
}
