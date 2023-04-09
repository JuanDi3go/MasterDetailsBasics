using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace MasterDetailsBasics.Models
{
    public class SalesDetail
    {
       public int Id { get; set; } 
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Overall { get; set; }
    }
}
