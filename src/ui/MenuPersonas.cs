using soccer_cs;
using System;

namespace persona.ui
{
    public class MenuPersonas
    {
        private readonly IPersonaService _personaService;

        public MenuPersonas(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- GESTIÓN DE PERSONAS -----");
                Console.WriteLine("1. Registrar persona");
                Console.WriteLine("2. Listar personas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarPersona();
                        break;
                    case "2":
                        ListarPersonas();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void RegistrarPersona()
        {
            Console.Clear();
            Console.WriteLine("---- Registrar Persona ----");

            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int.TryParse(Console.ReadLine(), out int edad);

            Console.Write("Género: ");
            var genero = Console.ReadLine();

            var nuevaPersona = new Persona
            {
                Nombre = nombre,
                Edad = edad,
                Genero = genero
            };

            _personaService.CrearPersona(nuevaPersona);

            Console.WriteLine("✅ Persona registrada con éxito.");
        }

        private void ListarPersonas()
        {
            Console.Clear();
            Console.WriteLine("---- Lista de Personas ----");

            var personas = _personaService.ObtenerPersonas();

            foreach (var p in personas)
            {
                Console.WriteLine($"ID: {p.Id} | Nombre: {p.Nombre} | Edad: {p.Edad} | Género: {p.Genero}");
            }
        }
    }
}
