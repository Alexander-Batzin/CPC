using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly ModelContext movimiento;

        public MovimientoController(ModelContext movimiento)
        {
            this.movimiento = movimiento;
        }

        [HttpGet]
        public async Task<List<CpcMovimiento>> Listar()
        {
            return await movimiento.CpcMovimientos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcMovimiento>> BuscarPorId(decimal Id)
        {
            var resultado = await movimiento.CpcMovimientos.FirstOrDefaultAsync(x => x.MovMovimientoId == Id);
            if (resultado != null)
            {
                return resultado;
            }else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CpcMovimiento>> Guardar(CpcMovimiento m)
        {
            try
            {
                await movimiento.CpcMovimientos.AddAsync(m);
                await movimiento.SaveChangesAsync();
                m.MovMovimientoId = await movimiento.CpcMovimientos.MaxAsync(x => x.MovMovimientoId);

                return m;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcMovimiento>> Actualizar(CpcMovimiento m)
        {
            if (m == null || m.MovMovimientoId == 0)
                return BadRequest("No Contiene Datos");
            CpcMovimiento cat = await movimiento.CpcMovimientos.FirstOrDefaultAsync(x => x.MovMovimientoId == m.MovMovimientoId);
            if (cat == null)
                return NotFound();
            try
            {
                cat.NotNotaDebito = m.NotNotaDebito;
                cat.NocNotaCredito = m.NocNotaCredito;
                cat.MovFecha = m.MovFecha;
                cat.MovComentario = m.MovComentario;
                movimiento.CpcMovimientos.Update(cat);
                await movimiento.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcMovimiento cat = await movimiento.CpcMovimientos.FirstOrDefaultAsync(x => x.MovMovimientoId == Id);
            if (cat == null) 
                return NotFound();
            try
            {
                movimiento.CpcMovimientos.Remove(cat);
                await movimiento.SaveChangesAsync();

                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
