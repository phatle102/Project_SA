using System;
using System.Collections.Generic;

namespace FruitableShop.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Img { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }
}
