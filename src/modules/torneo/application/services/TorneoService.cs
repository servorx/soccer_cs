using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Globalization;
using soccer_cs.infrastructure.utils;
using soccer.modules.equipo.domain;

namespace soccer_cs.services;

public class TorneoService
{
  // esto se tiene que crear para que puedan funcionar las validaciones en el TorneoService. reandonly indica que la asignación al campo solo puede producirse como parte de la declaración o en un constructor de la misma clase.
  private readonly Validaciones validate_input = new();
  public void CrearTorneo()
  {
    Console.Clear();
    System.Console.WriteLine("=== CREAR NUEVO TORNEO ===");

    System.Console.Write("Ingrese el nombre del torneo: ");
    string nombre = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("ingrese el tipo de torneo (torneo o liga): ");
    string tipo_torneo = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("ingrese la ubicacion de donde se va a realizar el torneo (pais): ");
    string ubicacion = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("ingrese la fecha del comienzo del torneo (DD-MM-YYYY): ");
    string fecha_creacion = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("ingrese la duracion del torneo en numero de dias: ");
    int duracion_dias = validate_input.ValidarEntero(Console.ReadLine());

    System.Console.Write($"ingrese la cantidad del premio en {NumberFormatInfo.CurrentInfo.CurrencySymbol}: ");
    float premio_ = validate_input.ValidarDecimal(Console.ReadLine());
    string premio = premio_.ToString("C3", CultureInfo.CurrentCulture).ToLower();


    // TODO arreglar toda esta logica erronea de querer ingresar los equipos participantes al equipo (opcional) y si el usuario los ingresa, tienen que haber sido creados previamente y si no es asi, crearlos manualmente y crear un metodo que cree el equipo y lo asigne de manera inmediada a la lista de Torneos
    System.Console.Write("Ingrese los equipos participantes (separados por comas): ");
    string? equipos_participantes = validate_input.ValidarTexto(Console.ReadLine()).ToLower();
    List<Equipo?> equipos = equipos_participantes.Split(',')
    .Select(nombre =>
    {
      string nombreLimpio = nombre.Trim();
      Equipo? existente = AppData.Equipos.FirstOrDefault(e => e.Nombre != null && e.Nombre.Equals(nombreLimpio, StringComparison.OrdinalIgnoreCase));

      if (existente != null)
      {
        return existente; // ya existe en el sistema
      }
      else
      {
        System.Console.Write($"\nEl equipo \"{nombreLimpio}\" no existe. ¿Deseas crear este equipo con solo el nombre? (s/n): ");
        bool crearEquipo = validate_input.ValidarBoleano(Console.ReadLine());

        if (crearEquipo)
        {
          var nuevoEquipo = new Equipo(
            id_util.GenerarID(),
            nombreLimpio,
            null, null, null, null, null, null, null, null, null, null);
          AppData.Equipos.Add(nuevoEquipo);
          return nuevoEquipo;
        }
        else
        {
          return null; // el usuario no quiso crearlo
        }
      }
    })
    .Where(e => e != null) // filtra los equipos nulos
    .ToList();


    // mostrar los datos ingresados y validar su confirmacion 
    System.Console.WriteLine($"\ningresaste los datos:");
    // crear la instancia
    Torneo nuevo_torneo = new Torneo(id_nuevo, nombre, tipo_torneo, ubicacion, fecha_creacion, duracion_dias, premio, equipos);
    nuevo_torneo.MostrarResumen();
    System.Console.Write("deseas confirmar los cambios? (s/n): ");
    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

    // agregar los datos a la lista Torneo
    if (validate_data)
    {
      AppData.Torneos.Add(nuevo_torneo);
      Console.Clear();
      System.Console.WriteLine("torneo creado exitosamente :)");
      System.Console.WriteLine("presione una tecla para continuar...");
      Console.ReadLine();
    }
    else
    {
      Console.Clear();
      System.Console.WriteLine("no confirmó los cambios, presione una tecla para volver al menu");
      Console.ReadLine();
    }
  }
  public void BuscarTorneo()
  {
    Console.Clear();
    System.Console.Write("ingrese el ID o el nombre del torneo que desea buscar: ");
    string? busqueda = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    // se usa var porque puede ser un id(int) o nombre(string). Tambien se usa lambda para cortar expresiones.
    // FirstOrDefault recorre la coleccionm aplica una funcion de true o false y retorna el primer elemento que cumpla con la condicion(id o nombre equivalente al input del usuario), retorna null si no hay ninguna equivalencia. 
    // t es una simplicidad de torneo (parametro de tipo torneo), donde busca el nombre o el id equivalente a busqueda. 
    // la funcion lambda en realidad sirve como un argumento al metodo FirstOrDefault/
    // el el .Constains hace que si el usuario escriba "cham" y hay una liga llamada "champions" el programa lo reconoce
    var torneo_busqueda = AppData.Torneos.FirstOrDefault(t =>
    t.Nombre!.Contains(busqueda) || t.Id.ToString() == busqueda
    );

    if (torneo_busqueda != null)
    {
      System.Console.Write($"\nTorneo encontrado:\nID: {torneo_busqueda.Id}\nNombre: {torneo_busqueda.Nombre}\nFecha: {torneo_busqueda.FechaCreacion}\nDuracion: {torneo_busqueda.DuracionDias} días\nPremio: {torneo_busqueda.Premio}\nEquipos participantes: {torneo_busqueda.EquiposParticipantes.Count}\n");
      Console.ReadLine();
    }
    else
    {
      System.Console.Write("Torneo no encontrado...");
      Console.ReadLine();
    }
  }
  public void EliminarTorneo()
  {
    System.Console.Write("Ingrese el ID o nombre del torneo a eliminar: ");
    string busqueda = validate_input.ValidarTexto(Console.ReadLine());

    var torneo_eliminar = AppData.Torneos.FirstOrDefault(t => t.Id.ToString() == busqueda || t.Nombre!.Contains(busqueda));

    if (torneo_eliminar != null)
    {
      AppData.Torneos.Remove(torneo_eliminar);
      Console.Clear();
      System.Console.WriteLine("Torneo eliminado exitosamente :)");
      System.Console.WriteLine("presione una tecla para continuar...");
      Console.ReadLine();
    }
    else
    {
      System.Console.WriteLine("Torneo no encontrado :(\n");
      Console.ReadLine();
    }
  }
  public void ActualizarTorneo()
  {

    System.Console.WriteLine("Ingrese el ID o nombre del torneo a actualizar: ");
    string busqueda = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    var torneo_act = AppData.Torneos.FirstOrDefault(t =>
    t.Nombre!.Contains(busqueda) || t.Id.ToString() == busqueda
    );

    if (torneo_act == null)
    {
      System.Console.WriteLine("Torneo no encontrado. :(");
      Console.ReadLine();
      return;
    }
    else
    {
      Console.Clear();
      System.Console.WriteLine("=== ACTUALIZANDO TORNEO ===");

      // crear copias temporales de los datos para actualizarlos unicamente cuando el usuario desee confirmar los cambios
      string nuevoNombre = torneo_act.Nombre!;
      string nuevaFecha = torneo_act.FechaCreacion!;
      int nuevaDuracion = torneo_act.DuracionDias;
      string nuevoPremio = torneo_act.Premio!;

      System.Console.Write("nuevo nombre para el torneo (dejar vacio para mantener el actual): ");
      string? nombre_nuevo = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(nombre_nuevo))
      {
        nuevoNombre = validate_input.ValidarTexto(nombre_nuevo).ToLower();
      }

      System.Console.Write("Nueva fecha de creacion del torneo (dejar vacío para mantener la actual): ");
      string? fecha_creacion_nueva = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(fecha_creacion_nueva))
      {
        nuevaFecha = validate_input.ValidarTexto(fecha_creacion_nueva).ToLower();
      }

