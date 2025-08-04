using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.models;

namespace soccer_cs;
public interface ITorneoService
{
  void RegistrarTorneo(Torneo torneo);
  Torneo? BuscarTorneo(int id);
  List<Torneo> ListarTorneos();
  void EditarTorneos(Torneo torneo);
  void EliminarTorneo(int id);
}
