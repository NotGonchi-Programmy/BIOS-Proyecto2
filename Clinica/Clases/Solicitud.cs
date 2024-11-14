using System;
using System.Collections.Generic;


namespace Clinica
{
    public class Solicitud
    {
        private static int contador = 1;
        public int ID { get; private set; }
        public Paciente Paciente { get; set; }
        public ConsultaMedica Consulta { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public bool Asistio { get; set; }

        public Solicitud(Paciente paciente, ConsultaMedica consulta, DateTime fechaSolicitud)
        {
            ID = contador++;
            Paciente = paciente;
            Consulta = consulta;
            FechaSolicitud = fechaSolicitud;
            Asistio = false;
        }

        public override string ToString()
        {
            return $"Solicitud ID: {ID}, Paciente: {Paciente.NombreCompleto}, Consulta: {Consulta}, Asistió: {Asistio}";
        }
    }
}
