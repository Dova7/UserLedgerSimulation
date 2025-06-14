using Domain.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dtos.Ledgers
{
    public class GetLedgerDto
    {
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Description description { get; set; }
    }
}
