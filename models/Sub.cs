using System.Diagnostics.CodeAnalysis;

namespace by_my_hand.models
{
    public class Sub
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public  byte[] image { get; set; }
        public required string Group { get; set; }
    }
}
