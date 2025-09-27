using Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosProductos : IAccesoDatosProductos
    {
        private readonly string _con;

        // ✅ Consulta SQL como propiedad de clase
        private readonly string _insertProducto = @"
            INSERT INTO Producto (nombreProducto, descripcion, precio, fechaCreacion, cantidadExistencia)
            VALUES (@nombreProducto, @descripcion, @precio, @fechaCreacion, @cantidadExistencia);
        ";

        public AccesoDatosProductos(IConfiguration configuration)
        {
            _con = configuration.GetConnectionString("TECHNOVAConnection");
        }

        public async Task InsertarProducto(ProductoDTO producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_con))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(_insertProducto, connection))
                    {
                        command.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                        command.Parameters.AddWithValue("@descripcion", (object?)producto.Descripcion ?? DBNull.Value);
                        command.Parameters.AddWithValue("@precio", producto.Precio);
                        command.Parameters.AddWithValue("@fechaCreacion", producto.FechaCreacion);
                        command.Parameters.AddWithValue("@cantidadExistencia", producto.CantidadExistencia);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes loguear o lanzar la excepción según la lógica de tu negocio
                throw new Exception("Error al insertar el producto en la base de datos: " + ex.Message, ex);
            }
        }
    }
}
