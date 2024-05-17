namespace by_my_hand.models
{
    public class Order
    {
        public int Id { get; set; }

        public required string ProductName { get; set; }

        public required string Description { get; set; }

        public required float Price { get; set; }

        public required int Quantity { get; set; }

        public required string PaymentType { get; set; }

        public required string OrderStatus {get; set;}

        public  byte[] image { get; set; }

    }
}
