namespace by_my_hand.Dtos
{
    public class LoginDto
    {
        public required string Email { get; set; }

        [MaxLength(50)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
