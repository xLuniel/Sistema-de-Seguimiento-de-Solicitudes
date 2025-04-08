﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolicitudesAPI.Models;
using SolicitudesShared;
using System.Collections.Generic;
using System.Drawing;
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
        public string? RecibidaRegistradaPNT { get; set; }

        // Fixing the syntax errors and context issues in the Lista method

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
                        // Etapa inicial
                        Id = expediente.Id,
                        Folio = expediente.Folio,
                        NombreSolicitante = expediente.NombreSolicitante,
                        FechaInicio = expediente.FechaInicio ?? default(DateTime), // Manejar valores NULL
                        Estado = expediente.Estado,
                        ContenidoSolicitud = expediente.ContenidoSolicitud,
                        MesAdmision = expediente.MesAdmision,
                        TipoSolicitud = expediente.TipoSolicitud,
                        TipoDerecho = expediente.TipoDerecho,
                        FechaLimiteRespuesta10dias = expediente.FechaLimiteRespuesta10dias,
                        Ampliacion = expediente.Ampliacion,
                        FechaLimiteRespuesta20dias = expediente.FechaLimiteRespuesta20dias,
                        FechaRespuesta = expediente.FechaRespuesta,
                        PromedioDiasRespuesta = expediente.PromedioDiasRespuesta,
                        Prevencion = expediente.Prevencion,
                        SubsanaPrevencionReinicoTramite = expediente.SubsanaPrevencionReinicoTramite,
                        FechaLimitePrevencion10dias = expediente.FechaLimitePrevencion10dias,
                        PreferenciaParaRecibirRespuesta = expediente.PreferenciaParaRecibirRespuesta,
                        CorreoElectronicoSolicitante = expediente.CorreoElectronicoSolicitante,

                        // Etapa de seguimiento
                        AreaPoseedoraInformacion = expediente.AreaPoseedoraInformacion,

                        // Etapa Final
                        Materia = expediente.Materia,
                        CiudadSolicitante = expediente.CiudadSolicitante,
                        Tematica = expediente.Tematica,
                        TematicaEspecifica = expediente.TematicaEspecifica,
                        SentidoRespuesta = expediente.SentidoRespuesta,
                        PrecisionSentidoRespuesta = expediente.PrecisionSentidoRespuesta,
                        ModalidadEntrega = expediente.ModalidadEntrega,
                        Cobro = expediente.Cobro,
                        RecursoRevision = expediente.RecursoRevision,
                        DatosRecursoRevision = expediente.DatosRecursoRevision,
                        Nota = expediente.Nota
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
        }

        // Fixing the syntax errors and context issues in the Buscar method

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
                        // Etapa inicial
                        Id = dbExpediente.Id,
                        Folio = dbExpediente.Folio,
                        NombreSolicitante = dbExpediente.NombreSolicitante,
                        FechaInicio = dbExpediente.FechaInicio ?? default(DateTime), // Manejar valores NULL
                        Estado = dbExpediente.Estado,
                        ContenidoSolicitud = dbExpediente.ContenidoSolicitud,
                        MesAdmision = dbExpediente.MesAdmision,
                        TipoSolicitud = dbExpediente.TipoSolicitud,
                        TipoDerecho = dbExpediente.TipoDerecho,
                        FechaLimiteRespuesta10dias = dbExpediente.FechaLimiteRespuesta10dias,
                        Ampliacion = dbExpediente.Ampliacion,
                        FechaLimiteRespuesta20dias = dbExpediente.FechaLimiteRespuesta20dias,
                        FechaRespuesta = dbExpediente.FechaRespuesta,
                        PromedioDiasRespuesta = dbExpediente.PromedioDiasRespuesta,
                        Prevencion = dbExpediente.Prevencion,
                        SubsanaPrevencionReinicoTramite = dbExpediente.SubsanaPrevencionReinicoTramite,
                        FechaLimitePrevencion10dias = dbExpediente.FechaLimitePrevencion10dias,
                        PreferenciaParaRecibirRespuesta = dbExpediente.PreferenciaParaRecibirRespuesta,
                        CorreoElectronicoSolicitante = dbExpediente.CorreoElectronicoSolicitante,

                        // Etapa de seguimiento
                        AreaPoseedoraInformacion = dbExpediente.AreaPoseedoraInformacion,

                        // Etapa Final
                        Materia = dbExpediente.Materia,
                        CiudadSolicitante = dbExpediente.CiudadSolicitante,
                        Tematica = dbExpediente.Tematica,
                        TematicaEspecifica = dbExpediente.TematicaEspecifica,
                        SentidoRespuesta = dbExpediente.SentidoRespuesta,
                        PrecisionSentidoRespuesta = dbExpediente.PrecisionSentidoRespuesta,
                        ModalidadEntrega = dbExpediente.ModalidadEntrega,
                        Cobro = dbExpediente.Cobro,
                        RecursoRevision = dbExpediente.RecursoRevision,
                        DatosRecursoRevision = dbExpediente.DatosRecursoRevision,
                        Nota = dbExpediente.Nota
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
                    //dbExpediente.Folio = expediente.Folio;
                    //dbExpediente.NombreSolicitante = expediente.NombreSolicitante;
                    //dbExpediente.FechaInicio = expediente.FechaInicio;
                    //dbExpediente.Estado = expediente.Estado;
                    //dbExpediente.ContenidoSolicitud = expediente.ContenidoSolicitud;

                    //foreach (var prop in typeof(ExpedienteDTO).GetProperties())
                    //{
                    //    var dbProp = typeof(Expediente).GetProperty(prop.Name);
                    //    if (dbProp != null && dbProp.CanWrite)
                    //    {
                    //        dbProp.SetValue(dbExpediente, prop.GetValue(expediente));
                    //    }
                    //}

                    foreach (var propDto in typeof(ExpedienteDTO).GetProperties())
                    {
                        var propExpediente = typeof(Expediente).GetProperty(propDto.Name);

                        if (propExpediente != null && propExpediente.CanWrite)
                        {
                            var value = propDto.GetValue(expediente);

                            try
                            {
                                // 🔥 Conversión de tipos si es necesario
                                if (propExpediente.PropertyType == typeof(string) && value is DateTime dateTimeValue)
                                {
                                    propExpediente.SetValue(dbExpediente, dateTimeValue.ToString("dd-MM-yyyy"));
                                }
                                else if (propExpediente.PropertyType == typeof(DateTime) && value is string stringValue)
                                {
                                    if (DateTime.TryParse(stringValue, out DateTime parsedDate))
                                    {
                                        propExpediente.SetValue(dbExpediente, parsedDate);
                                    }
                                }
                                else if (propExpediente.PropertyType == propDto.PropertyType)
                                {
                                    propExpediente.SetValue(dbExpediente, value);
                                }
                                else
                                {
                                    Console.WriteLine($"⚠️ No se pudo asignar {propDto.Name} ({propDto.PropertyType} → {propExpediente.PropertyType})");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"❌ Error al asignar {propDto.Name}: {ex.Message}");
                            }
                        }
                    }

                        _context.Expedientes.Update(dbExpediente);
                    await _context.SaveChangesAsync();

                    responseApi.Exito = true;
                    responseApi.Data = dbExpediente.Id;
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

                if (dbExpediente.Id != 0)
                {
                    responseApi.Exito = true;
                    responseApi.Data = dbExpediente.Id;
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

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ExpedienteDTO expediente)
        {
            if (id != expediente.Id)
            {
                return BadRequest("ID mismatch");
            }

            var expedienteExistente = await _context.Expedientes.FindAsync(id);
            if (expedienteExistente == null)
            {
                return NotFound("Expediente no encontrado");
            }

            // Etapa Inicial
            expedienteExistente.MesAdmision = expediente.MesAdmision;
            expedienteExistente.TipoSolicitud = expediente.TipoSolicitud;
            expedienteExistente.TipoDerecho = expediente.TipoDerecho;
            expedienteExistente.FechaInicio = expediente.FechaInicio;
            expedienteExistente.FechaLimiteRespuesta10dias = expediente.FechaLimiteRespuesta10dias;
            expedienteExistente.Ampliacion = expediente.Ampliacion;
            expedienteExistente.FechaLimiteRespuesta20dias = expediente.FechaLimiteRespuesta20dias;
            expedienteExistente.Estado = expediente.Estado;
            expedienteExistente.FechaRespuesta = expediente.FechaRespuesta;
            expedienteExistente.PromedioDiasRespuesta = expediente.PromedioDiasRespuesta;
            expedienteExistente.Prevencion = expediente.Prevencion;
            expedienteExistente.SubsanaPrevencionReinicoTramite = expediente.SubsanaPrevencionReinicoTramite;
            expedienteExistente.FechaLimitePrevencion10dias = expediente.FechaLimitePrevencion10dias;
            expedienteExistente.PreferenciaParaRecibirRespuesta = expediente.PreferenciaParaRecibirRespuesta;
            expedienteExistente.NombreSolicitante = expediente.NombreSolicitante;
            expedienteExistente.CorreoElectronicoSolicitante = expediente.CorreoElectronicoSolicitante;
            expedienteExistente.ContenidoSolicitud = expediente.ContenidoSolicitud;

            // Etapa de Seguimiento
            expedienteExistente.AreaPoseedoraInformacion = expediente.AreaPoseedoraInformacion;

            // Etapa Final
            expedienteExistente.Materia = expediente.Materia;
            expedienteExistente.CiudadSolicitante = expediente.CiudadSolicitante;
            expedienteExistente.Tematica = expediente.Tematica;
            expedienteExistente.TematicaEspecifica = expediente.TematicaEspecifica;
            expedienteExistente.SentidoRespuesta = expediente.SentidoRespuesta;
            expedienteExistente.PrecisionSentidoRespuesta = expediente.PrecisionSentidoRespuesta;
            expedienteExistente.ModalidadEntrega = expediente.ModalidadEntrega;
            expedienteExistente.Cobro = expediente.Cobro;
            expedienteExistente.RecursoRevision = expediente.RecursoRevision;
            expedienteExistente.DatosRecursoRevision = expediente.DatosRecursoRevision;
            expedienteExistente.Nota = expediente.Nota;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new ResponseAPI<int> { Exito = true, Data = expedienteExistente.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
    }
}
 