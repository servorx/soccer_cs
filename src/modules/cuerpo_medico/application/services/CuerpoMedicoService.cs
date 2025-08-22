using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.equipo.application.interfaces;

namespace soccer_cs.src.modules.cuerpo_medico.application.services;

public class CuerpoMedicoService : ICuerpoMedicoService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly ICuerpoMedicoRepository _cuerpoMedicoRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  private readonly IEquipoRepository _equipoRepository;
  public CuerpoMedicoService(ICuerpoMedicoRepository cuerpoMedicoRepository) =>_cuerpoMedicoRepository = cuerpoMedicoRepository;
  public async Task AgregarCuerpoMedicoAsync(CuerpoMedico cuerpoMedico)
  {
    _cuerpoMedicoRepository.Add(cuerpoMedico);
    await _cuerpoMedicoRepository.SaveAsync();
  }
  public async Task ActualizarCuerpoMedicoAsync(int id, CuerpoMedico cuerpoMedico)
  {
    var existingCuerpoMedico = await _cuerpoMedicoRepository.GetByIdAsync(id);
    if (existingCuerpoMedico != null)
    {
      existingCuerpoMedico.Persona.Nombre = cuerpoMedico.Persona.Nombre;
      existingCuerpoMedico.IdPersona = cuerpoMedico.IdPersona; 
      _cuerpoMedicoRepository.Update(existingCuerpoMedico);
      await _cuerpoMedicoRepository.SaveAsync();
    }
  }
  public async Task EliminarCuerpoMedicoAsync(int id)
  {
    var cuerpoMedico = await _cuerpoMedicoRepository.GetByIdAsync(id);
    if (cuerpoMedico != null)
    {
      _cuerpoMedicoRepository.Remove(cuerpoMedico);
      await _cuerpoMedicoRepository.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<CuerpoMedico?>> MostrarCuerpoMedicosAsync() => await _cuerpoMedicoRepository.GetAllAsync();
  public async Task<CuerpoMedico?> ObtenerCuerpoMedicoPorIdAsync(int id) => await _cuerpoMedicoRepository.GetByIdAsync(id);
  public async Task<CuerpoMedico?> ObtenerCuerpoMedicoPorNombreAsync(string nombre) => await _cuerpoMedicoRepository.GetByNameAsync(nombre); 
  // estas son las partes de las funcionalidades donde se manipulan los datos con otras entitdades y sus relaciones
  public async Task RegistrarCuerpoMedicoEquipoAsync(int id_cuerpo_medico, int id_equipo)
  {
    var cuerpo_medico = await _cuerpoMedicoRepository.GetByIdAsync(id_cuerpo_medico);
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    cuerpo_medico.IdEquipo = id_equipo; 
    _cuerpoMedicoRepository.Update(cuerpo_medico);
  }
  public async Task EliminarCuerpoMedicoEquipoAsync(int id_cuerpo_medico, int id_equipo)
  {
    var cuerpo_medico = await _cuerpoMedicoRepository.GetByIdAsync(id_cuerpo_medico);
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    cuerpo_medico.IdEquipo = 0;
    _cuerpoMedicoRepository.Update(cuerpo_medico);
  }
}
