using IS_161_Proyecto_Grupo2.Data;
using IS_161_Proyecto_Grupo2.Models;

namespace IS_161_Proyecto_Grupo2.Services
{
    public class ServicioVentas
    {
        private ServicioInventario servicioInventario = new ServicioInventario();

        public bool RegistrarVenta(Factura factura)
        {
            foreach (var detalle in factura.Detalles)
            {
                bool exito = servicioInventario.RegistrarSalida(
                    detalle.ProductoId,
                    detalle.Cantidad
                );

                if (!exito)
                    return false;
            }

            BaseDatosMemoria.Facturas.Add(factura);
            return true;
        }
    }
}