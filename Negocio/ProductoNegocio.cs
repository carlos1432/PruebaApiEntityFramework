using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio : IProductoNegocio
    {
        private readonly DBContext _db;

        public ProductoNegocio(DBContext db)
        {
            _db = db;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _db.Productos.FindAsync(id);
        }

        public async Task<List<Producto>> GetProductos()
        {
            Console.WriteLine(_db.Database.GetConnectionString());
            return await _db.Productos.ToListAsync();
        }
    }

}
