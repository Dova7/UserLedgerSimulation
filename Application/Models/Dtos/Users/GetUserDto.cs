using Application.Models.Dtos.Ledgers;

namespace Application.Models.Dtos.Users
{
    public class GetUserDto
    {
        public string Username { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<GetLedgerDto> Ledgers { get; set; } = new List<GetLedgerDto>();
    }
}
