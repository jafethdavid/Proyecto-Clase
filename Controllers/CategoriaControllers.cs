using IS_161_Proyecto_Grupo2.Data;
using IS_161_Proyecto_Grupo2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            var categorias = BaseDatosMemoria.Categorias;
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.IdCategoria = BaseDatosMemoria.Categorias.Any()
                    ? BaseDatosMemoria.Categorias.Max(c => c.IdCategoria) + 1
                    : 1;

                BaseDatosMemoria.Categorias.Add(categoria);
                TempData["Success"] = "Categoría creada correctamente.";
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public IActionResult Edit(int id)
        {
            var categoria = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.IdCategoria == id);
            if (categoria == null) return RedirectToAction("Index");
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var catExistente = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.IdCategoria == categoria.IdCategoria);
                if (catExistente != null)
                {
                    catExistente.Nombre = categoria.Nombre;
                    catExistente.IdSubcategoriaPadre = categoria.IdSubcategoriaPadre;
                }
                TempData["Success"] = "Categoría actualizada correctamente.";
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View(categoria);
        }

        public IActionResult Delete(int id)
        {
            var categoria = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.IdCategoria == id);
            if (categoria != null)
            {
                BaseDatosMemoria.Categorias.Remove(categoria);
                TempData["Success"] = "Categoría eliminada correctamente.";
            }
            return RedirectToAction("Index");
        }
    }
}
