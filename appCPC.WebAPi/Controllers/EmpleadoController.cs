using appCPC.DataAcces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appCPC.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ModelContext empleado;

        public EmpleadoController(ModelContext empleado)
        {
            this.empleado = empleado;
        }
        [HttpGet]
        public async Task<List<CpcEmpleado>> Listar()
        {
            return await empleado.CpcEmpleados.ToListAsync();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CpcEmpleado>> BuscarPorId(decimal Id)
        {
            var resultado = await empleado.CpcEmpleados.FirstOrDefaultAsync(x => x.EmpEmpleadoId == Id);
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
        public async Task<ActionResult<CpcEmpleado>> Guardar(CpcEmpleado e)
        {
            try
            {
                await empleado.CpcEmpleados.AddAsync(e);
                await empleado.SaveChangesAsync();
                e.EmpEmpleadoId = await empleado.CpcEmpleados.MaxAsync(x => x.EmpEmpleadoId);

                return e;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CpcEmpleado>> Actualizar(CpcEmpleado e)
        {
            if (e == null || e.EmpEmpleadoId == 0)
                return BadRequest("No contiene Daatos");
            CpcEmpleado cat = await empleado.CpcEmpleados.FirstOrDefaultAsync(x => x.EmpEmpleadoId == e.EmpEmpleadoId);

            if (cat == null)
                return NotFound();
            try
            {
                cat.EmpPrimerNombre = e.EmpPrimerNombre;
                cat.EmpSegundoNombre = e.EmpSegundoNombre;
                cat.EmpPrimerApellido = e.EmpPrimerApellido;
                cat.EmpSegundoApellido = e.EmpSegundoApellido;
                cat.EmpPuesto = e.EmpPuesto;
                cat.EmpTelefono = e.EmpTelefono;
                cat.EmpCui = e.EmpCui;
                cat.EmpPasaporte = e.EmpPasaporte;
                cat.EmpJefeInmediato = e.EmpJefeInmediato;
                cat.EmpEmail = e.EmpEmail;
                cat.EmpDireccion = e.EmpDireccion;
                cat.EmpUsuario = e.EmpUsuario;
                cat.EmpPassword = e.EmpPassword;
                empleado.CpcEmpleados.Update(cat);
                await empleado.SaveChangesAsync();
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
            CpcEmpleado elim = await empleado.CpcEmpleados.FirstOrDefaultAsync(x => x.EmpEmpleadoId == Id);
            if (elim == null)
                return NotFound();
            try
            {
                empleado.CpcEmpleados.Remove(elim);
                await empleado.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
