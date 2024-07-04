using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Piloto_Buscarini.Models;

namespace Piloto_Buscarini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : Controller
    {
        private readonly PilotoContext _pilotoContext;
        public NacionalidadController(PilotoContext pilotoContext) { 
            _pilotoContext = pilotoContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nacionalidad>>> GetNacionalidades()
        {
            var nacionalidades = await _pilotoContext.Nacionalidad.ToListAsync();
            return nacionalidades;
        }
    }
}
