using System;
using System.Collections.Generic;
namespace Clinica
{
    public abstract class ConsultaMedica
    {
        public int NumeroConsultorio { get; set; }
        public DateTime FechaYHora { get; set; }
        public string NombreMedico { get; set; }
        public int CantidadNumeros { get; set; }

        public ConsultaMedica(int numeroConsultorio, DateTime fechaYHora, string nombreMedico, int cantidadNumeros)
        {
            NumeroConsultorio = numeroConsultorio;
            FechaYHora = fechaYHora;
            NombreMedico = nombreMedico;
            CantidadNumeros = cantidadNumeros;
        }

        public abstract override string ToString();
    }
}
