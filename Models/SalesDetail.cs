using System;
using System.Collections.Generic;

namespace MasterDetailsBasics.Models;

public partial class SalesDetail
{
    public int IdSalesDetails { get; set; }

    public int? IdVenta { get; set; }

    public string? Product { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Overall { get; set; }

    public virtual Sale? IdVentaNavigation { get; set; }
}
