using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaCreditoController : ControllerBase
    {
        private readonly ModelContext credito;

        public NotaCreditoController(ModelContext credito)
        {
            this.credito = credito;
        }

        [HttpGet]
        public async Task<List<CpcNotaCredito>> Listar()
        {
            return await credito.CpcNotaCreditos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcNotaCredito>> BuscarPorId(decimal Id)
        {
            var resultado = await credito.CpcNotaCreditos.FirstOrDefaultAsync(x => x.NocNotaCreditoId == Id);
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
        public async Task<ActionResult<CpcNotaCredito>> Guardar(CpcNotaCredito c)
        {
            try
            {
                await credito.CpcNotaCreditos.AddAsync(c);
                await credito.SaveChangesAsync();
                c.NocNotaCreditoId = await credito.CpcNotaCreditos.MaxAsync(x => x.NocNotaCreditoId);
                return c;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcNotaCredito>> Actualizar(CpcNotaCredito c)
        {
            if(c == null || c.NocNotaCreditoId == 0)
            return BadRequest("No Contiene Datos");
            CpcNotaCredito cat = await credito.CpcNotaCreditos.FirstOrDefaultAsync(x => x.NocNotaCreditoId == c.NocNotaCreditoId);
            if (cat == null)
                return NotFound();
            try
            {
                cat.NocMontoDescuento = c.NocMontoDescuento;
                cat.NocFechaEmision = c.NocFechaEmision;
                cat.NocDescripcion = c.NocDescripcion;
                credito.CpcNotaCreditos.Update(cat);
                await credito.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcNotaCredito cat = await credito.CpcNotaCreditos.FirstOrDefaultAsync(x => x.NocNotaCreditoId == Id);
            if (cat == null) 
                return NotFound();
            try
            {
                credito.CpcNotaCreditos.Remove(cat);
                await credito.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
