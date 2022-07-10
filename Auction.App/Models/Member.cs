namespace Auction.App.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public List<Item> Items { get; set; }
    public List<Lot> BoughtItems { get; set; }
}
