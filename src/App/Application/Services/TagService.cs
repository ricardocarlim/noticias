using App.Domain.Entities;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace App.Application.Services
{
    // Application/Services/TagService.cs
    public class TagService
    {
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<NoticiaTag> _noticiaTagRepository;

        public TagService(IRepository<Tag> tagRepository, IRepository<NoticiaTag> noticiaTagRepository)
        {
            _tagRepository = tagRepository;
            _noticiaTagRepository = noticiaTagRepository;
        }

        public IEnumerable<Tag> ObterTodas()
        {
            try
            {
                return _tagRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                throw new ApplicationException("Erro ao obter todas as tags.", ex);
            }
        }

        public void CriarTag(Tag tag)
        {
            try
            {
                _tagRepository.Add(tag);
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                throw new ApplicationException("Erro ao criar a tag.", ex);
            }
        }

        public void EditarTag(Tag tag)
        {
            try
            {
                _tagRepository.Update(tag);
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                throw new ApplicationException("Erro ao editar a tag.", ex);
            }
        }

        public bool ExcluirTag(Tag tag)
        {
            try
            {
                var excluirTag = false;
                var noticiasTags = _noticiaTagRepository.GetByIdTag(tag.Id);

                if (noticiasTags == null || noticiasTags.Count() <= 0)
                {
                    excluirTag = true;
                    _tagRepository.Delete(tag);
                }

                return excluirTag;
            }
            catch (Exception ex)
            {
                // Log a exceção (ex)
                throw new ApplicationException("Erro ao excluir a tag.", ex);
            }
        }
    }
}
