﻿namespace App.Domain.Entities
{    
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
 
        public ICollection<Noticia> Noticias { get; set; }
    }

}
