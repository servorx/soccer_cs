using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1;
using soccer_cs.infrastructure.utils;
using System.Runtime.CompilerServices;
using soccer_cs.services;
using soccer.modules.equipo.domain;
using soccer_cs.models;


namespace soccer_cs;

public class EquipoService : IEquipoService
{
  private readonly IEquipoRepository _equipoRepo;
  private readonly ICuerpoTecnicoRepository _cuerpoTecnicoRepo;
  private readonly ICuerpoMedicoRepository _cuerpoMedicoRepo;
  private readonly ITorneoRepository _torneoRepo;

  private readonly ICuerpoMedicoService _cuerpoMedicoService;
  private readonly ICuerpoTecnicoService _cuerpoTecnicoService;

  public EquipoService(
    IEquipoRepository equipoRepo,
    ICuerpoTecnicoRepository cuerpoTecnicoRepo,
    ICuerpoMedicoRepository cuerpoMedicoRepo,
    ITorneoRepository torneoRepo,

    ICuerpoMedicoService cuerpoMedicoService,
    ICuerpoTecnicoService cuerpoTecnicoService)
  {
    _equipoRepo = equipoRepo;
    _cuerpoMedicoService = cuerpoMedicoService;
    _cuerpoTecnicoRepo = cuerpoTecnicoRepo;
    _cuerpoMedicoRepo = cuerpoMedicoRepo;
    _torneoRepo = torneoRepo;

    _cuerpoMedicoService = cuerpoMedicoService;
    _cuerpoTecnicoService = cuerpoTecnicoService;
  }

  public async Task AgregarEquipoAsync(Equipo equipo)
  {
    _equipoRepo.Add(equipo);
    await _equipoRepo.SaveAsync();
  }

  public async Task ActualizarEquipoAsync(int id, Equipo equipo)
  {
    var existente = await _equipoRepo.GetByIdAsync(id);
    if (existente == null) throw new Exception("Equipo no encontrado");

    existente.Nombre = equipo.Nombre;
    existente.Ciudad = equipo.Ciudad;
    existente.Pais = equipo.Pais;
    existente.Estadio = equipo.Estadio;
    existente.TipoEquipo = equipo.TipoEquipo;
    existente.CantidadTitulos = equipo.CantidadTitulos;

    _equipoRepo.Update(existente);
    await _equipoRepo.SaveAsync();
  }

  public async Task EliminarEquipoAsync(int id)
  {
    var equipo = await _equipoRepo.GetByIdAsync(id);
    if (equipo == null) throw new Exception("Equipo no encontrado");

    _equipoRepo.Remove(equipo);
    await _equipoRepo.SaveAsync();
  }

  public async Task<IEnumerable<Equipo>> MostrarEquiposAsync() => await _equipoRepo.GetAllAsync();

  public async Task<Equipo?> ObtenerEquipoPorIdAsync(int id) => await _equipoRepo.GetByIdAsync(id);

  public async Task<IEnumerable<Equipo>> ObtenerEquipoPorNombreAsync(string nombre) =>
      (await _equipoRepo.GetAllAsync()).Where(e => e.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));

  public async Task<IEnumerable<Jugador>> ObtenerJugadoresPorEquipoAsync(int idEquipo) =>
      await _equipoRepo.GetJugadoresByEquipoIdAsync(idEquipo);

  public async Task RegistrarCuerpoTecnicoAsync(int idEquipo, IEnumerable<int> idsCuerposTecnicos)
  {
    var equipo = await _equipoRepo.GetByIdAsync(idEquipo);
    if (equipo == null) throw new Exception("Equipo no encontrado");

    var cuerpos = await _cuerpoTecnicoRepo.GetByIdsAsync(idsCuerposTecnicos);
    equipo.CuerpoTecnicos = cuerpos.ToList();

    _equipoRepo.Update(equipo);
    await _equipoRepo.SaveAsync();
  }

  public async Task RegistrarCuerpoMedicoEnEquipoAsync(int idEquipo, int idCuerpoMedico)
  {
    var equipo = await _equipoRepo.GetByIdAsync(idEquipo);
    if (equipo == null)
      throw new Exception("El equipo no existe");

    var cuerpoMedico = await _cuerpoMedicoService.ObtenerCuerpoMedicoPorIdAsync(idCuerpoMedico);
    if (cuerpoMedico == null)
      throw new Exception("El cuerpo médico no existe");

    equipo.CuerpoMedicos ??= new List<CuerpoMedico>();
    equipo.CuerpoMedicos.Add(cuerpoMedico);

    await _equipoRepo.SaveAsync();
  }
  public async Task RegistrarCuerpoTecnicoEnEquipoAsync(int idEquipo, int idCuerpoTecnico)
  {
    var equipo = await _equipoRepo.GetByIdAsync(idEquipo);
    if (equipo == null)
      throw new Exception("El equipo no existe");

    var cuerpoTecnico = await _cuerpoTecnicoService.ObtenerCuerpoTecnicoPorIdAsync(idCuerpoTecnico);
    if (cuerpoTecnico == null)
      throw new Exception("El cuerpo técnico no existe");

    equipo.CuerpoTecnicos ??= new List<CuerpoTecnico>();
    equipo.CuerpoTecnicos.Add(cuerpoTecnico);

    await _equipoRepo.SaveAsync();
  }


  public async Task InscribirEquipoAsync(int idEquipo, int idTorneo)
  {
    var torneo = await _torneoRepo.GetByIdAsync(idTorneo);
    var equipo = await _equipoRepo.GetByIdAsync(idEquipo);
    if (torneo == null || equipo == null) throw new Exception("Torneo o equipo no encontrado");

    torneo.TorneosEquipos.Add(new TorneoEquipo { EquipoId = idEquipo, TorneoId = idTorneo });
    await _torneoRepo.SaveAsync();
  }

  public async Task DesinscribirEquipoAsync(int idEquipo, int idTorneo)
  {
    var torneo = await _torneoRepo.GetByIdAsync(idTorneo);
    if (torneo == null) throw new Exception("Torneo no encontrado");

    var relacion = torneo.TorneosEquipos.FirstOrDefault(te => te.EquipoId == idEquipo);
    if (relacion != null) torneo.TorneosEquipos.Remove(relacion);

    await _torneoRepo.SaveAsync();
  }
  
}
