using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly ModelContext orden;
        public OrdenCompraController(ModelContext orden)
        {
            this.orden = orden;
        }

        [HttpGet]
        public async Task<List<CpcOrdenCompra>> Listar()
        {
            return await orden.CpcOrdenCompras.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcOrdenCompra>> ListarPorId(decimal Id)
        {
            var resultado = await orden.CpcOrdenCompras.FirstOrDefaultAsync(x => x.OrdOrdenCompraId == Id);
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
        public async Task<ActionResult<CpcOrdenCompra>> Guardar(CpcOrdenCompra o)
        {
            try
            {
                await orden.CpcOrdenCompras.AddAsync(o);
                await orden.SaveChangesAsync();
                o.OrdOrdenCompraId = await orden.CpcOrdenCompras.MaxAsync(x => x.OrdOrdenCompraId);
                return o;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcOrdenCompra>> Actualizar(CpcOrdenCompra o)
        {
            if (o == null || o.CliClienteId == 0)
                return BadRequest("No contiene Datos");
            CpcOrdenCompra cat = await orden.CpcOrdenCompras.FirstOrDefaultAsync(x => x.OrdOrdenCompraId == o.OrdOrdenCompraId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.CliClienteId = o.CliClienteId;
                cat.ProProductoId = o.ProProductoId;
                cat.OrdFechaOrden = o.OrdFechaOrden;
                cat.OrdCantidad = o.OrdCantidad;
                cat.OrdProductoDetallado = o.OrdProductoDetallado;
                cat.OrdMontoTotal = o.OrdMontoTotal;
                cat.OrdIva  = o.OrdIva;
                cat.OrdCuentaMayor  = o.OrdCuentaMayor;
                cat.OrdPlazoDePago = o.OrdPlazoDePago;
                orden.CpcOrdenCompras.Update(cat);
                await orden.SaveChangesAsync();
                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcOrdenCompra cat = await orden.CpcOrdenCompras.FirstOrDefaultAsync(x => x.OrdOrdenCompraId == Id);
            if(cat == null)
                return NotFound();
            try
            {
                orden.CpcOrdenCompras.Remove(cat);
                await orden.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
