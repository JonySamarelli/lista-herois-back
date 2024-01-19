namespace super_herois_api.Domain.Models
{
    public class Superpoderes
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string? Descricao { get; set; }

        public Superpoderes(int id, string superpoder, string? descricao)
        {
            Id = id;
            Superpoder = superpoder;
            Descricao = descricao;
        }
    }
}
