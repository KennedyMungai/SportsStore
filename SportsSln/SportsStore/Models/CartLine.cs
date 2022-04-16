namespace SportsStore.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
    }
}
