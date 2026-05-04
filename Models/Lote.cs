using System.ComponentModel.DataAnnotations;

namespace IS_161_Proyecto_Grupo2.Models
{
    public class Lote
    {
        private DateTime? fechaFin;
        private string codigoLote;
        private DateTime fechaIngreso;
        private int cantidadDisponible;

        public Lote() { }

        public Lote(string codigoLote, DateTime fechaIngreso, int cantidadDisponible)
        {
            this.codigoLote = codigoLote;
            this.fechaIngreso = fechaIngreso;
            this.cantidadDisponible = cantidadDisponible;
        }

        public string CodigoLote
        {
            get { return codigoLote; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    codigoLote = value;
            }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        [Required(ErrorMessage = "La cantidad de productos en un Lote es Obligatoria ")]
        [Range(0.01, 999999, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int CantidadDisponible
        {
            get { return cantidadDisponible; }
            set
            {
                if (value >= 0)
                    cantidadDisponible = value;
            }
        }
        public DateTime? FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        public int DuracionDias()
        {
            if (FechaFin == null)
                return (DateTime.Now - FechaIngreso).Days;

            return (FechaFin.Value - FechaIngreso).Days;
        }
    }
}