using System;
using System.Collections.Generic;



namespace Clinica
{
    public class ConsultaComun : ConsultaMedica
    {
        public bool Enfermeria { get; set; }

        public ConsultaComun(int numeroConsultorio, DateTime fechaYHora, string nombreMedico, int cantidadNumeros, bool enfermeria)
            : base(numeroConsultorio, fechaYHora, nombreMedico, cantidadNumeros)
        {
            Enfermeria = enfermeria;
        }

        public override string ToString()
        {
            return $"Consulta Común - Consultorio: {NumeroConsultorio}, Médico: {NombreMedico}, Enfermería: {(Enfermeria ? "Sí" : "No")}";
        }
    }
}

