using System;
using System.Collections.Generic;

namespace MasterDetailsBasics.Models;

public partial class Sale
{
    public int IdVenta { get; set; }

    public string? DocumentNumber { get; set; }

    public string? BusinessName { get; set; }

    public decimal? Overall { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
