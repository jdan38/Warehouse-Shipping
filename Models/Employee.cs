using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EfName { get; set; }
        [Required]
        public string ElName { get; set; }
        public string EAddress { get; set; }
        public string ECity { get; set; }
        public string EState { get; set; }
        public string EZip { get; set; }
        public string EEmail { get; set; }
    }
}
