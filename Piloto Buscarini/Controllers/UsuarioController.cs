using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Piloto_Buscarini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly PilotoContext _pilotoContext;

        public UsuarioController(PilotoContext pilotoContext)
        {
            _pilotoContext = pilotoContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var piloto = await _pilotoContext.usuarios.FirstOrDefaultAsync(p => p.Usuario1 == request.Email && p.Contraseña == request.Password);

            if (piloto == null)
            {
                return NotFound("El correo electrónico o la contraseña son incorrectos.");
            }

            return Ok(piloto);
        }
    }
}
