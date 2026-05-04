using System.Collections.Generic;
using IS_161_Proyecto_Grupo2.Models;

namespace IS_161_Proyecto_Grupo2.Data
{
    public class BaseDatosMemoria
    {
       
        public static List<Producto> Productos = new List<Producto>();
        public static List<MovimientoInventario> Movimientos = new List<MovimientoInventario>();
        public static List<Factura> Facturas = new List<Factura>();
        public static List<Categoria> Categorias = new List<Categoria>(); // ← 
    }
}