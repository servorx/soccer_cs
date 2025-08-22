using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.domain.models;
using soccer_cs.src.modules.transferencia.application.interfaces;

namespace soccer_cs.src.modules.transferencia.application.services;

public class TransferenciaService : ITransferenciaService
{
    private readonly ITransferenciaRepository _transferenciaRepository;

    public TransferenciaService(ITransferenciaRepository transferenciaRepository)
        => _transferenciaRepository = transferenciaRepository;

    public async Task RealizarTransferenciaAsync(int id_jugador, int id_equipo_origen, int id_equipo_destino, string tipo_transferencia, float valor_transferencia, DateTime fecha_transferencia)
    {
        _transferenciaRepository.Add(new Transferencia
        {
            IdJugador = id_jugador,
            IdEquipoOrigen = id_equipo_origen,
            IdEquipoDestino = id_equipo_destino,
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
            existingTransferencia.IdEquipoDestino = transferencia.IdEquipoDestino;
            existingTransferencia.IdEquipoOrigen = transferencia.IdEquipoOrigen;
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

    public async Task<IEnumerable<Transferencia?>> VerTodoTransferenciaAsync() 
        => await _transferenciaRepository.GetAllAsync();

    public async Task<List<Transferencia?>> VerHistorialTransferenciaPorJugadorAsync(int id_jugador) 
        => await _transferenciaRepository.ObtenerTransferenciasPorJugador(id_jugador);

    public async Task<List<Transferencia?>> VerHistorialTransferenciaPorEquipoAsync(int id_equipo) 
        => await _transferenciaRepository.ObtenerTransferenciasPorEquipo(id_equipo);

    public async Task<Transferencia?> ObtenerTransferenciaPorIdAsync(int id) 
        => await _transferenciaRepository.GetByIdAsync(id);
}
