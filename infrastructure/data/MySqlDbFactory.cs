using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using soccer_cs.infrastructure.data;
using soccer_cs.models;

namespace soccer_cs.infrastructure.data;
public class MySqlDbFactory : IDbFactory
{
  private readonly string _connectionString;

  public MySqlDbFactory(string connectionString)
  {
    _connectionString = connectionString;
  }
  // todas estas funciones crean una instancia de cada repositorio y le pasan la cadena de conexión
  // para que cada repositorio pueda conectarse a la base de datos
  // y realizar las operaciones necesarias
  public ICuerpoMedicoRepository CrearCuerpoMedicoRepository()
  {
    return new CuerpoMedicoRepository(_connectionString);
  }

  public ICuerpoTecnicoRepository CrearCuerpoTecnicoRepository()
  {
    return new CuerpoTecnicoRepository(_connectionString);
  }

  public IEquipoRepository CrearEquipoRepository()
  {
    return new EquipoRepository(_connectionString);
  }

  public IEstadisticaEquipoRepository CrearEstadisticaEquipoRepository()
  {
    return new EstadisticaEquipoRepository(_connectionString);
  }

  public IEstadisticaJugadorRepository CrearEstadisticaJugadorRepository()
  {
    return new EstadisticaJugadorRepository(_connectionString);
  }

  public IJugadorRepository CrearJugadorRepository()
  {
    return new JugadorRepository(_connectionString);
  }

  public IPersonaRepository CrearPersonaRepository()
  {
    return new PersonaRepository(_connectionString);
  }

  public ITorneoRepository CrearTorneoRepository()
  {
    return new TorneoRepository(_connectionString);
  }

  public ITransferenciaRepository CrearTransferenciaRepository()
  {
    return new TransferenciaRepository(_connectionString);
  }
}