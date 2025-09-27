using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    interface IAccesoDatosProductos
    {
        //Task<IEnumerable<Producto>> GetProductos();
        //Task<IEnumerable<Producto>> GetProductoById(int id);
        Task InsertarProducto(ProductoDTO producto);
    }
}
