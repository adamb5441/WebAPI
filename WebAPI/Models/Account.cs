using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int? HouseholdId { get; set; }
        public string Name { get; set; }
        public Decimal InitialBalance { get; set; }
        public Decimal CurrentBalance { get; set; }
        public Decimal? LowBalanceLevel { get; set; }

    }
}