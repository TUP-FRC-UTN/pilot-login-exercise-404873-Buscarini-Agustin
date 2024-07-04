using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Piloto_Buscarini.DTO;
using Piloto_Buscarini.Models;

namespace Piloto_Buscarini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : Controller
    {
        private readonly PilotoContext _pilotoContext;

        public PilotoController(PilotoContext pilotoContext)
        {
            _pilotoContext = pilotoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piloto>>> GetPilotos()
        {
            var pilotos = await _pilotoContext.pilotos
                .Include(p => p.IdNacionalidadNavigation)
                .Include(p => p.IdSexoNavigation)
                .ToListAsync();

            return pilotos;
        }

        [HttpPost]
        public async Task<ActionResult<Piloto>> PostPiloto(PilotoDTO pilotoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var nuevoPiloto = new Piloto
                {
                    Nombre = pilotoDto.Nombre,
                    Apellido = pilotoDto.Apellido,
                    HorasVuelo = pilotoDto.HorasVuelo,
                    IdSexo = pilotoDto.IdSexo,
                    IdNacionalidad = pilotoDto.IdNacionalidad
                };

                _pilotoContext.pilotos.Add(nuevoPiloto);
                await _pilotoContext.SaveChangesAsync();

                return CreatedAtAction(nameof(PostPiloto), new { id = nuevoPiloto.Id }, pilotoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiloto(int id, PilotoDTO pilotoDto)
        {
            var piloto = await _pilotoContext.pilotos.FindAsync(id);

            if (piloto == null)
            {
                return NotFound();
            }

            piloto.Nombre = pilotoDto.Nombre;
            piloto.Apellido = pilotoDto.Apellido;
            piloto.HorasVuelo = pilotoDto.HorasVuelo;
            piloto.IdSexo = pilotoDto.IdSexo;
            piloto.IdNacionalidad = pilotoDto.IdNacionalidad;

            _pilotoContext.Entry(piloto).State = EntityState.Modified;
            var response = await _pilotoContext.SaveChangesAsync();

            if (response == 0)
            {
                return BadRequest(new { message = "No se pudo guardar en la base." });
            }
            return Ok(new { message = "Se edito exitosamente." });
        }
    }
}
