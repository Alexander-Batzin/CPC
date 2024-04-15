using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPagoController : ControllerBase
    {
        private readonly ModelContext registro;

        public RegistroPagoController(ModelContext registro)
        {
            this.registro = registro;
        }

        [HttpGet]
        public async Task<List<CpcRegistroPago>> Listar()
        {
            return await registro.CpcRegistroPagos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcRegistroPago>> BuscarPorId(decimal Id)
        {
            var resultado = await registro.CpcRegistroPagos.FirstOrDefaultAsync(x => x.PagRegistroPagoId == Id);
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
        public async Task<ActionResult<CpcRegistroPago>> Guardar(CpcRegistroPago rp)
        {
            try
            {
                await registro.CpcRegistroPagos.AddAsync(rp);
                await registro.SaveChangesAsync();
                rp.PagRegistroPagoId = await registro.CpcRegistroPagos.MaxAsync(x => x.PagRegistroPagoId);
                return rp;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcRegistroPago>> Actualizar(CpcRegistroPago rp)
        {
            if (rp == null || rp.PagRegistroPagoId == 0)
                return BadRequest("No Contiene Datos");
            CpcRegistroPago cat = await registro.CpcRegistroPagos.FirstOrDefaultAsync(x => x.PagRegistroPagoId == rp.PagRegistroPagoId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.TdpTipoDePagoId = rp.TdpTipoDePagoId;
                cat.MovMovimientoId = rp.MovMovimientoId;
                cat.FacFacturaId = rp.FacFacturaId;
                cat.PagFechaPago = rp.PagFechaPago;
                cat.PagMontoPagado = rp.PagMontoPagado;
                registro.CpcRegistroPagos.Update(cat);
                await registro.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcRegistroPago cat = await registro.CpcRegistroPagos.FirstOrDefaultAsync(x => x.PagRegistroPagoId == Id);
            if(cat == null)
                return NotFound();
            try
            {
                registro.CpcRegistroPagos.Remove(cat);
                await registro.SaveChangesAsync();

                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
