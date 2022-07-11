namespace Auction.App.Models;

public class Lot
{
    public int Id { get; set; }

    public int AuctionId { get; set; }
    public AuctionInfo Auction { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }

    public decimal StartPrice { get; set; }
    public decimal EndPrice { get; set; }
    
    public int? BuyerId { get; set; }
    public Member Buyer { get; set; }
}
