using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeController : ControllerBase
    {
        private readonly ModelContext cheque;

        public ChequeController(ModelContext cheque)
        {
            this.cheque = cheque;
        }

        [HttpGet]
        public async Task<List<CpcCheque>> Listar()
        {
            return await cheque.CpcCheques.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcCheque>> BuscarPorId(decimal Id)
        {
            var resultado = await cheque.CpcCheques.FirstOrDefaultAsync(x => x.CheChequeId == Id);
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
        public async Task<ActionResult<CpcCheque>> Guardar(CpcCheque c)
        {
            try
            {
                await cheque.CpcCheques.AddAsync(c);
                await cheque.SaveChangesAsync();
                c.CheChequeId = await cheque.CpcCheques.MaxAsync(x => x.CheChequeId);
                return c;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcCheque>> Actualizar(CpcCheque c)
        {
            if (c == null || c.CheChequeId == 0)
                return BadRequest("No Contiene Datos");
            CpcCheque cat = await cheque.CpcCheques.FirstOrDefaultAsync(x => x.CheChequeId == c.CheChequeId);
            if (cat == null)
                return NotFound();
            try
            {
                cat.CheNumeroCheque = c.CheNumeroCheque;
                cat.CheMonto = c.CheMonto;
                cat.CheFechaEmision = c.CheFechaEmision;
                cat.CheNombreBeneficiario = c.CheNombreBeneficiario;
                cat.CheBancoEmisor = c.CheBancoEmisor;
                cat.CheNumeroDeCuenta = c.CheNumeroDeCuenta;
                cat.CheEstado = c.CheEstado;
                cheque.CpcCheques.Update(cat);
                await cheque.SaveChangesAsync();
                return cat;
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar (decimal Id)
        {
            CpcCheque cat = await cheque.CpcCheques.FirstOrDefaultAsync(x => x.CheChequeId ==  Id);
            if (cat == null) 
                return NotFound();
            try
            {
                cheque.CpcCheques.Remove(cat);
                await cheque.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
