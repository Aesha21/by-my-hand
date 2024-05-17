using Microsoft.Extensions.Configuration.UserSecrets;

namespace by_my_hand.models
{
    public class Cart
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public required string items { get; set; }

    }
}
