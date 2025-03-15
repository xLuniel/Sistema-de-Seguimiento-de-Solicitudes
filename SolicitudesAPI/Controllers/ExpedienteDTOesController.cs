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
        public async Task<ActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ExpedienteDTO>>();
            var listaExpedienteDTO = new List<ExpedienteDTO>();

            try
            {
                foreach (var expediente in await _context.Expedientes.ToListAsync())
                {
                    listaExpedienteDTO.Add(new ExpedienteDTO
                    {
                        Id = expediente.Id,
                        Folio = expediente.Folio,
                        NombreSolicitante = expediente.NombreSolicitante,
                        FechaInicio = (DateTime)expediente.FechaInicio,
                        Estado = expediente.Estado,
                        ContenidoSolicitud = expediente.ContenidoSolicitud
                    });
                }

                responseApi.Exito = true;
                responseApi.Data = listaExpedienteDTO;
            }
            catch (Exception ex)
            {
                responseApi.Exito = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

            /*var expedientes = await _context.Expedientes.AsNoTracking().ToListAsync();

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
            }).ToList());*/
        }

        // GET: api/Expedientes/single/5
        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<ExpedienteDTO>();
            var ExpedienteDTO = new ExpedienteDTO();

            try
            {
                var dbExpediente = await _context.Expedientes.FirstOrDefaultAsync(e => e.Id == id); 

                if (dbExpediente != null)
                {
                    ExpedienteDTO = new ExpedienteDTO
                    {
                        Id = dbExpediente.Id,
                        Folio = dbExpediente.Folio,
                        NombreSolicitante = dbExpediente.NombreSolicitante,
                        FechaInicio = (DateTime)dbExpediente.FechaInicio,
                        Estado = dbExpediente.Estado,
                        ContenidoSolicitud = dbExpediente.ContenidoSolicitud
                    };

                    responseApi.Exito = true;
                    responseApi.Data = ExpedienteDTO;
                }
                else
                {
                    responseApi.Exito = false;
                    responseApi.Mensaje = "No se encontró el expediente";
                }


            }
            catch (Exception ex)
            {
                responseApi.Exito = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

            
        }

        // PUT: api/Expedientes/5
        [HttpPut("Editar/{id}")]
        public async Task<ActionResult> Editar(ExpedienteDTO expediente, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbExpediente = await _context.Expedientes.FirstOrDefaultAsync(e => e.Id == id);

                

                if (dbExpediente != null)
                {
                    dbExpediente.Folio = expediente.Folio;
                    dbExpediente.NombreSolicitante = expediente.NombreSolicitante; 
                    dbExpediente.FechaInicio = expediente.FechaInicio;
                    dbExpediente.Estado = expediente.Estado;
                    dbExpediente.ContenidoSolicitud = expediente.ContenidoSolicitud;
                    

                    _context.Expedientes.Update(dbExpediente);
                    await _context.SaveChangesAsync();

                    responseApi.Exito = true;
                    responseApi.Data = dbExpediente.Id; // posiblemente cree error al querer guardar sin proporcionar el id
                
                }
                else
                {
                    responseApi.Exito = false;
                    responseApi.Mensaje = "No se pudo encontrar el expediente";
                }


            }
            catch (Exception ex)
            {
                responseApi.Exito = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);


        }

        // POST: api/Expedientes/add
        [HttpPost("Crear")]
        public async Task<ActionResult> Crear(ExpedienteDTO expediente)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbExpediente = new Expediente
                {
                    Folio = expediente.Folio,
                    NombreSolicitante = expediente.NombreSolicitante,
                    FechaInicio = expediente.FechaInicio,
                    Estado = expediente.Estado,
                    ContenidoSolicitud = expediente.ContenidoSolicitud
                };

                _context.Expedientes.Add(dbExpediente);
                await _context.SaveChangesAsync();

                if(dbExpediente.Id != 0)
                {
                    responseApi.Exito = true;
                    responseApi.Data = dbExpediente.Id; // posiblemente cree error al querer guardar sin proporcionar el id
                }
                else
                {
                    responseApi.Exito = false;
                    responseApi.Mensaje = "No se pudo crear el expediente";
                }


            }
            catch (Exception ex)
            {
                responseApi.Exito = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);


        }

        // DELETE: api/Expedientes/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbExpediente = await _context.Expedientes.FirstOrDefaultAsync(e => e.Id == id);

                if (dbExpediente != null)
                {
                    _context.Expedientes.Remove(dbExpediente);
                    await _context.SaveChangesAsync();

                    responseApi.Exito = true;
                }
                else
                {
                    responseApi.Exito = false;
                    responseApi.Mensaje = "No se pudo encontrar el expediente";
                }
            }
            catch (Exception ex)
            {
                responseApi.Exito = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }
    }
}
