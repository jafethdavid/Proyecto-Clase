using IS_161_Proyecto_Grupo2.Data;
using IS_161_Proyecto_Grupo2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            return View(BaseDatosMemoria.Productos);
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = BaseDatosMemoria.Categorias;
                return View(producto);
            }

            producto.IdProducto = BaseDatosMemoria.Productos.Any()
                ? BaseDatosMemoria.Productos.Max(p => p.IdProducto) + 1
                : 1;

            BaseDatosMemoria.Productos.Add(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var producto = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == id);

            if (producto == null)
                return RedirectToAction("Index");

            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = BaseDatosMemoria.Categorias;
                return View(producto);
            }

            var prod = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == producto.IdProducto);

            if (prod != null)
            {
                prod.NombreProducto = producto.NombreProducto;
                prod.Categoria = producto.Categoria;
                prod.PrecioCosto = producto.PrecioCosto;
                prod.PrecioVenta = producto.PrecioVenta;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var producto = BaseDatosMemoria.Productos
                .FirstOrDefault(p => p.IdProducto == id);

            if (producto != null)
            {
                BaseDatosMemoria.Productos.Remove(producto);
            }

            return RedirectToAction("Index");
        }
    }
}