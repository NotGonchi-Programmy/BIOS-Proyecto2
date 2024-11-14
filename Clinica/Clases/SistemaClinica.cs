using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica
{
    public class SistemaClinica
    {
        public List<Paciente> Pacientes { get; private set; } = new List<Paciente>();
        public List<ConsultaMedica> Consultas { get; private set; } = new List<ConsultaMedica>();
        public List<Solicitud> Solicitudes { get; private set; } = new List<Solicitud>();

        public bool AgregarPaciente(Paciente paciente)
        {
            if (Pacientes.Any(p => p.Cedula == paciente.Cedula))
            {
                Console.WriteLine("Error: El paciente ya existe.");
                return false;
            }
            Pacientes.Add(paciente);
            return true;
        }

        public bool AgregarConsulta(ConsultaMedica consulta)
        {
            if (Consultas.Any(c => c.NumeroConsultorio == consulta.NumeroConsultorio &&
                                    Math.Abs((c.FechaYHora - consulta.FechaYHora).TotalHours) < 2))
            {
                Console.WriteLine("Error: Hay un conflicto de horario en el mismo consultorio.");
                return false;
            }
            Consultas.Add(consulta);
            return true;
        }

        public bool AgregarSolicitud(Paciente paciente, ConsultaMedica consulta)
        {
            if (!Pacientes.Contains(paciente) || !Consultas.Contains(consulta))
            {
                Console.WriteLine("Error: Paciente o consulta no encontrados.");
                return false;
            }
            var solicitud = new Solicitud(paciente, consulta, DateTime.Now);
            Solicitudes.Add(solicitud);
            Console.WriteLine("Solicitud agregada exitosamente.");
            return true;
        }

        public void MarcarAsistencia(Solicitud solicitud)
        {
            solicitud.Asistio = true;
            Console.WriteLine("Asistencia marcada con éxito.");
        }
    }
}
