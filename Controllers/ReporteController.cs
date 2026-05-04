using IS_161_Proyecto_Grupo2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Productos()
        {
            var productos = BaseDatosMemoria.Productos;
            return View(productos);
        }

        public IActionResult Lotes()
        {
            var productos = BaseDatosMemoria.Productos;
            return View(productos);
        }

        public IActionResult Movimientos()
        {
            var movimientos = BaseDatosMemoria.Movimientos;
            return View(movimientos);
        }

        public IActionResult Ventas()
        {
            var facturas = BaseDatosMemoria.Facturas;
            return View(facturas);
        }
        public IActionResult Detalle(int id)
        {
            var factura = BaseDatosMemoria.Facturas
                .FirstOrDefault(f => f.IdFactura == id);

            if (factura == null)
                return RedirectToAction("Ventas");

            return View(factura);
        }
    }
}