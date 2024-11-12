using System;
using System.Collections.Generic;

namespace MantenimientosdePacientes
{
    public class Paciente
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public override string ToString()
        {
            return $"Cedula: {Cedula}, Nombre: {NombreCompleto}, Fecha de Nacimiento: {FechaNacimiento.ToShortDateString()}";
        }
    }

    class Program
    {
        private static List<Paciente> pacientes = new List<Paciente>();

        static void Main()
        {
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Mantenimiento de Pacientes ---");
                Console.WriteLine("1. Agregar Paciente");
                Console.WriteLine("2. Buscar Paciente");
                Console.WriteLine("3. Editar Paciente");
                Console.WriteLine("4. Eliminar Paciente");
                Console.WriteLine("5. Listar Pacientes");
                Console.WriteLine("6. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: AgregarPaciente(); break;
                    case 2: BuscarPaciente(); break;
                    case 3: EditarPaciente(); break;
                    case 4: EliminarPaciente(); break;
                    case 5: ListarPacientes(); break;
                    case 6: Console.WriteLine("Saliendo del sistema..."); break;
                    default: Console.WriteLine("Opción no válida"); break;
                }
            } while (opcion != 6);
        }

        static void AgregarPaciente()
        {
            Console.WriteLine("\n--- Agregar Paciente ---");
            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();
            Console.Write("Nombre Completo: ");
            string nombreCompleto = Console.ReadLine();
            Console.Write("Fecha de Nacimiento (YYYY-MM-DD): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Paciente paciente = new Paciente { Cedula = cedula, NombreCompleto = nombreCompleto, FechaNacimiento = fechaNacimiento };
            pacientes.Add(paciente);

            Console.WriteLine("Paciente agregado con éxito.");
            Console.WriteLine("Información del paciente:");
            Console.WriteLine(paciente.ToString()); // Mostrar la información del paciente usando ToString
        }

        static void BuscarPaciente()
        {
            Console.WriteLine("\n--- Buscar Paciente ---");
            Console.Write("Ingrese la Cedula: ");
            string cedula = Console.ReadLine();

            Paciente paciente = pacientes.Find(p => p.Cedula == cedula);
            if (paciente != null)
            {
                Console.WriteLine("Paciente encontrado:");
                Console.WriteLine(paciente);
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }

        static void EditarPaciente() { /* Código de edición */ }
        static void EliminarPaciente() { /* Código de eliminación */ }
        static void ListarPacientes() { /* Código de listado */ }
    }
}
