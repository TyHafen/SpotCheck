using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotCheck.Models
{
    public class Spot
    {
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public new string CreatorId { get; set; }
        public new Account? Creator { get; set; }

    }
}