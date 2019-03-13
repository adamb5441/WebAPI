using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal TargetTotal { get; set; }
        public Decimal CurrentTotal { get; set; }

    }
}