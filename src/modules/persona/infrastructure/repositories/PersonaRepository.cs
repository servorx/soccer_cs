using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using soccer_cs.application;
using soccer_cs.infrastructure;

namespace soccer_cs;
public class PersonaRepository : IPersonaRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public PersonaRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(Persona cuerpoMedico) => _context.Personas.Add(cuerpoMedico);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