      System.Console.Write("Nueva duracion en dias (dejar vacío para mantener la duracion actual): ");
      string? duracion_nueva = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(duracion_nueva))
      {
        nuevaDuracion = validate_input.ValidarEntero(duracion_nueva);
      }

      System.Console.Write($"Nuevo premio en {NumberFormatInfo.CurrentInfo.CurrencySymbol} (dejar vacio para mantener el actual): ");
      string? input_premio = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(input_premio))
      {
        float nuevo_premio_ = validate_input.ValidarDecimal(input_premio);
        nuevoPremio = nuevo_premio_.ToString("C3", CultureInfo.CurrentCulture).ToLower();
      }
      // mostrar los datos ingresados y validar su confirmacion de actualizacion
      System.Console.Write($"\ningresaste los datos:");
      System.Console.Write($"ID: {torneo_act.Id}\nNombre: {nuevoNombre}\nFecha de creacion: {nuevaFecha}\nDuracion (dias): {nuevaDuracion}\nPremio: {nuevoPremio}");
      System.Console.Write("deseas confirmar los cambios? (s/n): ");
      bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

      // actualiza los datos a la lista Torneo en caso de que sean asi
      if (validate_data)
      {
        torneo_act.Nombre = nuevoNombre;
        torneo_act.FechaCreacion = nuevaFecha;
        torneo_act.DuracionDias = nuevaDuracion;
        torneo_act.Premio = nuevoPremio;
        Console.Clear();
        System.Console.WriteLine("torneo actualizado exitosamente :)");
        System.Console.WriteLine("presione una tecla para continuar...");
        Console.ReadLine();
      }
      else
      {
        Console.Clear();
        System.Console.Write("no confirmó los cambios, presione una tecla para volver al menu");
        Console.ReadLine();
      }
    }
  }
  public void AsignarEquipoATorneo(Equipo equipo, Torneo torneo)
  {
    if (!torneo.EquiposParticipantes.Contains(equipo))
    {
      torneo.EquiposParticipantes.Add(equipo);
    }
  }
}

