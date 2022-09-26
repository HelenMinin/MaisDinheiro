using System.Threading.Tasks;
using MaisDinheiro.Data;
using MaisDinheiro.Models;
using MaisDinheiro.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaisDinheiro.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] Usuario model, [FromServices] AppDbContext context)
        {
            var usuario = await context
                .Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => 
                    x.NomeUsuario == model.NomeUsuario 
                    && x.Senha == model.Senha);

            if (usuario == null)
                return NotFound(new {message = "Usuário ou senha  inválidos"});

            var token = TokenService.GerarToken(usuario);

            usuario.Senha = "***";

            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}