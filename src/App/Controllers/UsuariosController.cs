using Microsoft.AspNetCore.Mvc;
using App.Application.Services;
using App.Domain.Entities;

namespace App.Web.Controllers
{    
    public class UsuariosController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            var usuarios = _usuarioService.ObterTodos();
            return View(usuarios); // Retorna a view com a lista de usuários
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var usuarios = _usuarioService.ObterTodos();
            return Json(usuarios);
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] Usuario usuario)
        {
            _usuarioService.CriarUsuario(usuario);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarUsuario([FromBody] Usuario usuario)
        {
            _usuarioService.EditarUsuario(usuario);
            return Ok();
        }

        [HttpPost]
        public IActionResult ExcluirUsuario([FromQuery]int id)
        {
            var usuario = _usuarioService.ObterTodos().FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();
            _usuarioService.ExcluirUsuario(usuario);
            return Ok();
        }
    }
}
