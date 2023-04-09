namespace MasterDetailsBasics.Models
{
    public class SalesEntityViewModel
    {
        public Sale OSale { get; set; }
        public List<SalesDetail> ListSalesDetails { get; set; }
    }
}
