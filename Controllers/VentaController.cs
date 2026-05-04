using IS_161_Proyecto_Grupo2.Data;
using IS_161_Proyecto_Grupo2.Models;
using IS_161_Proyecto_Grupo2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Controllers
{
    public class VentaController : Controller
    {
        private ServicioVentas servicioVentas = new ServicioVentas();

        public IActionResult Create()
        {
            ViewBag.Productos = BaseDatosMemoria.Productos;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Factura factura)
        {
            if (factura.Detalles == null || factura.Detalles.Count == 0)
            {
                TempData["Error"] = "Debe agregar al menos un producto a la venta.";
                return RedirectToAction("Create");
            }

            factura.IdFactura = BaseDatosMemoria.Facturas.Any()
                ? BaseDatosMemoria.Facturas.Max(f => f.IdFactura) + 1
                : 1;

            foreach (var detalle in factura.Detalles)
            {
                var producto = BaseDatosMemoria.Productos
                    .FirstOrDefault(p => p.IdProducto == detalle.ProductoId);

                if (producto == null)
                {
                    TempData["Error"] = "Producto no encontrado.";
                    return RedirectToAction("Create");
                }

                detalle.PrecioUnitario = producto.PrecioVenta ?? 0;
            }

            bool ventaExitosa = servicioVentas.RegistrarVenta(factura);

            if (!ventaExitosa)
            {
                TempData["Error"] = "No hay suficiente stock disponible.";
                return RedirectToAction("Create");
            }

            TempData["Exito"] = "Venta realizada correctamente.";

            return RedirectToAction("Create");
        }
    }
}