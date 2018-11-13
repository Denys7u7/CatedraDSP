using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spares_Web.Models
{
    public class ProductoEN
    {
        public int id { get; set; }
        public string Producto { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
    }
}