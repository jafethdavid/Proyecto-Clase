using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IS_161_Proyecto_Grupo2.Models
{
    public class Categoria
    {
        private int idCategoria;
        private string nombre;
        private List<Subcategoria> subcategorias;
        private int? idSubcategoriaPadre; 

        public Categoria()
        {
            subcategorias = new List<Subcategoria>();
        }

        public Categoria(int idCategoria, string nombre)
        {
            this.idCategoria = idCategoria;
            this.nombre = nombre;
            subcategorias = new List<Subcategoria>();
        }

        [Key]
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nombre debe tener entre 2-100 caracteres")]
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    nombre = value;
            }
        }

        public List<Subcategoria> Subcategorias
        {
            get { return subcategorias; }
            set { subcategorias = value; }
        }

        public int? IdSubcategoriaPadre
        {
            get { return idSubcategoriaPadre; }
            set { idSubcategoriaPadre = value; }
        }
    }
}
