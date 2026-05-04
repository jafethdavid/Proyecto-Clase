using IS_161_Proyecto_Grupo2.Data;
using IS_161_Proyecto_Grupo2.Models;

namespace IS_161_Proyecto_Grupo2.Services
{
    public class ServicioInventario
    {
        public void RegistrarEntrada(int productoId, Lote lote)
        {
            var producto = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == productoId);

            if (producto != null)
            {
                producto.Lotes.Add(lote);

                BaseDatosMemoria.Movimientos.Add(
                    new MovimientoInventario(
                        DateTime.Now,
                        EnumTipoMovimiento.Entrada,
                        productoId,
                        lote.CodigoLote,
                        lote.CantidadDisponible
                    )
                );
            }
        }

        public bool RegistrarSalida(int productoId, int cantidad)
        {
            var producto = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == productoId);

            if (producto == null)
                return false;

            int? totalDisponible = producto.Lotes
                .Sum(l => l.CantidadDisponible);

            if (totalDisponible < cantidad)
                return false;

            var lotesOrdenados = producto.Lotes
                .Where(l => l.CantidadDisponible > 0)
                .OrderBy(l => l.FechaIngreso)
                .ToList();

            foreach (var lote in lotesOrdenados)
            {
                if (cantidad <= 0)
                    break;

                int descontar = Math.Min(cantidad, lote.CantidadDisponible);

                lote.CantidadDisponible -= descontar;
                cantidad -= descontar;

                //  Si el lote se agoto se guarda la fecha
                if (lote.CantidadDisponible == 0)
                {
                    lote.FechaFin = DateTime.Now;
                }

                BaseDatosMemoria.Movimientos.Add(
                    new MovimientoInventario(
                        DateTime.Now,
                        EnumTipoMovimiento.Salida,
                        productoId,
                        lote.CodigoLote,
                        descontar
                    )
                );
            }

            return true;
        }
    }
}
