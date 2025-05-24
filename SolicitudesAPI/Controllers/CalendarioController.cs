using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Seguimiento_de_Solicitudes.Models;
using SolicitudesAPI.Models;
using SolicitudesShared;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CalendarioController : ControllerBase
{
    private readonly SistemaSolicitudesContext _context;

    public CalendarioController(SistemaSolicitudesContext context)
    {
        _context = context;
    }
    //Simulando una base de datos en memoria
    //private static List<CalendarioDTO> DiasActivos = new();

    [HttpGet("Obtener_dias")]
    public async Task<ActionResult<List<CalendarioDTO>>> Obtener()
    {
        var dias = await _context.Calendario.
            Select(d => new CalendarioDTO
            {
                Fecha = d.Fecha,
                Activo = d.Activo
            }).ToListAsync();


        return Ok(dias);
    }

    [HttpPost("Guardar_dia")]
    public async Task<ActionResult> Guardar(List<CalendarioDTO> diasActivos)
    {
        var responseApi = new ResponseAPI<List<CalendarioDTO>>();

        if(diasActivos == null || diasActivos.Count == 0)
        {
            responseApi.Exito = false;
            responseApi.Mensaje = "No se recibieron días activos.";
            return BadRequest(responseApi);
        }

        // Guardar los días activos en la base de datos
        foreach (var dia in diasActivos)
        {
            // Verificar si el día ya existe en la base de datos
            //var diaExistente = await _context.Calendario
            //    .FirstOrDefaultAsync(d => d.Fecha == dia.Fecha);

            bool existe = await _context.Calendario
                .AnyAsync(d => d.Fecha == dia.Fecha);

            if (!existe)
            {
                var nuevoDia = new Calendario
                {
                    Fecha = dia.Fecha,
                    Activo = dia.Activo
                };

                _context.Calendario.Add(nuevoDia);
            }
        }

        await _context.SaveChangesAsync();

        //DiasActivos = diasActivos;

        return Ok(new { mensaje = "Dias guardados correctamente"});
    }

    
    //public async Task<ActionResult<IEnumerable<DateTime>>> Get_DiasInhabiles()
    //{
    //    var dias = await _context.DiaInhabilManual
    //        .Select(d => d.Fecha.Date)
    //        .ToListAsync();

    //    return Ok(dias);
    //}
    //[HttpGet]

    [HttpGet ("Get_DiasInhabiles")]
    public async Task<ActionResult<List<DiaInhabilManualDTO>>> ObtenerDiasInhabiles()
    {
        var dias = await _context.DiaInhabilManual
            .Select(d => new DiaInhabilManualDTO
            {
                Fecha = d.Fecha.Date
            })
            .ToListAsync();

        return Ok(dias);
    }

    // guardar dia uno por uno
    [HttpPost ("Guardar_DiasInhabiles")]
    public async Task<IActionResult> Guardar_DiaInhabil([FromBody] DiaInhabilManualDTO diaInhabil)
    {
        //fecha = fecha.Date;

        if (diaInhabil == null || diaInhabil == default)
        {
            return BadRequest("La fecha es requerida.");
        }

        var fecha = diaInhabil.Fecha.Date;

        if (!await _context.DiaInhabilManual.AnyAsync(d => d.Fecha == fecha))
        {
            _context.DiaInhabilManual.Add(new DiaInhabilManual { Fecha = fecha });
            await _context.SaveChangesAsync();
        }

        return Ok(new { mensaje = "Día inhábil guardado correctamente." });
    }

    // guardar varios dias
    //[HttpPost("Guardar_variosDiasInhabiles")]
    //public async Task<IActionResult> PostVarios([FromBody] List<DateTime> fechas)
    //{
    //    var existentes = await _context.DiaInhabilManual
    //        .Select(d => d.Fecha.Date)
    //        .ToListAsync();

    //    var nuevas = fechas
    //        .Select(f => f.Date)
    //        .Where(f => !existentes.Contains(f))
    //        .Distinct()
    //        .Select(f => new DiaInhabilManual { Fecha = f })
    //        .ToList();

    //    if (nuevas.Any())
    //    {
    //        _context.DiaInhabilManual.AddRange(nuevas);
    //        await _context.SaveChangesAsync();
    //    }

    //    return NoContent();
    //}

    [HttpDelete("Eliminar_DiaInhabil/{fecha}")]
    public async Task<IActionResult> Eliminar_DiaInhabil(DateTime fecha)
    {
        var fechaNormalizada = fecha.Date;

        var diaInhabil = await _context.DiaInhabilManual
            .FirstOrDefaultAsync(d => d.Fecha == fechaNormalizada);

        if (diaInhabil == null)
        {
            return NotFound();
        }

        _context.DiaInhabilManual.Remove(diaInhabil);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
