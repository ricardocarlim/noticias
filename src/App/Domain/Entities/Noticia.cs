using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    // Domain/Entities/Noticia.cs
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [NotMapped]
        public int[] TagIds { get; set; }

        public ICollection<NoticiaTag> NoticiaTags { get; set; }
    }

}
