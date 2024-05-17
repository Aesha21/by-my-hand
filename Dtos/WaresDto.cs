namespace by_my_hand.Dtos
{
    public class WaresDto
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        public required string Description { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public required string Size { get; set; }

        public required string Color { get; set; }

        public required string Group { get; set; }

        public int Rate { get; set; }

    }
}
