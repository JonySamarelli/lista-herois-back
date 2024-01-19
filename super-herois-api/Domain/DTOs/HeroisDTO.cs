using super_herois_api.Domain.Models;
using System.Text.Json.Serialization;

namespace super_herois_api.Domain.DTOs
{
    public class HeroisDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        public List<Superpoderes> ListaSuperpoderes { get; set; }

        public HeroisDTO(int id, string nome, string nomeHeroi, DateTime dataNascimento, double altura, double peso, List<Superpoderes> listaSuperpoderes)
        {
            Id = id;
            Nome = nome;
            NomeHeroi = nomeHeroi;
            DataNascimento = dataNascimento;
            Altura = altura;
            Peso = peso;
            ListaSuperpoderes = listaSuperpoderes;
        }
    }
}
