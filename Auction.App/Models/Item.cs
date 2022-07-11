namespace Auction.App.Models;

public class Item
{
    public int Id { get; set; }

    public int OwnerId { get; set; }
    public Member Owner { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public Lot Lot { get; set; }

    public DateOnly ReceivedAt { get; set; }

    public bool IsSold { get; set; }
}
