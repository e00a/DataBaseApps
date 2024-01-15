using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PractWork4.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Model { get; set; } = null!;

    public decimal Price { get; set; }

    public short ProductionYear { get; set; }

    public string Type { get; set; } = null!;

    public decimal? Weight { get; set; }

    public string? Description { get; set; }

    public int ManufacturerId { get; set; }

    public bool IsDeleted { get; set; }

    public byte Quantity { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();
}
