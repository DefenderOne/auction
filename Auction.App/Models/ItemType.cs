namespace Auction.App.Models;

public class ItemType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Item> Items { get; set; }
}