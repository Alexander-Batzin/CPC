using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ModelContext producto;
        public ProductoController(ModelContext producto)
        {
            this.producto = producto;
        }

        [HttpGet]
        public async Task<List<CpcProducto>> Listar()
        {
            return await producto.CpcProductos.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcProducto>> BuscarPorId(decimal Id)
        {
            var resultado = await producto.CpcProductos.FirstOrDefaultAsync(x => x.ProProductoId == Id);
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CpcProducto>> Guardar(CpcProducto p)
        {
            try
            {
                await producto.CpcProductos.AddAsync(p);
                await producto.SaveChangesAsync();
                p.ProProductoId = await producto.CpcProductos.MaxAsync(x => x.ProProductoId);

                return p;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcProducto>> Actualizar(CpcProducto p)
        {
            if (p == null || p.ProProductoId == 0)
                return BadRequest("No Contiene Datos");
            CpcProducto cat = await producto.CpcProductos.FirstOrDefaultAsync(x => x.ProProductoId == p.ProProductoId);
            if (cat == null)
                return NotFound();
            try
            {
                cat.ProNombreProducto = p.ProNombreProducto;
                cat.ProDescripcion = p.ProDescripcion;
                cat.ProStock = p.ProStock;
                cat.ProEstadoProducto = p.ProEstadoProducto;
                cat.ProPrecioSinIva = p.ProPrecioSinIva;
                producto.CpcProductos.Update(cat);
                await producto.SaveChangesAsync();
                return cat;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcProducto cat = await producto.CpcProductos.FirstOrDefaultAsync(x => x.ProProductoId == Id);
            if (cat == null)
                return NotFound();
            try
            {
                producto.CpcProductos.Remove(cat);
                await producto.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
