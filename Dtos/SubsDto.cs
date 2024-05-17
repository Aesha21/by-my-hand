namespace by_my_hand.Dtos
{
    public class SubsDto
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        public required string Group { get; set; }
    }
}
