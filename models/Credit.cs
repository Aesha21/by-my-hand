namespace by_my_hand.models
{
    public class Credit
    {
  public int Id { get; set; }
  public required string HolderName { get; set; }

  public required string CardNumber { get; set; }

  public int CVV { get; set; }
  public DateTime ExpiryDate { get; set; } 

    }
}
