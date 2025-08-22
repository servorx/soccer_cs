using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.cuerpo_tecnico.application.interfaces;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.modules.equipo.application.interfaces;
using soccer_cs.src.modules.equipo.infrastructure.repositories;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.cuerpo_tecnico.application.services;
public class CuerpoTecnicoService : ICuerpoTecnicoService
{
    // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly ICuerpoTecnicoRepository _cuerpoTecnicoRepository = null!;
  private readonly IEquipoRepository _equipoRepository = null!;
  public CuerpoTecnicoService(ICuerpoTecnicoRepository cuerpoTecnicoRepository)
  {
    _cuerpoTecnicoRepository = cuerpoTecnicoRepository;
  }
  public async Task AgregarCuerpoTecnicoAsync(CuerpoTecnico? cuerpoTecnico)
  {
    var existe = await _cuerpoTecnicoRepository.GetByNameAsync(cuerpoTecnico.Persona.Nombre);
    if (existe != null)
    {
      throw new InvalidOperationException($"Ya existe un Cuerpo Técnico con nombre {cuerpoTecnico.Persona.Nombre}");
    }
    _cuerpoTecnicoRepository.Add(cuerpoTecnico);
    await _cuerpoTecnicoRepository.SaveAsync();
  }
  public async Task ActualizarCuerpoTecnicoAsync(int id, CuerpoTecnico cuerpoTecnico)
  {
    var existingCuerpoTecnico = await _cuerpoTecnicoRepository.GetByIdAsync(id);
    if (existingCuerpoTecnico != null)
    {
      existingCuerpoTecnico.Persona.Nombre = cuerpoTecnico.Persona.Nombre;
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
  if (cuerpo_tecnico is null)
  {
    throw new InvalidOperationException($"No se encontró Cuerpo Técnico con ID {id_cuerpo_tecnico}");
  }
  if (equipo is null)
  {
    throw new InvalidOperationException($"No se encontró Equipo con ID {id_equipo}");
  }
  cuerpo_tecnico.IdEquipo = id_equipo; 
  _cuerpoTecnicoRepository.Update(cuerpo_tecnico);
}


public async Task EliminarCuerpoTecnicoEquipoAsync(int id_cuerpo_tecnico, int id_equipo)
{
  var cuerpo_tecnico = await _cuerpoTecnicoRepository.GetByIdAsync(id_cuerpo_tecnico);
  var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
  if (cuerpo_tecnico is null)
  {
    throw new InvalidOperationException($"No se encontró Cuerpo Técnico con ID {id_cuerpo_tecnico}");
  }
  if (equipo is null)
  {
    throw new InvalidOperationException($"No se encontró Equipo con ID {id_equipo}");
  }
  cuerpo_tecnico.IdEquipo = null; // <- asegúrate de que IdEquipo sea `int?` (nullable) en tu entidad
  _cuerpoTecnicoRepository.Update(cuerpo_tecnico);
}
}
