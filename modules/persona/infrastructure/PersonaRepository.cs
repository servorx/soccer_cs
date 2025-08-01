using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using soccer_cs.application;
using soccer_cs.infrastructure.data;

namespace soccer_cs;

public class PersonaRepository : IGenericRepository<Persona>, IPersonaRepository
{
  private readonly ConexionSingleton _conexion;
  public PersonaRepository(string conecctionString)
  {
    _conexion = ConexionSingleton.Instancia(conecctionString);
  }
  public void Crear(Persona persona)
  {
    // Implementación para crear una persona en la base de datos
    var connection = _conexion.ObtenerConexion();
    // creacion del insert que se va a usar en consola para crear una persona
    string query = "INSERT INTO personas (nombre, apellido, edad, nacionalidad, documento_identidad, genero) VALUES (@Nombre, @Apellido, @Edad, @Nacionalidad, @DocumentoIdentidad, @Genero)";
    // colocar los parametros en el comando
    using var command = new MySqlCommand(query, connection);
    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
    command.Parameters.AddWithValue("@Apellido", persona.Apellido);
    command.Parameters.AddWithValue("@Edad", persona.Edad);
    command.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);
    command.Parameters.AddWithValue("@DocumentoIdentidad", persona.DocumentoIdentidad);
    command.Parameters.AddWithValue("@Genero", persona.Genero);
    // ejecutar el comando
    command.ExecuteNonQuery();
  }
  public void Actualizar(Persona persona)
  {
    // aqui tambien
    throw new NotImplementedException();
  }
  public void Eliminar(int id)
  {
    // Implementación para eliminar una persona por ID
    throw new NotImplementedException();
  }
  public List<Persona> ObtenerTodasLasPersonas()
  {
    // Implementación para obtener todas las personas de la base de datos
    throw new NotImplementedException();
  }
}
