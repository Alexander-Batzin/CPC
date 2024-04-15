using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ModelContext factura;
        public FacturaController(ModelContext factura)
        {
            this.factura = factura;
        }

        [HttpGet]
        public async Task<List<CpcFactura>> Listar()
        {
            return await factura.CpcFacturas.ToListAsync();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcFactura>> BuscarPorId(decimal Id)
        {
            var resultado = await factura.CpcFacturas.FirstOrDefaultAsync(x => x.FacFacturaId == Id);
            if(resultado != null) {
                return resultado;
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult<CpcFactura>> Guardar(CpcFactura f)
        {
            try
            {
                await factura.CpcFacturas.AddAsync(f);
                await factura.SaveChangesAsync();
                f.FacFacturaId = await factura.CpcFacturas.MaxAsync(x => x.FacFacturaId);
                return f;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcFactura>> Actualizar(CpcFactura f)
        {
            if(f == null || f.FacFacturaId == 0)
            
                return BadRequest("No contiene Datos");
                CpcFactura cat = await factura.CpcFacturas.FirstOrDefaultAsync(x => x.FacFacturaId == f.FacFacturaId);
            if(cat == null)
            return NotFound();
            try
            {
                cat.CliClienteId = f.CliClienteId;
                cat.EmpEmpleadoId = f.EmpEmpleadoId;
                cat.FacFechaEmision = f.FacFechaEmision;
                cat.FacFechaVencimiento = f.FacFechaVencimiento;
                cat.FacCantidad = f.FacCantidad;
                cat.FacDescripcion = f.FacDescripcion;
                cat.FacPrecioUnitario = f.FacPrecioUnitario;
                cat.FacPrecioTotal = f.FacPrecioTotal;
                cat.FacIva  = f.FacIva;
                cat.FacSubtotal = f.FacSubtotal;
                cat.FacMontoTotal = f.FacMontoTotal;
                cat.FacMoneda   = f.FacMoneda;
                cat.FacFelNumeroAutorizacion = f.FacFelNumeroAutorizacion;
                cat.FacFelSerie = f.FacFelSerie;
                cat.FacFelNoDte = f.FacFelNoDte;
                cat.FacPlazoDePago = f.FacPlazoDePago;
                factura.CpcFacturas.Update(cat);
                await factura.SaveChangesAsync();
                return cat;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcFactura cat = await factura.CpcFacturas.FirstOrDefaultAsync(x => x.FacFacturaId == Id);
            if(cat == null)
                return NotFound();
            try
            {
                factura.CpcFacturas.Remove(cat);
                await factura.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
