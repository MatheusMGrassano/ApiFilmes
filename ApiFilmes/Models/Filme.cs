using ApiFilmes.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public long Bilheteria { get; set; }
        public DateTime DataLancamento{ get; set; }
        public GeneroEnum Genero { get; set; }
    }
}
