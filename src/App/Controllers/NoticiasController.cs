using Microsoft.AspNetCore.Mvc;
using App.Application.Services;
using App.Domain.Entities;
using System;
using System.Linq;

namespace App.Web.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly NoticiaService _noticiaService;

        public NoticiasController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        public IActionResult Index()
        {
            try
            {
                var noticias = _noticiaService.ObterTodas();
                return View(noticias);
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro ao carregar as notícias.");
            }
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            try
            {
                var noticias = _noticiaService.ObterTodas();
                return Json(noticias);
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro ao obter todas as notícias.");
            }
        }

        [Route("Noticias/ObterPorId/{id?}")]
        [HttpGet("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var noticia = _noticiaService.ObterPorId(id);
                if (noticia == null)
                {
                    return NotFound("Notícia não encontrada.");
                }

                return Ok(new
                {
                    id = noticia.Id,
                    titulo = noticia.Titulo,
                    texto = noticia.Texto,
                    usuarioId = noticia.UsuarioId,
                    tagIds = noticia.NoticiaTags.Select(nt => nt.TagId).ToArray()
                });
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro ao obter a notícia.");
            }
        }

        [HttpPost]
        public IActionResult CriarNoticia([FromBody] Noticia noticia)
        {
            try
            {
                _noticiaService.CriarNoticia(noticia);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro ao criar a notícia.");
            }
        }

        [HttpPut]
        public IActionResult EditarNoticia([FromBody] Noticia noticia)
        {
            try
            {
                _noticiaService.EditarNoticia(noticia);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro ao editar a notícia.");
            }
        }

        [HttpPost]
        public IActionResult ExcluirNoticia([FromQuery] int id)
        {
            try
            {
                var noticia = _noticiaService.ObterPorId(id);
                if (noticia == null) return NotFound("Notícia não encontrada.");

                _noticiaService.ExcluirNoticia(noticia);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro ao excluir a notícia.");
            }
        }
    }
}
