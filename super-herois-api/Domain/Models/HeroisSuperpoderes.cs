namespace super_herois_api.Domain.Models
{
    public class HeroisSuperpoderes
    {
        public int HeroiId { get; set; }
        public int SuperpoderId { get; set; }

        public HeroisSuperpoderes(int heroiId, int superpoderId)
        {
            HeroiId = heroiId;
            SuperpoderId = superpoderId;
        }
    }
}
