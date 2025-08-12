using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs;

namespace soccer_cs.application;
// este archivo como tal es la puerta de salida del dominio persona hacia el exterior, es decir, es la interfaz que se usa para interactuar con el dominio persona
// se usa para declarar metodos que se van a usar en PersonaRepository.cs y PersonaService.cs
public interface IPersonaRepository
{
  void Add(Persona entity);
  Task SaveAsync();
}
