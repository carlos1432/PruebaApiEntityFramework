using Azure;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace PruebaApiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoNegocio _productoNegocio;

        public ProductoController(IProductoNegocio productoNegocio)
        {
            _productoNegocio = productoNegocio;                                                                                                                                     
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            try
            {
                var productos = await _productoNegocio.GetProductos();
                return Ok(productos); // ✅ devuelve los productos al cliente
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetProductoById(int id)
        {
            try
            {
                var producto = await _productoNegocio.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound(); 
                }
                return Ok(producto); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
