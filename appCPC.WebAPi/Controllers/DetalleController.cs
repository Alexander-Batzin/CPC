using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private readonly ModelContext detalle;

        public DetalleController(ModelContext detalle)
        {
            this.detalle = detalle;

        }

        [HttpGet]
        public async Task<List<CpcDetalle>> Listar()
        {
            return await detalle.CpcDetalles.ToListAsync();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcDetalle>> BuscarPorId(decimal Id)
        {
            var resultado = await detalle.CpcDetalles.FirstOrDefaultAsync(x => x.DteDetalleId == Id);
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
        public async Task<ActionResult<CpcDetalle>> Guardar(CpcDetalle d)
        {
            try
            {
                await detalle.CpcDetalles.AddAsync(d);
                await detalle.SaveChangesAsync();

                return d;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcDetalle>> Actualizar(CpcDetalle d)
        {
            if(d == null || d.DteDetalleId == 0)
                return BadRequest("No Contiene Datos");
            CpcDetalle cat = await detalle.CpcDetalles.FirstOrDefaultAsync(x => x.DteDetalleId == d.DteDetalleId);
            if (cat == null)
                return NotFound();
            try
            {
                cat.CliClienteId = d.CliClienteId;
                cat.FacFacturaId = d.FacFacturaId;
                cat.OrdOrdenCompraId = d.OrdOrdenCompraId;
                cat.PagRegistroPagoId = d.PagRegistroPagoId;
                cat.EmpEmpleadoId = d.EmpEmpleadoId;
                cat.DteMontoInicial = d.DteMontoInicial;
                cat.DteMontoPagado = d.DteMontoPagado;
                cat.DteAbono = d.DteAbono;
                cat.DteSaldoAnterior = d.DteSaldoAnterior;
                cat.DteSaldoActual = d.DteSaldoActual;
                cat.DteMora = d.DteMora;
                cat.DteTotalPago = d.DteTotalPago;
                cat.DteEstadoPago = d.DteEstadoPago;
                cat.DteInteres = d.DteInteres;
                cat.DteFechaRegistro = d.DteFechaRegistro;
                cat.DteComentario = d.DteComentario;
                detalle.CpcDetalles.Update(cat);
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
            CpcDetalle cat = await detalle.CpcDetalles.FirstOrDefaultAsync(x => x.DteDetalleId == Id);
            if (cat == null)
                return NotFound();
            try
            {
                detalle.CpcDetalles.Remove(cat);
                await detalle.SaveChangesAsync();

                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            


    }
}
