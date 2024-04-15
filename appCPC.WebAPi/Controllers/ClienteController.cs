using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ModelContext cliente;
        public ClienteController(ModelContext cliente)
        {
            this.cliente = cliente;
        }
        [HttpGet]
        public async Task<List<CpcCliente>> Listar()
        {
            return await cliente.CpcClientes.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcCliente>> BuscarPorId(decimal Id)
        {
            var resultado = await cliente.CpcClientes.FirstOrDefaultAsync(x => x.CliClienteId == Id);
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
        public async Task<ActionResult<CpcCliente>> Guardar(CpcCliente c)
        {
            try
            {
                await cliente.CpcClientes.AddAsync(c);
                await cliente.SaveChangesAsync();
                c.CliClienteId = await cliente.CpcClientes.MaxAsync(x => x.CliClienteId);

                return c;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcCliente>> Actualizar(CpcCliente c)
        {
            if (c == null || c.CliClienteId == 0)
                return BadRequest("No Contiene Datos");
            CpcCliente cat = await cliente.CpcClientes.FirstOrDefaultAsync(x => x.CliClienteId == c.CliClienteId);
            if (cat == null)
                return NotFound();
            try
            {
                cat.CliPrimerNombre = c.CliPrimerNombre;
                cat.CliSegundoNombre = c.CliSegundoNombre;
                cat.CliPrimerApellido = c.CliPrimerApellido;
                cat.CliSegundoApellido = c.CliSegundoApellido;
                cat.CliCui = c.CliCui;
                cat.CliPasaporte = c.CliPasaporte;
                cat.CliNit = c.CliNit;
                cat.CliDireccion = c.CliDireccion;
                cat.CliTelefono = c.CliTelefono;
                cat.CliEmail = c.CliEmail;
                cliente.CpcClientes.Update(cat);
                await cliente.SaveChangesAsync();

                return cat;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Eliminar(decimal Id)
        {
            CpcCliente cat = await cliente.CpcClientes.FirstOrDefaultAsync(x => x.CliClienteId == Id);
            if (cat == null)
                return NotFound();
            try
            {
                cliente.CpcClientes.Remove(cat);
                await cliente.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
