using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using soccer_cs.application;
using soccer_cs.infrastructure;

namespace soccer_cs;
// // este archivo es el adaptador de la infraestructura, implementa lo declarado en IPersonaRepository, usando AppDbContext, IDbFactory, o MySqlDbFactory para acceder a la base de datos.using persona.domain;

public class PersonaRepository : IPersonaRepository
{
  private readonly AppDbContext _dbContext;

  public PersonaRepository(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public void CrearPersona(Persona persona)
  {
    _dbContext.Set<Persona>().Add(persona);
    _dbContext.SaveChanges();
  }
  public Persona? ObtenerPorId(int id)
  {
    return _dbContext.Set<Persona>().Find(id);
  }
  public List<Persona> ObtenerTodas()
  {
      return _dbContext.Set<Persona>().ToList();
  }
  public void ActualizarPersona(Persona persona)
  {
      throw new NotImplementedException();
  }

  public void EliminarPersona(Persona persona)
  {
      throw new NotImplementedException();
  }
}





// public class PersonaRepository : IGenericRepository<Persona>, IPersonaRepository
// {
//   private readonly IDbFactory _dbFactory;

//   public PersonaRepository(IDbFactory dbFactory)
//   {
//     _dbFactory = dbFactory;
//   }

//   public async Task<List<Persona>> ObtenerTodasAsync()
//   {
//     using var context = _dbFactory.CrearPersonaRepository();
//     var personas = new List<Persona>();

//     using var command = context.CreateCommand();
//     command.CommandText = "SELECT * FROM personas";

//     using var reader = await command.ExecuteReaderAsync();
//     while (await reader.ReadAsync())
//     {
//       personas.Add(new Persona
//       {
//         Id = reader.GetInt32("id"),
//         Edad = reader.GetInt32("edad"),
//         Nacionalidad = reader.GetString("nacionalidad"),
//         DocumentoIdentidad = reader.GetInt32("documento_identidad"),
//         Genero = reader.GetString("genero")
//       });
//     }

//     return personas;
//   }

//   // Implementa los demás métodos igual (Crear, ObtenerPorId, Actualizar, Eliminar)
//   public void Crear(Persona persona)
//   {
//     // Implementación para crear una persona en la base de datos
//     var connection = _conexion.ObtenerConexion();
//     // creacion del insert que se va a usar en consola para crear una persona
//     string query = "INSERT INTO personas (nombre, apellido, edad, nacionalidad, documento_identidad, genero) VALUES (@Nombre, @Apellido, @Edad, @Nacionalidad, @DocumentoIdentidad, @Genero)";
//     // colocar los parametros en el comando
//     using var command = new MySqlCommand(query, connection);
//     command.Parameters.AddWithValue("@Nombre", persona.Nombre);
//     command.Parameters.AddWithValue("@Apellido", persona.Apellido);
//     command.Parameters.AddWithValue("@Edad", persona.Edad);
//     command.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);
//     command.Parameters.AddWithValue("@DocumentoIdentidad", persona.DocumentoIdentidad);
//     command.Parameters.AddWithValue("@Genero", persona.Genero);
//     // ejecutar el comando
//     command.ExecuteNonQuery();
//   }
//   public void Actualizar(Persona persona)
//   {
//     // Implementación para actualizar una persona en la base de datos 
//     var connection = _conexion.ObtenerConexion();
//     // creacion del update que se va a usar en consola para actualizar los atributos de una persona
//     string query = """
//     UPDATE personas SET nombre = @Nombre, 
//     apellido = @Apellido, 
//     edad = @Edad, 
//     nacionalidad = @Nacionalidad, 
//     documento_identidad = @DocumentoIdentidad, 
//     genero = @Genero 
//     WHERE id = @Id
//     """;
//     // colocar los parametros en el comando para la update
//     using var command = new MySqlCommand(query, connection);
//     command.Parameters.AddWithValue("@Id", persona.Id);
//     command.Parameters.AddWithValue("@Nombre", persona.Nombre);
//     command.Parameters.AddWithValue("@Apellido", persona.Apellido);
//     command.Parameters.AddWithValue("@Edad", persona.Edad);
//     command.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);
//     command.Parameters.AddWithValue("@DocumentoIdentidad", persona.DocumentoIdentidad);
//     command.Parameters.AddWithValue("@Genero", persona.Genero);
//     // ejecutar el comando
//     command.ExecuteNonQuery();
//   }
//   public void Eliminar(int id)
//   {
//     // Implementación para eliminar una persona en la base de datos 
//     var connection = _conexion.ObtenerConexion();
//     // creacion del delete que se va a usar en consola para actualizar los atributos de una persona
//     string query = "DELETE FROM personas WHERE id = @Id";
//     // implementacion del comando para eliminar a la persona seleccionada 
//     using var command = new MySqlCommand(query, connection);
//     command.Parameters.AddWithValue("@Id", id);
//     // ejecutar el comando
//     command.ExecuteNonQuery();
//   }
//   public List<Persona> ObtenerTodasLasPersonas()
//   {
//     // implementacion de un metodo que obtiene las personas de la base de datos
//     var personas = new List<Persona>();
//     // genera una conexion para obtener las personas de la base de datos
//     var connection = _conexion.ObtenerConexion();
//     string query = "SELECT * FROM personas";
//     // ejecutar el comando de arriba
//     using var command = new MySqlCommand(query, connection);
//     // ejecutar el comando y leer los datos con el metodo executeReader
//     using var reader = command.ExecuteReader();
//     // leer los datos y agregarlos a la lista de personas 
//     while (reader.Read())
//     {
//       // agregar cada persona a la lista de personas
//       personas.Add(new Persona
//       {
//         Id = reader.GetInt32("id"),
//         Nombre = reader.GetString("nombre"),
//         Apellido = reader.GetString("apellido"),
//         Edad = reader.GetInt32("edad"),
//         Nacionalidad = reader.GetString("nacionalidad"),
//         DocumentoIdentidad = reader.GetInt32("documento_identidad"),
//         Genero = reader.GetString("genero")
//       });
//     }
//     // devuelve la lista de personas obtenidas de la consulta
//     return personas;
//   }
// }
