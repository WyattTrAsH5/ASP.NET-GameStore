namespace ASP.NET_GameStore.Models
{
    public class CartItem
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}