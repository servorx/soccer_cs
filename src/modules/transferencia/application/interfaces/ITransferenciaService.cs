using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.domain.models;

namespace soccer_cs.src.modules.transferencia.application.interfaces;

public interface ITransferenciaService
{
  Task RealizarTransferenciaAsync(int id_jugador, int id_equipo_origen, int id_equipo_destino, string tipo_transferencia, float valor_transferencia, DateTime fecha_transferencia);
  Task ActualizarTransferenciaAsync(int id, Transferencia transferencia);
  Task EliminarTransferenciaAsync(int id);
  Task<IEnumerable<Transferencia?>> VerTodoTransferenciaAsync();
  Task<List<Transferencia?>> VerHistorialTransferenciaPorJugadorAsync(int id_jugador);
  Task<List<Transferencia?>> VerHistorialTransferenciaPorEquipoAsync(int id_equipo);
  Task<Transferencia?> ObtenerTransferenciaPorIdAsync(int id);
}
