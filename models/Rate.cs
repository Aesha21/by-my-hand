namespace by_my_hand.models
{
    public class Rate
    {
        public byte Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public int stars { get; set; }

    }
}
