using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }


        public string Description { get; set; }
    }
}