using IS_161_Proyecto_Grupo2.Models;
using IS_161_Proyecto_Grupo2.Services;
using IS_161_Proyecto_Grupo2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Controllers
{
    public class LoteController : Controller
    {
        private ServicioInventario servicio = new ServicioInventario();

        public ActionResult Create(int idProducto)
        {
            var producto = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto == null)
                return RedirectToAction("Index", "Producto");

            string prefijo = producto.NombreProducto.Substring(0, 3).ToUpper();

            int contador = producto.Lotes.Count + 1;

            string codigo = prefijo + "-" + contador.ToString("D3");

            ViewBag.IdProducto = idProducto;
            ViewBag.CodigoLote = codigo;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int idProducto, Lote lote)
        {
            var producto = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == idProducto);

            string prefijo = producto.NombreProducto.Substring(0, 3).ToUpper();

            int contador = producto.Lotes.Count + 1;

            lote.CodigoLote = prefijo + "-" + contador.ToString("D3");

            lote.FechaIngreso = DateTime.Now;

            servicio.RegistrarEntrada(idProducto, lote);

            return RedirectToAction("Index", "Producto");
        }
    }
}