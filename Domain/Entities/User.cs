namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Ledger> Ledgers { get; set; } = new List<Ledger>();
    }
}
