using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Inventory
    {
        [Key]
        public int IvenId { get; set; }
        public string ItemName { get; set; }

        public int Qyt { get; set; }

        public int Price { get; set; }
    }
}
