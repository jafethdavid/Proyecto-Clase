using IS_161_Proyecto_Grupo2.Data;
using IS_161_Proyecto_Grupo2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IS_161_Proyecto_Grupo2.Controllers
{
    public class SubcategoriaController : Controller
    {
        public IActionResult Create(int? idCategoria)
        {
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            ViewBag.IdCategoriaSeleccionada = idCategoria;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                // asignar id 
                subcategoria.IdSubcategoria = (BaseDatosMemoria.Categorias.SelectMany(c => c.Subcategorias).Count()) + 1;
                // buscar categoria y añadir
                var cat = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.IdCategoria == subcategoria.CategoriaId);
                if (cat != null)
                {
                    cat.Subcategorias.Add(subcategoria);
                }
                return RedirectToAction("Index", "Categoria");
            }
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View(subcategoria);
        }

        public IActionResult Edit(int id)
        {
            var sub = BaseDatosMemoria.Categorias.SelectMany(c => c.Subcategorias).FirstOrDefault(s => s.IdSubcategoria == id);
            if (sub == null) return RedirectToAction("Index", "Categoria");
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View(sub);
        }

        [HttpPost]
        public IActionResult Edit(Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                var existing = BaseDatosMemoria.Categorias.SelectMany(c => c.Subcategorias).FirstOrDefault(s => s.IdSubcategoria == subcategoria.IdSubcategoria);
                if (existing != null)
                {
                    
                    if (existing.CategoriaId != subcategoria.CategoriaId)
                    {
                        var oldCat = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.IdCategoria == existing.CategoriaId);
                        var newCat = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.IdCategoria == subcategoria.CategoriaId);
                        if (oldCat != null)
                            oldCat.Subcategorias.RemoveAll(s => s.IdSubcategoria == existing.IdSubcategoria);
                        if (newCat != null)
                            newCat.Subcategorias.Add(subcategoria);
                    }
                    else
                    {
                        existing.Nombre = subcategoria.Nombre;
                    }
                }
                return RedirectToAction("Index", "Categoria");
            }
            ViewBag.Categorias = BaseDatosMemoria.Categorias;
            return View(subcategoria);
        }

        public IActionResult Delete(int id)
        {
            var cat = BaseDatosMemoria.Categorias.FirstOrDefault(c => c.Subcategorias.Any(s => s.IdSubcategoria == id));
                if (cat != null)
                {
                    cat.Subcategorias.RemoveAll(s => s.IdSubcategoria == id);
                    return RedirectToAction("Index", "Categoria");
                }
            return RedirectToAction("Index", "Categoria");
        }
    }
}
