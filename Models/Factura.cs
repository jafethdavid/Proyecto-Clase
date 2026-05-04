namespace IS_161_Proyecto_Grupo2.Models
{
    public class Factura
    {
        private int idFactura;
        private DateTime fecha;
        private List<DetalleFactura> detalles;

        public Factura()
        {
            fecha = DateTime.Now;
            detalles = new List<DetalleFactura>();
        }

        public Factura(int idFactura, DateTime fecha)
        {
            this.idFactura = idFactura;
            this.fecha = fecha;
            detalles = new List<DetalleFactura>();
        }

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public List<DetalleFactura> Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }

        public decimal Subtotal() => detalles.Sum(d => d.Subtotal);
        public decimal IVA() => Subtotal() * 0.15m;
        public decimal Total() => Subtotal() + IVA();
    }
}
