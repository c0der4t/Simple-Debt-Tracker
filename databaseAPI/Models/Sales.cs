namespace databaseAPI.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public string SaleID { get; set; }
        public DateTime DateTime { get; set; }
        public string SKU { get; set; }
        public float QTY { get; set; }
        public float SellPrice { get; set; }
        public string Description { get; set; }

    }
}
