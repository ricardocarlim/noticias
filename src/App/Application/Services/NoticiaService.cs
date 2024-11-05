using App.Domain.Entities;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class NoticiaService
    {
        private readonly IRepository<Noticia> _noticiaRepository;
        private readonly IRepository<NoticiaTag> _noticiaTagRepository;

        public NoticiaService(IRepository<Noticia> noticiaRepository, IRepository<NoticiaTag> noticiaTagRepository)
        {
            _noticiaRepository = noticiaRepository;
            _noticiaTagRepository = noticiaTagRepository;
        }

        public IEnumerable<Noticia> ObterTodas()
        {
            try
            {
                return _noticiaRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Erro ao obter todas as notícias.", ex);
            }
        }

        public Noticia ObterPorId(int id)
        {
            try
            {
                return _noticiaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Erro ao obter a notícia.", ex);
            }
        }

        public void CriarNoticia(Noticia noticia)
        {
            try
            {
                var id = _noticiaRepository.Add(noticia);
                noticia.TagIds.ToList().ForEach(tagId =>
                {
                    _noticiaTagRepository.Add(new NoticiaTag { NoticiaId = id, Noticia = noticia, TagId = tagId });
                });
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Erro ao criar a notícia.", ex);
            }
        }

        public void EditarNoticia(Noticia noticia)
        {
            try
            {
                _noticiaRepository.Update(noticia);
                _noticiaTagRepository.Delete(new NoticiaTag { NoticiaId = noticia.Id });

                noticia.TagIds.ToList().ForEach(tagId =>
                {
                    _noticiaTagRepository.Add(new NoticiaTag { NoticiaId = noticia.Id, Noticia = noticia, TagId = tagId });
                });
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Erro ao editar a notícia.", ex);
            }
        }

        public void ExcluirNoticia(Noticia noticia)
        {
            try
            {
                _noticiaTagRepository.Delete(new NoticiaTag { NoticiaId = noticia.Id });
                _noticiaRepository.Delete(noticia);
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Erro ao excluir a notícia.", ex);
            }
        }
    }
}
