using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Models
{
    public class Producto : IValidatableObject
    {
        private int idProducto;
        private string nombreProducto;
        private decimal? precioCosto;
        private decimal? precioVenta;
        private string categoria;
        private List<Lote> lotes;

        public Producto()
        {
            lotes = new List<Lote>();
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        [Required(ErrorMessage = "El precio de costo es obligatorio")]
        [Range(0.01, 999999, ErrorMessage = "El precio de costo debe ser mayor a 0")]
        public decimal? PrecioCosto
        {
            get { return precioCosto; }
            set { precioCosto = value; }
        }

        [Required(ErrorMessage = "El precio de venta es obligatorio")]
        [Range(0.01, 999999, ErrorMessage = "El precio de venta debe ser mayor a 0")]
        public decimal? PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        public List<Lote> Lotes
        {
            get { return lotes; }
            set { lotes = value; }
        }

        public int StockTotal()
        {
            return lotes.Sum(l => l.CantidadDisponible);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PrecioCosto.HasValue && PrecioVenta.HasValue)
            {
                if (PrecioCosto.Value > PrecioVenta.Value)
                {
                    yield return new ValidationResult(
                        "El precio de costo no puede ser mayor que el precio de venta.",
                        new[] { nameof(PrecioCosto), nameof(PrecioVenta) }
                    );
                }
            }
        }
    }
}