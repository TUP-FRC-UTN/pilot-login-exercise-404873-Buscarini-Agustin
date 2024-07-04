using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Piloto_Buscarini.Models;

namespace Piloto_Buscarini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : Controller
    {
        private readonly PilotoContext _pilotoContext;
        public SexoController(PilotoContext pilotoContext)
        {
            _pilotoContext = pilotoContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sexo>>> GetNacionalidades()
        {
            var sexos = await _pilotoContext.Sexo.ToListAsync();
            return sexos;
        }
    }
}
