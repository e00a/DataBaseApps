using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabWork17
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}