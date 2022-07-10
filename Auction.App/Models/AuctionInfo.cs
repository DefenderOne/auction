namespace Auction.App.Models;

public class AuctionInfo
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public List<Lot> Lots { get; set; }
}
