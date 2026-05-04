namespace IS_161_Proyecto_Grupo2.Models
{
    public class MovimientoInventario
    {
        private DateTime fechaMovimiento;
        private EnumTipoMovimiento tipoMovimiento;
        private int productoId;
        private string codigoLote;
        private int cantidad;

        public MovimientoInventario() { }

        public MovimientoInventario(
            DateTime fechaMovimiento,
            EnumTipoMovimiento tipoMovimiento,
            int productoId,
            string codigoLote,
            int cantidad)
        {
            this.fechaMovimiento = fechaMovimiento;
            this.tipoMovimiento = tipoMovimiento;
            this.productoId = productoId;
            this.codigoLote = codigoLote;
            this.cantidad = cantidad;
        }

        public DateTime FechaMovimiento
        {
            get { return fechaMovimiento; }
            set { fechaMovimiento = value; }
        }

        public EnumTipoMovimiento TipoMovimiento
        {
            get { return tipoMovimiento; }
            set { tipoMovimiento = value; }
        }

        public int ProductoId
        {
            get { return productoId; }
            set { productoId = value; }
        }

        public string CodigoLote
        {
            get { return codigoLote; }
            set { codigoLote = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}