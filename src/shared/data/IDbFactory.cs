using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.application;

namespace soccer_cs.infrastructure.data;
public interface IDbFactory
{
  ICuerpoMedicoRepository CrearCuerpoMedicoRepository();
  ICuerpoTecnicoRepository CrearCuerpoTecnicoRepository();
  IEquipoRepository CrearEquipoRepository();
  IEquipoCuerpoMedicoRepository CrearEquipoCuerpoMedicoRepository();
  IEquipoCuerpoTecnicoRepository CrearEquipoCuerpoTecnicoRepository();
  IEquipoJugadorRepository CrearEquipoJugadorRepository();
  IEstadisticaEquipoRepository CrearEstadisticaEquipoRepository();
  IEstadisticaJugadorRepository CrearEstadisticaJugadorRepository();
  IJugadorRepository CrearJugadorRepository();
  IPersonaRepository CrearPersonaRepository();
  ITorneoRepository CrearTorneoRepository();
  ITorneoEquipoService CrearTorneoEquipoService();
  ITransferenciaRepository CrearTransferenciaRepository();
}
