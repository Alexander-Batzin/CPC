using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController : ControllerBase
    {
        private readonly ModelContext pago;

        public TipoPagoController(ModelContext pago)
        {
            this.pago = pago;
        }

        [HttpGet]
        public async Task<List<CpcTipoDePago>> Listar()
        {
            return await pago.CpcTipoDePagos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcTipoDePago>> BuscarPorId(decimal Id)
        {
            var resultado = await pago.CpcTipoDePagos.FirstOrDefaultAsync(x => x.TdpTipoDePagoId == Id);
            if (resultado != null)
            {
                return resultado;
            }else
            {
                return NotFound();
            }
                
        }

        [HttpPost]
        public async Task<ActionResult<CpcTipoDePago>> Guardar(CpcTipoDePago p)
        {
            try
            {
                await pago.CpcTipoDePagos.AddAsync(p);
                await pago.SaveChangesAsync();
                p.TdpTipoDePagoId = await pago.CpcTipoDePagos.MaxAsync(x => x.TdpTipoDePagoId);

                return p;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcTipoDePago>> Actualizar(CpcTipoDePago p)
        { 
            if(p == null || p.TdpTipoDePagoId == 0)
                return BadRequest("No Contiene Datos");
            CpcTipoDePago cat = await pago.CpcTipoDePagos.FirstOrDefaultAsync(x => x.TdpTipoDePagoId == p.TdpTipoDePagoId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.CheChequeId = p.CheChequeId;
                cat.TraTransferenciaId = p.TraTransferenciaId;
                cat.TdpFechaRegistro = p.TdpFechaRegistro;
                cat.TdpComentario = p.TdpComentario;
                pago.CpcTipoDePagos.Update(cat);
                await pago.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcTipoDePago cat = await pago.CpcTipoDePagos.FirstOrDefaultAsync(x => x.TdpTipoDePagoId == Id);
            if(cat == null) 
                return NotFound();
            try
            {
                pago.CpcTipoDePagos.Remove(cat);
                await pago.SaveChangesAsync();

                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
