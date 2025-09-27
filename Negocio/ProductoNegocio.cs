using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Negocio
{
    public class ProductoNegocio : IProductoNegocio
    {
        private readonly DBContext _db;
        private readonly AccesoDatosProductos _accesoDatos;

        public ProductoNegocio(DBContext db, IConfiguration configuration)
        {
            _db = db;
            _accesoDatos = new AccesoDatosProductos(configuration);
        }

        public async Task<string> CreateProducto(ProductoDTO producto)
        {
            try
            {
                await _accesoDatos.InsertarProducto(producto);
                return "Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                // Opcional: puedes loguear el error aquí si tienes un sistema de logs
                return $"Error al insertar el producto: {ex.Message}";
            }
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
