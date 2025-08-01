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
    // Implementación para actualizar una persona en la base de datos 
    var connection = _conexion.ObtenerConexion();
    // creacion del update que se va a usar en consola para actualizar los atributos de una persona
    string query = """
    UPDATE personas SET nombre = @Nombre, 
    apellido = @Apellido, 
    edad = @Edad, 
    nacionalidad = @Nacionalidad, 
    documento_identidad = @DocumentoIdentidad, 
    genero = @Genero 
    WHERE id = @Id
    """;
    // colocar los parametros en el comando para la update
    using var command = new MySqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", persona.Id);
    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
    command.Parameters.AddWithValue("@Apellido", persona.Apellido);
    command.Parameters.AddWithValue("@Edad", persona.Edad);
    command.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad); 
    command.Parameters.AddWithValue("@DocumentoIdentidad", persona.DocumentoIdentidad);
    command.Parameters.AddWithValue("@Genero", persona.Genero);
    // ejecutar el comando
    command.ExecuteNonQuery();
  }
  public void Eliminar(int id)
  {
    // Implementación para eliminar una persona en la base de datos 
    var connection = _conexion.ObtenerConexion();
    // creacion del delete que se va a usar en consola para actualizar los atributos de una persona
    string query = "DELETE FROM personas WHERE id = @Id";
    // implementacion del comando para eliminar a la persona seleccionada 
    using var command = new MySqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id); 
    // ejecutar el comando
    command.ExecuteNonQuery();
  }
  public List<Persona> ObtenerTodasLasPersonas()
  {
    // Implementación para actualizar una persona en la base de datos 
    var connection = _conexion.ObtenerConexion();
    // creacion del update que se va a usar en consola para actualizar los atributos de una persona
    string query = "SELECT * FROM personas";
    // colocar los parametros en el comando para la seleccion de todo las personas
    using var command = new MySqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", 0);
    // ejecutar el comando
    command.ExecuteNonQuery();
  }
}
