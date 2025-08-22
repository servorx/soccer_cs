using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.equipo.application.interfaces;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.equipo.application.services;

public class EquipoService : IEquipoService
{
    // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly IEquipoRepository _equipoRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad

  public EquipoService(IEquipoRepository equipoRepository) =>_equipoRepository = equipoRepository;
  public async Task AgregarEquipoAsync(Equipo equipo)
  {
    _equipoRepository.Add(equipo);
    await _equipoRepository.SaveAsync();
  }
  public async Task ActualizarEquipoAsync(int id, Equipo equipo)
  {
    var existingEquipo = await _equipoRepository.GetByIdAsync(id);
    if (existingEquipo != null)
    {
      existingEquipo.Nombre = equipo.Nombre;
      existingEquipo.Id = equipo.Id;
      _equipoRepository.Update(existingEquipo);
      await _equipoRepository.SaveAsync();
    }
  }
  public async Task EliminarEquipoAsync(int id)
  {
    var equipo = await _equipoRepository.GetByIdAsync(id);
    if (equipo != null)
    {
      _equipoRepository.Remove(equipo);
      await _equipoRepository.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<Equipo?>> MostrarEquiposAsync() => await _equipoRepository.GetAllAsync();
  public async Task<Equipo?> ObtenerEquipoPorIdAsync(int id) => await _equipoRepository.GetByIdAsync(id);
  public async Task<Equipo?> ObtenerEquipoPorNombreAsync(string nombre) => await _equipoRepository.GetByNameAsync(nombre); 
  // estas son las partes de las funcionalidades donde se manipulan los datos con otras entitdades y sus relaciones
  public async Task<IEnumerable<Jugador?>> ObtenerJugadoresPorEquipoAsync(int id_equipo) => await _equipoRepository.GetJugadoresByEquipoIdAsync(id_equipo); 
}
