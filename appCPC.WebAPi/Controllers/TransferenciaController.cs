using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ModelContext transferencia;

        public TransferenciaController(ModelContext transferencia)
        {
            this.transferencia = transferencia;
        }

        [HttpGet]
        public async Task<List<CpcTransferencium>> Listar()
        {
            return await transferencia.CpcTransferencia.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcTransferencium>> BuscarPorId(decimal Id)
        {
            var resultado = await transferencia.CpcTransferencia.FirstOrDefaultAsync(x => x.TraTransferenciaId == Id);
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
        public async Task<ActionResult<CpcTransferencium>> Guardar(CpcTransferencium t)
        {
            try
            {
                await transferencia.CpcTransferencia.AddAsync(t);
                await transferencia.SaveChangesAsync();
                t.TraTransferenciaId = await transferencia.CpcTransferencia.MaxAsync(x => x.TraTransferenciaId);
                return t;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<CpcTransferencium>> Actualizar(CpcTransferencium t)
        {
            if (t == null || t.TraTransferenciaId == 0)
                return BadRequest("No Contiene Datos");
            CpcTransferencium cat = await transferencia.CpcTransferencia.FirstOrDefaultAsync(x => x.TraTransferenciaId == t.TraTransferenciaId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.TraCodigoAutorizacion = t.TraCodigoAutorizacion;
                cat.TraNombreBeneficiario = t.TraNombreBeneficiario;
                cat.TraBancoEmisor = t.TraBancoEmisor;
                cat.TraBancoReceptor = t.TraBancoReceptor;
                cat.TraFecha = t.TraFecha;
                cat.TraMonto = t.TraMonto;
                cat.TraMoneda = t.TraMoneda;
                transferencia.CpcTransferencia.Update(cat);
                await transferencia.SaveChangesAsync();
                return cat;
    
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcTransferencium cat = await transferencia.CpcTransferencia.FirstOrDefaultAsync(x => x.TraTransferenciaId == Id);
            if(cat == null) 
                return NotFound();
            try
            {
                transferencia.CpcTransferencia.Remove(cat);
                await transferencia.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}