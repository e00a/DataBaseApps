using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabWork17
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public short ProductionYear { get; set; }
        public string Type { get; set; }
        public decimal? Weight { get; set; }
        public string? Description { get; set; }
        public int ManufacturerId { get; set; }
        public bool IsDeleted { get; set; }
        public byte Quantity { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}