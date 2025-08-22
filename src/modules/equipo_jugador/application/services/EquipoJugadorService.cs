using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.equipo_jugador.application.interfaces;
using soccer_cs.src.modules.equipo_jugador.domain.models;

namespace soccer_cs.src.modules.equipo_jugador.application.services;
public class EquipoJugadorService : IEquipoJugadorService
{
    private readonly IEquipoJugadorRepository _equipoJugadorRepository;

    public EquipoJugadorService(IEquipoJugadorRepository equipoJugadorRepository)
        => _equipoJugadorRepository = equipoJugadorRepository;

    // Crear nueva relación Equipo - Jugador
    public async Task AgregarEquipoJugadorAsync(EquipoJugador equipoJugador)
    {
        _equipoJugadorRepository.Add(equipoJugador);
        await _equipoJugadorRepository.SaveAsync();
    }

    // Actualizar relación (ej: cambiar de equipo un jugador o viceversa)
    public async Task ActualizarEquipoJugadorAsync(int id, EquipoJugador equipoJugador)
    {
        var existingEquipoJugador = await _equipoJugadorRepository.GetByIdAsync(id);
        if (existingEquipoJugador != null)
        {
            existingEquipoJugador.IdEquipo = equipoJugador.IdEquipo;
            existingEquipoJugador.IdJugador = equipoJugador.IdJugador;

            _equipoJugadorRepository.Update(existingEquipoJugador);
            await _equipoJugadorRepository.SaveAsync();
        }
    }

    // Eliminar relación (Jugador deja un equipo)
    public async Task EliminarEquipoJugadorAsync(int id)
    {
        var equipoJugador = await _equipoJugadorRepository.GetByIdAsync(id);
        if (equipoJugador != null)
        {
            _equipoJugadorRepository.Remove(equipoJugador);
            await _equipoJugadorRepository.SaveAsync();
        }
    }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<EquipoJugador?>> MostrarEquipoJugadorsAsync() => await _equipoJugadorRepository.GetAllAsync();
}
