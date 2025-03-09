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
    public class ExpedientesController : ControllerBase
    {
        private readonly SistemaSolicitudesContext _context;

        public ExpedientesController(SistemaSolicitudesContext context)
        {
            _context = context;
        }

        // GET: api/Expedientes/Lista
        [HttpGet("Lista")]
        public async Task<ActionResult<IEnumerable<ExpedienteDTO>>> GetExpedientes()
        {
            var expedientes = await _context.Expedientes.AsNoTracking().ToListAsync();

            if (expedientes.Count == 0)
                return NotFound();

            return Ok(expedientes.Select(e => new ExpedienteDTO
            {
                Id = e.Id,
                Folio = e.Folio,
                NombreSolicitante = e.NombreSolicitante,
                FechaInicio = e.FechaInicio,
                Estado = e.Estado,
                ContenidoSolicitud = e.ContenidoSolicitud
            }).ToList());
        }

        // GET: api/Expedientes/single/5
        [HttpGet("single/{id}")]
        public async Task<ActionResult<ExpedienteDTO>> GetExpediente(int id)
        {
            var expediente = await _context.Expedientes.AsNoTracking()
                                    .FirstOrDefaultAsync(e => e.Id == id);

            if (expediente == null)
                return NotFound();

            return new ExpedienteDTO
            {
                Id = expediente.Id,
                Folio = expediente.Folio,
                NombreSolicitante = expediente.NombreSolicitante,
                FechaInicio = expediente.FechaInicio,
                Estado = expediente.Estado,
                ContenidoSolicitud = expediente.ContenidoSolicitud
            };
        }

        // PUT: api/Expedientes/5
        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> PutExpediente(int id, ExpedienteDTO expedienteDTO)
        {
            if (id != expedienteDTO.Id)
                return BadRequest();

            var expediente = await _context.Expedientes.FindAsync(id);
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
                if (!ExpedienteExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok(expediente);
        }

        // POST: api/Expedientes/add
        [HttpPost("add")]
        public async Task<ActionResult<ExpedienteDTO>> PostExpediente(ExpedienteDTO expedienteDTO)
        {
            var expediente = new Expediente
            {
                Folio = expedienteDTO.Folio,
                NombreSolicitante = expedienteDTO.NombreSolicitante,
                FechaInicio = expedienteDTO.FechaInicio,
                Estado = expedienteDTO.Estado,
                ContenidoSolicitud = expedienteDTO.ContenidoSolicitud
            };

            _context.Expedientes.Add(expediente);
            await _context.SaveChangesAsync();

            expedienteDTO.Id = expediente.Id;

            return CreatedAtAction(nameof(GetExpediente), new { id = expediente.Id }, expedienteDTO);
        }

        // DELETE: api/Expedientes/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> DeleteExpediente(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null)
                return NotFound();

            _context.Expedientes.Remove(expediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.Id == id);
        }
    }
}
