using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork16
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Model { get; set; }
        public decimal Price{ get; set; }
        public int ProductionYear{ get; set; }
        public string? Type { get; set; }
        public decimal Weight { get; set; }
        public string? Description { get; set; }
        public int ManufacturerId { get; set; }
        public bool IsDeleted { get; set; }
        public int Quantity { get; set; }
    }
}
