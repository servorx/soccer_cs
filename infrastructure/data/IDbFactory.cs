using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs.infrastructure.data;
public interface IDbFactory
{
  ICuerpoMedicoRepository CrearCuerpoMedicoRepository();
  ICuerpoTecnicoRepository CrearCuerpoTecnicoRepository();
  IEquipoRepository CrearEquipoRepository();
  IEstadisticaEquipoRepository CrearEstadisticaEquipoRepository();
  IEstadisticaJugadorRepository CrearEstadisticaJugadorRepository();
  IJugadorRepository CrearJugadorRepository();
  IPersonaRepository CrearPersonaRepository();
  ITorneoRepository CrearTorneoRepository();
  ITransferenciaRepository CrearTransferenciaRepository();
}
