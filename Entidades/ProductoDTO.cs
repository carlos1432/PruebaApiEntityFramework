using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoDTO
    {
        public string NombreProducto { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int CantidadExistencia { get; set; }
    }
}
