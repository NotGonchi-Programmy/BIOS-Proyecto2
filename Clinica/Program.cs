using System;
using System.Linq;

namespace Clinica
{
    class Program
    {
        private static SistemaClinica sistema = new SistemaClinica();

        static void Main(string[] args)
        {
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Agregar Paciente");
                Console.WriteLine("2. Editar Paciente");
                Console.WriteLine("3. Agregar Consulta Común");
                Console.WriteLine("4. Agregar Consulta Especialista");
                Console.WriteLine("5. Agregar Solicitud");
                Console.WriteLine("6. Marcar Asistencia a Solicitud");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarPaciente();
                        break;
                    case 2:
                        EditarPaciente();
                        break;
                    case 3:
                        AgregarConsultaComun();
                        break;
                    case 4:
                        AgregarConsultaEspecialista();
                        break;
                    case 5:
                        AgregarSolicitud();
                        break;
                    case 6:
                        MarcarAsistencia();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 7);
        }

        private static void EditarPaciente()
        {
            Console.Write("Ingrese la cédula del paciente a editar: ");
            string cedula = Console.ReadLine();

            // Busca el paciente en el sistema
            Paciente paciente = sistema.Pacientes.FirstOrDefault(p => p.Cedula == cedula);

            if (paciente != null)
            {
                // Llama al menú de edición para este paciente
                EditarPaciente(paciente);
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }

        static void AgregarPaciente() // Agregar paciente 
        {
            Console.WriteLine("\n--- Agregar Paciente ---");
            Console.Write("Ingrese la Cédula del Paciente: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el Nombre Completo del Paciente: ");
            string nombreCompleto = Console.ReadLine();

            Console.Write("Ingrese la Fecha de Nacimiento (YYYY-MM-DD): ");
            DateTime fechaNacimiento;
            if (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
            {
                Console.WriteLine("Fecha de nacimiento no válida.");
                return;
            }

            Paciente nuevoPaciente = new Paciente(cedula, nombreCompleto, fechaNacimiento);
            if (sistema.AgregarPaciente(nuevoPaciente))
            {
                Console.WriteLine("Paciente agregado con éxito.");
            }
        }

        static void EditarPaciente(Paciente paciente) //Nos permite editar el paciente ojo es medio delicado por que es un menu a parte.
        {
            int opcionEditar;

            do
            {
                Console.WriteLine("---EDITAR PACIENTE---");
                Console.WriteLine("1. Editar nombre");
                Console.WriteLine("2. Editar fecha de nacimiento");
                Console.WriteLine("3. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcionEditar))
                {
                    Console.WriteLine("###Opción no válida, intente de nuevo###");
                    continue;
                }

                switch (opcionEditar)
                {
                    case 1:
                        Console.Write("Ingrese el nuevo nombre del paciente: ");
                        paciente.NombreCompleto = Console.ReadLine();
                        Console.WriteLine("Nombre actualizado correctamente.");
                        break;

                    case 2:
                        Console.Write("Ingrese la nueva fecha de nacimiento del paciente (formato: dd/MM/yyyy): ");
                        DateTime nuevaFechaNacimiento;
                        if (DateTime.TryParse(Console.ReadLine(), out nuevaFechaNacimiento))
                        {
                            paciente.FechaNacimiento = nuevaFechaNacimiento;
                            Console.WriteLine("Fecha de nacimiento actualizada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Fecha no válida.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo!");
                        break;
                }
            } while (opcionEditar != 3);
        }

        static void AgregarConsultaComun() // Consulta comun
        {
            Console.WriteLine("\n--- Agregar Consulta Común ---");
            Console.Write("Número de Consultorio: ");
            int numeroConsultorio = int.Parse(Console.ReadLine());

            Console.Write("Fecha y Hora (YYYY-MM-DD HH:MM): ");
            DateTime fechaYHora;
            if (!DateTime.TryParse(Console.ReadLine(), out fechaYHora))
            {
                Console.WriteLine("Fecha y hora no válidas.");
                return;
            }

            Console.Write("Nombre del Médico: ");
            string nombreMedico = Console.ReadLine();

            Console.Write("Cantidad de Números: ");
            int cantidadNumeros = int.Parse(Console.ReadLine());

            Console.Write("¿Requiere Enfermería? (si/no): ");
            bool enfermeria = Console.ReadLine().ToLower() == "si";

            ConsultaComun consulta = new ConsultaComun(numeroConsultorio, fechaYHora, nombreMedico, cantidadNumeros, enfermeria);
            if (sistema.AgregarConsulta(consulta))
            {
                Console.WriteLine("Consulta común agregada con éxito.");
            }
        }

        static void AgregarConsultaEspecialista() //Consulta especialista 
        {
            Console.WriteLine("\n--- Agregar Consulta Especialista ---");
            Console.Write("Número de Consultorio: ");
            int numeroConsultorio = int.Parse(Console.ReadLine());

            Console.Write("Fecha y Hora (YYYY-MM-DD HH:MM): ");
            DateTime fechaYHora;
            if (!DateTime.TryParse(Console.ReadLine(), out fechaYHora))
            {
                Console.WriteLine("Fecha y hora no válidas.");
                return;
            }

            Console.Write("Nombre del Médico: ");
            string nombreMedico = Console.ReadLine();

            Console.Write("Cantidad de Números: ");
            int cantidadNumeros = int.Parse(Console.ReadLine());

            Console.Write("Especialidad del Médico: ");
            string especialidad = Console.ReadLine();

            ConsultaEspecialista consulta = new ConsultaEspecialista(numeroConsultorio, fechaYHora, nombreMedico, cantidadNumeros, especialidad);
            if (sistema.AgregarConsulta(consulta))
            {
                Console.WriteLine("Consulta especialista agregada con éxito.");
            }
        }

        static void AgregarSolicitud() // Agregar solicitud 
        {
            Console.WriteLine("\n--- Agregar Solicitud ---");
            Console.Write("Ingrese la Cédula del Paciente: ");
            string cedula = Console.ReadLine();
            Paciente paciente = sistema.Pacientes.FirstOrDefault(p => p.Cedula == cedula);

            if (paciente == null)
            {
                Console.WriteLine("Paciente no encontrado. Operación cancelada.");
                return;
            }

            Console.Write("Ingrese el Número de Consultorio de la Consulta: ");
            int numeroConsultorio = int.Parse(Console.ReadLine());
            ConsultaMedica consulta = sistema.Consultas.FirstOrDefault(c => c.NumeroConsultorio == numeroConsultorio);

            if (consulta == null)
            {
                Console.WriteLine("Consulta no encontrada. Operación cancelada.");
                return;
            }

            if (sistema.AgregarSolicitud(paciente, consulta))
            {
                Console.WriteLine("Solicitud de número agregada con éxito.");
            }
        }

        static void MarcarAsistencia() //Para marcar asistencias
        {
            Console.WriteLine("\n--- Marcar Asistencia a Solicitud ---");
            Console.Write("Ingrese el ID de la Solicitud: ");
            int idSolicitud;
            if (!int.TryParse(Console.ReadLine(), out idSolicitud))
            {
                Console.WriteLine("ID de solicitud no válido.");
                return;
            }

            Solicitud solicitud = sistema.Solicitudes.FirstOrDefault(s => s.ID == idSolicitud);
            if (solicitud == null)
            {
                Console.WriteLine("Solicitud no encontrada.");
                return;
            }

            sistema.MarcarAsistencia(solicitud);
        }
    }
}
