using System;
using System.Collections.Generic;



namespace Clinica
{
    public class ConsultaEspecialista : ConsultaMedica
    {
        public string Especialidad { get; set; }

        public ConsultaEspecialista(int numeroConsultorio, DateTime fechaYHora, string nombreMedico, int cantidadNumeros, string especialidad)
            : base(numeroConsultorio, fechaYHora, nombreMedico, cantidadNumeros)
        {
            Especialidad = especialidad;
        }

        public override string ToString()
        {
            return $"Consulta Especialista - Consultorio: {NumeroConsultorio}, Médico: {NombreMedico}, Especialidad: {Especialidad}";
        }
    }
}
