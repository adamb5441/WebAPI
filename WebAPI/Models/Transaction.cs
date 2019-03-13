using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Enumeration;

namespace WebAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? BudgetItemId { get; set; }
        public string enteredById { get; set; }
        public DateTime date { get; set; }
        public decimal Amount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionTypes Type { get; set; }
        public bool Reaconciled { get; set; }
        public decimal ReconciledAmout { get; set; }
    }
}