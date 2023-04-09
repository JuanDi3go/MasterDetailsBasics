namespace MasterDetailsBasics.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string BusinessName { get; set;}
        public decimal Overall { get; set;}


        public List<SalesDetail> SalesDetails { get; set; }
    }
}
