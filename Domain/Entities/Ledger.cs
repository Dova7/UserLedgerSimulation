using Domain.Constants.Enums;

namespace Domain.Entities
{
    public class Ledger : BaseEntity
    {
        public Guid UserId {  get; set; }
        public decimal Amount { get; set; } 
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Description description { get; set; }
        public User User { get; set; } = null!;
    }
}
