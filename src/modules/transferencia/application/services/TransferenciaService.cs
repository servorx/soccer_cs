using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.models;

namespace soccer_cs.services;

public class TransferenciaService : ITransferenciaService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly ITransferenciaRepository _transferenciaRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  public TransferenciaService(ITransferenciaRepository transferenciaRepository) => _transferenciaRepository = transferenciaRepository;
  public async Task RealizarTransferenciaAsync(int id_jugador, int id_equipo_origen, int id_equipo_destino, string tipo_transferencia, float valor_transferencia, DateTime fecha_transferencia)
  {
    _transferenciaRepository.Add(new Transferencia
    {
      JugadorId = id_jugador,
      EquipoOrigenId = id_equipo_origen,
      EquipoDestinoId = id_equipo_destino,
      TipoTransferencia = tipo_transferencia,
      ValorTransferencia = valor_transferencia,
      FechaTransferencia = fecha_transferencia
    });
    await _transferenciaRepository.SaveAsync();
  }
  public async Task ActualizarTransferenciaAsync(int id, Transferencia transferencia)
  {
    var existingTransferencia = await _transferenciaRepository.GetByIdAsync(id);
    if (existingTransferencia != null)
    {
      existingTransferencia.EquipoDestinoId = transferencia.EquipoDestinoId;
      existingTransferencia.EquipoOrigenId = transferencia.EquipoOrigenId;
      existingTransferencia.TipoTransferencia = transferencia.TipoTransferencia;
      existingTransferencia.ValorTransferencia = transferencia.ValorTransferencia;
      existingTransferencia.FechaTransferencia = transferencia.FechaTransferencia;
      _transferenciaRepository.Update(existingTransferencia);
      await _transferenciaRepository.SaveAsync();
    }
  }
  public async Task EliminarTransferenciaAsync(int id)
  {
    var transferencia = await _transferenciaRepository.GetByIdAsync(id);
    if (transferencia != null)
    {
      _transferenciaRepository.Remove(transferencia);
      await _transferenciaRepository.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<Transferencia?>> VerTodoTransferenciaAsync() => await _transferenciaRepository.GetAllAsync();
  public async Task<Transferencia?> VerHistorialTransferenciaPorJugadorAsync(int id_jugador) => await _transferenciaRepository.ObtenerTransferenciasPorJugador(id_jugador);
  public async Task<Transferencia?> VerHistorialTransferenciaPorEquipoAsync(int id_equipo) => await _transferenciaRepository.GetByIdAsync(id_equipo);
  public async Task<Transferencia?> ObtenerTransferenciaPorIdAsync(int id) => await _transferenciaRepository.GetByIdAsync(id);
  
}
