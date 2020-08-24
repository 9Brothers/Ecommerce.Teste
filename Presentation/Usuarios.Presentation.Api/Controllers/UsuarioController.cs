using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Application.Interfaces;
using Usuarios.Domain.Entities;

namespace Usuarios.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        protected readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(string nome, bool ativo = true, int pagina = 1)
        {
            try
            {
                var usuarios = await _usuarioAppService.Filter(new Usuario { Nome = nome, Ativo = ativo }, pagina);

                return Ok(usuarios);
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.InnerException?.Message ?? ex.Message);                 
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Usuario usuario)
        {
            try
            {
                usuario = await _usuarioAppService.Add(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.InnerException?.Message ?? ex.Message);                 
            }
        }
    }
}