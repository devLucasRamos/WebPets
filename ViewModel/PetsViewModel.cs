using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class PetsViewModel
    {
        [Required]
        public string DonoNome { get; set; }
        public string Nome { get; set; }
        public string TipoDePet { get; set; }
        public int Idade { get; set; }
        public string Cor { get; set; }

        public PetsViewModel(string donoNome, string nome, string tipoDePet, int idade, string cor)
        {
            DonoNome = donoNome;
            Nome = nome;
            TipoDePet = tipoDePet;
            Idade = idade;
            Cor = cor;
        }
    }
}