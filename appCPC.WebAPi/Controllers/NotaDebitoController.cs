using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaDebitoController : ControllerBase
    {
        private readonly ModelContext debito;

        public NotaDebitoController(ModelContext debito)
        {
            this.debito = debito;
        }

        [HttpGet]
        public async Task<List<CpcNotaDebito>> Listar()
        {
            return await debito.CpcNotaDebitos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcNotaDebito>> BuscarPorId(decimal Id)
        {
            var resultado = await debito.CpcNotaDebitos.FirstOrDefaultAsync(x => x.NotNotaDebitoId == Id);
            if (resultado != null)
            {
                return resultado;
            }else
            {
                return NotFound();
            }
        }

        [HttpPost] 
        public async Task<ActionResult<CpcNotaDebito>> Guardar(CpcNotaDebito d)
        {
            try
            {
                await debito.CpcNotaDebitos.AddAsync(d);
                await debito.SaveChangesAsync();
                d.NotNotaDebitoId = await debito.CpcNotaDebitos.MaxAsync(x => x.NotNotaDebitoId);
                return d;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcNotaDebito>> Actualizar(CpcNotaDebito d)
        {
            if (d == null || d.NotNotaDebitoId == 0)
                return BadRequest("No Contiene Datos");
            CpcNotaDebito cat = await debito.CpcNotaDebitos.FirstOrDefaultAsync(x => x.NotNotaDebitoId == d.NotNotaDebitoId);
            if(cat == null)
                return NotFound();
            try
            {
                cat.NotMontoAdicional = d.NotMontoAdicional;
                cat.NotFechaEmision = d.NotFechaEmision;
                cat.NotDescripcion = d.NotDescripcion;
                debito.CpcNotaDebitos.Update(cat);
                await debito.SaveChangesAsync();

                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcNotaDebito cat = await debito.CpcNotaDebitos.FirstOrDefaultAsync(x => x.NotNotaDebitoId == Id);
            if(cat == null) 
                return NotFound();
            try
            {
                debito.CpcNotaDebitos.Remove(cat);
                await debito.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
