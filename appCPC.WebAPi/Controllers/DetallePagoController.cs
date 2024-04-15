using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePagoController : ControllerBase
    {
        private readonly ModelContext detalle;

        public DetallePagoController(ModelContext detalle)
        {
            this.detalle = detalle;
        }

        [HttpGet]
        public async Task<List<CpcDetallePago>> Listar()
        {
            return await detalle.CpcDetallePagos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcDetallePago>> BuscarPorId(decimal Id)
        {
            var resultado = await detalle.CpcDetallePagos.FirstOrDefaultAsync(x => x.DtpDetallePagoId == Id);
            if (resultado != null)
            {
                return resultado;

            }else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CpcDetallePago>> Guardar(CpcDetallePago dp)
        {
            try
            {
                await detalle.CpcDetallePagos.AddAsync(dp);
                await detalle.SaveChangesAsync();
                dp.DtpDetallePagoId = await detalle.CpcDetallePagos.MaxAsync(x => x.DtpDetallePagoId);
                return dp;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcDetallePago>> Actualizar(CpcDetallePago dp)
        {
            if (dp == null || dp.DtpDetallePagoId == 0)
                return BadRequest("No Contiene Datos");
            CpcDetallePago cat = await detalle.CpcDetallePagos.FirstOrDefaultAsync(x => x.DtpDetallePagoId == dp.DtpDetallePagoId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.PagRegistroPagoId = dp.PagRegistroPagoId;
                cat.DtpFecha = dp.DtpFecha;
                cat.DtpMoneda = dp.DtpMoneda;
                detalle.CpcDetallePagos.Update(cat);
                await detalle.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcDetallePago cat = await detalle.CpcDetallePagos.FirstOrDefaultAsync(x => x.DtpDetallePagoId == Id);
            if(cat == null)
                return NotFound();
            try
            {
                detalle.CpcDetallePagos.Remove(cat);
                await detalle.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
