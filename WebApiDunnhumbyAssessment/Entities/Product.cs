namespace WebApiDunnhumbyAssessment.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
