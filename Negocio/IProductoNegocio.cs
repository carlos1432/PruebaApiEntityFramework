using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface IProductoNegocio
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProductoById(int id);
        Task<string> CreateProducto(ProductoDTO producto);
    }
}
