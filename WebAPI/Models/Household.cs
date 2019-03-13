using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// A class representing a household.
    /// </summary>
    public class Household
    {
        /// <summary>
        /// PK of the household.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The household name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The household greeting.
        /// </summary>
        public string Greeting { get; set; }

    }
}