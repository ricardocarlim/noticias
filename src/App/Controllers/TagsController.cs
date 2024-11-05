using Microsoft.AspNetCore.Mvc;
using App.Application.Services;
using App.Domain.Entities;
using System;
using System.Linq;

namespace App.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly TagService _tagService;

        public TagsController(TagService tagService)
        {
            _tagService = tagService;
        }

        // GET: Tags
        public IActionResult Index()
        {
            try
            {
                var tags = _tagService.ObterTodas();
                return View(tags); // Retorna a view com a lista de tags
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                return StatusCode(500, "Erro ao carregar as tags.");
            }
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            try
            {
                var tags = _tagService.ObterTodas();
                return Json(tags); // Retorna as tags em formato JSON para popular o combo de seleção
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                return StatusCode(500, "Erro ao obter as tags.");
            }
        }

        [HttpPost]
        public IActionResult CriarTag([FromBody] Tag tag)
        {
            try
            {
                _tagService.CriarTag(tag);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                return StatusCode(500, "Erro ao criar a tag.");
            }
        }

        [HttpPut]
        public IActionResult EditarTag([FromBody] Tag tag)
        {
            try
            {
                _tagService.EditarTag(tag);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                return StatusCode(500, "Erro ao editar a tag.");
            }
        }

        [HttpPost]
        public IActionResult ExcluirTag([FromQuery] int id)
        {
            try
            {
                var tag = _tagService.ObterTodas().FirstOrDefault(t => t.Id == id);
                if (tag == null) return NotFound("Tag não encontrada.");

                var excluiTag = _tagService.ExcluirTag(tag);

                if (excluiTag)
                    return Ok();
                else
                    return BadRequest("Existe uma notícia vinculada a essa tag. Exclua a notícia antes de excluir a tag.");
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                return StatusCode(500, "Erro ao excluir a tag.");
            }
        }
    }
}
