using System.ComponentModel.DataAnnotations;

namespace IS_161_Proyecto_Grupo2.Models
{
    public class Subcategoria 
    {
        private int idSubcategoria;
        private string nombre;
        private int? categoriaId;

        public Subcategoria() { }

        public Subcategoria(int idSubcategoria, string nombre, int categoriaId)
        {
            this.idSubcategoria = idSubcategoria;
            this.nombre = nombre;
            this.categoriaId = categoriaId;
        }

        [Key]
        public int IdSubcategoria
        {
            get { return idSubcategoria; }
            set { idSubcategoria = value; }
        }

        [Required(ErrorMessage = "El nombre de la subcategoría es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    nombre = value;
            }
        }

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        
        public int? CategoriaId
        {
            get { return categoriaId; }
            set { categoriaId = value; }
        }
    }
}
