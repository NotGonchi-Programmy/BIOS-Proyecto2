using System;
using System.Collections.Generic;


namespace Clinica
{
    public class Paciente
    {
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Paciente(string cedula, string nombreCompleto, DateTime fechaNacimiento)
        {
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
        }

        public override string ToString()
        {
            return $"Paciente {Cedula} - {NombreCompleto} - Nacimiento: {FechaNacimiento.ToShortDateString()}";
        }
    }
}
