namespace Domain.Entities
{
    public class Ledger : BaseEntity
    {
        public Guid UserId {  get; set; }
        public decimal Amount { get; set; } //negative = lose
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
    }
}
