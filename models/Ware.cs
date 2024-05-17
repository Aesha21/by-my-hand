using System.Diagnostics.CodeAnalysis;

namespace by_my_hand.models
{
    public class Ware
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public required string Description { get; set; }

        public  byte[] image { get; set; }

        public float price { get; set; }

        public int quantity { get; set; }

        public required string size { get; set; }

        public required string color { get; set; }

        public required string group { get; set; }

        public int rate { get; set; }

    }
}

