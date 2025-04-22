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
}
