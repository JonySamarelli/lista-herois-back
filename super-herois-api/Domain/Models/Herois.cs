using System.Text.Json.Serialization;

namespace super_herois_api.Domain.Models
{
    public class Herois
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        public Herois(string nome, string nomeHeroi, DateTime dataNascimento, double altura, double peso)
        {
            Nome = nome;
            NomeHeroi = nomeHeroi;
            DataNascimento = dataNascimento;
            Altura = altura;
            Peso = peso;
        }

        [JsonConstructor]
        public Herois(int id, string nome, string nomeHeroi, DateTime dataNascimento, double altura, double peso)
        {
            Id = id;
            Nome = nome;
            NomeHeroi = nomeHeroi;
            DataNascimento = dataNascimento;
            Altura = altura;
            Peso = peso;
        }
    }
}
