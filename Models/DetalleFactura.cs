namespace IS_161_Proyecto_Grupo2.Models
{
    public class DetalleFactura
    {
        private int productoId;
        private int cantidad;
        private decimal precioUnitario;

        public DetalleFactura() { }

        public DetalleFactura(int productoId, int cantidad, decimal precioUnitario)
        {
            this.productoId = productoId;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }

        public int ProductoId
        {
            get { return productoId; }
            set { productoId = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public decimal Subtotal
        {
            get { return cantidad * precioUnitario; }
        }
    }
}