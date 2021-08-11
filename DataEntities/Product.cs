namespace PromotionEngine.DataEntities
{
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public Product(string id)
        {
            Id = id;
            switch (id)
            {
                case "A":
                    Price = 50m;
                    break;
                case "B":
                    Price = 30m;
                    break;
                case "C":
                    Price = 20m;
                    break;
                case "D":
                    Price = 15m;
                    break;
            }
        }
    }
}
