using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelacionTotalController : ControllerBase
    {
        private readonly ModelContext cancelacion;

        public CancelacionTotalController(ModelContext cancelacion)
        {
            this.cancelacion = cancelacion;
        }

        [HttpGet]
        public async Task<List<CpcCancelacionTotal>> Listar()
        {
            return await cancelacion.CpcCancelacionTotals.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcCancelacionTotal>> BuscarPorId(decimal Id)
        {
            var resultado = await cancelacion.CpcCancelacionTotals.FirstOrDefaultAsync(x => x.CntCancelacionTotalId == Id);
            if(resultado != null)
            {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CpcCancelacionTotal>> Guardar(CpcCancelacionTotal ct)
        {
            try
            {
                await cancelacion.CpcCancelacionTotals.AddAsync(ct);
                await cancelacion.SaveChangesAsync();
                ct.CntCancelacionTotalId = await cancelacion.CpcCancelacionTotals.MaxAsync(x => x.CntCancelacionTotalId);

                return ct;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcCancelacionTotal>> Actualizar(CpcCancelacionTotal ct)
        {
            if(ct == null || ct.CntCancelacionTotalId == 0)
             return BadRequest("No Contiene Datos");
            CpcCancelacionTotal cat = await cancelacion.CpcCancelacionTotals.FirstOrDefaultAsync(x => x.CntCancelacionTotalId == ct.CntCancelacionTotalId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.CliClienteId = ct.CliClienteId;
                cat.FacFacturaId = ct.FacFacturaId;
                cat.CntFechaCancelacion = ct.CntFechaCancelacion;
                cat.CntDescuento = ct.CntDescuento;
                cat.CntMontoTotalPagado = ct.CntMontoTotalPagado;
                cancelacion.CpcCancelacionTotals.Update(cat);
                await cancelacion.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcCancelacionTotal cat = await cancelacion.CpcCancelacionTotals.FirstOrDefaultAsync(x => x.CntCancelacionTotalId == Id);
            if(cat == null) 
                return NotFound();
            try
            {
                cancelacion.CpcCancelacionTotals.Remove(cat);
                await cancelacion.SaveChangesAsync();

                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
