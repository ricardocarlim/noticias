using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Application.Services
{
    // Application/Services/NoticiaService.cs
    public class UsuarioService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }      

        public IEnumerable<Usuario> ObterTodos()
        {
            // Implementar regras de negócio aqui
            return _usuarioRepository.GetAll();
        }

        public void CriarUsuario(Usuario usuario)
        {
            // Implementar regras de negócio aqui
            _usuarioRepository.Add(usuario);
        }

        public void EditarUsuario(Usuario usuario)
        {
            // Implementar regras de negócio aqui
            _usuarioRepository.Update(usuario);
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            _usuarioRepository.Delete(usuario);
        }
    }

}
