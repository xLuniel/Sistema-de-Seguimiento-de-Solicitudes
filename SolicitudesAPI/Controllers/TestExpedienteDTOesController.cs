using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolicitudesAPI.Models;
using SolicitudesShared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestExpedientesController : ControllerBase
    {
        private readonly SistemaSolicitudesContext _context;

        public TestExpedientesController(SistemaSolicitudesContext context)
        {
            _context = context;
        }

        // GET: api/TestExpedientes/Lista
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<TestExpedienteDTO>>> GetTestExpedientes()
        {
            var expedientes = await _context.TestExpedientes.AsNoTracking().ToListAsync();

            if (expedientes.Count == 0)
                return NotFound();

            return Ok(expedientes.Select(e => new TestExpedienteDTO
            {
                Id = e.Id,
                Folio = e.Folio,
                NombreSolicitante = e.NombreSolicitante,
                FechaInicio = e.FechaInicio,
                Estado = e.Estado,
                ContenidoSolicitud = e.ContenidoSolicitud
            }).ToList());
        }

        // GET: api/TestExpedientes/single/5
        [HttpGet("single/{id}")]
        public async Task<ActionResult<TestExpedienteDTO>> GetTestExpediente(int id)
        {
            var expediente = await _context.TestExpedientes.AsNoTracking()
                                    .FirstOrDefaultAsync(e => e.Id == id);

            if (expediente == null)
                return NotFound();

            return new TestExpedienteDTO
            {
                Id = expediente.Id,
                Folio = expediente.Folio,
                NombreSolicitante = expediente.NombreSolicitante,
                FechaInicio = expediente.FechaInicio,
                Estado = expediente.Estado,
                ContenidoSolicitud = expediente.ContenidoSolicitud
            };
        }

        // PUT: api/TestExpedientes/5
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> PutTestExpediente(int id, TestExpedienteDTO expedienteDTO)
        {
            if (id != expedienteDTO.Id)
                return BadRequest();

            var expediente = await _context.TestExpedientes.FindAsync(id);
            if (expediente == null)
                return NotFound();

            // Actualizar valores
            expediente.Folio = expedienteDTO.Folio;
            expediente.NombreSolicitante = expedienteDTO.NombreSolicitante;
            expediente.FechaInicio = expedienteDTO.FechaInicio;
            expediente.Estado = expedienteDTO.Estado;
            expediente.ContenidoSolicitud = expedienteDTO.ContenidoSolicitud;

            _context.Update(expediente);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExpedienteExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok(expediente);
        }

        // POST: api/TestExpedientes/add
        [HttpPost("add")]
        public async Task<ActionResult<TestExpedienteDTO>> PostTestExpediente(TestExpedienteDTO expedienteDTO)
        {
            var expediente = new TestExpediente
            {
                Folio = expedienteDTO.Folio,
                NombreSolicitante = expedienteDTO.NombreSolicitante,
                FechaInicio = expedienteDTO.FechaInicio,
                Estado = expedienteDTO.Estado,
                ContenidoSolicitud = expedienteDTO.ContenidoSolicitud
            };

            _context.TestExpedientes.Add(expediente);
            await _context.SaveChangesAsync();

            expedienteDTO.Id = expediente.Id;

            return CreatedAtAction(nameof(GetTestExpediente), new { id = expediente.Id }, expedienteDTO);
        }

        // DELETE: api/TestExpedientes/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteTestExpediente(int id)
        {
            var expediente = await _context.TestExpedientes.FindAsync(id);
            if (expediente == null)
                return NotFound();

            _context.TestExpedientes.Remove(expediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestExpedienteExists(int id)
        {
            return _context.TestExpedientes.Any(e => e.Id == id);
        }
    }
}
