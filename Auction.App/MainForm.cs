using Auction.App.Database;
using Auction.App.Forms;
using Microsoft.EntityFrameworkCore;

namespace Auction.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void task11Button_Click(object sender, EventArgs e)
        {
            var membersForm = new MembersForm();
            membersForm.ShowDialog();
        }

        private void task8Button_Click(object sender, EventArgs e)
        {
            var auctionsForm = new AuctionsForm();
            auctionsForm.ShowDialog();
        }

        private void task2Button_Click(object sender, EventArgs e)
        {
            var placeItemOnAuction = new PlaceItemOnAuctionForm();
            placeItemOnAuction.ShowDialog();
        }

        private void task5Button_Click(object sender, EventArgs e)
        {
            var buyItemOnAuction = new BuyItemOnAuctionForm();
            buyItemOnAuction.ShowDialog();
        }

        private void task1Button_Click(object sender, EventArgs e)
        {
            var context = new DataContext();
            UniversalListWithDateRangeForm.SortByDate sort = (DateOnly from, DateOnly to) => 
                context.Auctions.Where(a => a.Date >= from && a.Date <= to).OrderBy(a => a.Date).ToList();
            var universalListWithDateRangeForm = new UniversalListWithDateRangeForm("Список аукционов для интервала дат", sort);
            universalListWithDateRangeForm.ShowDialog();
        }

        private void task4Button_Click(object sender, EventArgs e)
        {
            var context = new DataContext();
            UniversalListWithDateRangeForm.SortByDate sort = (DateOnly from, DateOnly to) =>
                context.Items.Where(i => i.IsSold && i.ReceivedAt >= from && i.ReceivedAt <= to).Select(i => new { Название = i.Name, Дата = i.ReceivedAt}).ToList();
            var universalListWithDateRangeForm = new UniversalListWithDateRangeForm("Проданные предметы для интервала дат", sort);
            universalListWithDateRangeForm.ShowDialog();
        }

        private void task7Button_Click(object sender, EventArgs e)
        {
            var context = new DataContext();
            var lots = context.Lots.Include(l => l.Buyer).Include(l => l.Item);
            UniversalListWithDateRangeForm.SortByDate sort = (DateOnly from, DateOnly to) =>
                lots.Where(l => l.Item.IsSold).Select(l => new { l.Buyer, GoodName = l.Item.Name }).Select(b => new { Покупатель = b.Buyer.Name, Номер_телефона = b.Buyer.PhoneNumber, Товар = b.GoodName }).ToList();
            var universalListWithDateRangeForm = new UniversalListWithDateRangeForm("Проданные предметы для интервала дат", sort);
            universalListWithDateRangeForm.ShowDialog();
        }

        private void task3Button_Click(object sender, EventArgs e)
        {
            var auctionListWithSummaryForm = new AuctionListWithSummaryForm();
            auctionListWithSummaryForm.ShowDialog();
        }

        private void task6Button_Click(object sender, EventArgs e)
        {
            var context = new DataContext();
            var items = context.Items.Include(l => l.Owner).Include(l => l.Lot);
            UniversalListWithDateRangeForm.SortByDate sort = (DateOnly from, DateOnly to) =>
            {
                var first = items.Where(i => i.IsSold && i.ReceivedAt >= from && i.ReceivedAt <= to).ToList();
                return (from i in first
                        group i by i.Owner into r
                        select new { Имя = r.Key.Name, Общая_сумма = r.Sum(i => i.Lot.EndPrice) }).ToList();
            };
                
            var universalListWithDateRangeForm = new UniversalListWithDateRangeForm("Список продавцов и общая полученная сумма за указанный срок", sort);
            universalListWithDateRangeForm.ShowDialog();
        }

        private void task9Button_Click(object sender, EventArgs e)
        {
            var form = new AuctionListForm();
            form.ShowDialog();
        }

        private void task10Button_Click(object sender, EventArgs e)
        {
            var context = new DataContext();
            var items = context.Items.Include(i => i.Owner).ToList();
            UniversalListWithDateRangeForm.SortByDate sort = (DateOnly fromDate, DateOnly to) =>
                (from i in items
                 where (i.IsSold == true) && (i.ReceivedAt >= fromDate) && (i.ReceivedAt <= to)
                 group i by i.Owner into r
                 select new { Имя = r.Key.Name }).ToList();
            var form = new UniversalListWithDateRangeForm("Покупатели и кол-во покупок за срок", sort);
            form.ShowDialog();
        }

        private void task12Button_Click(object sender, EventArgs e)
        {
            var context = new DataContext();
            UniversalListWithDateRangeForm.SortByDate sort = (DateOnly from, DateOnly to) =>
            {
                var lots = context.Lots.Include(l => l.Auction).Include(l => l.Buyer).Where(l => l.Auction.Date >= from && l.Auction.Date <= to).ToList();
                return (from lot in lots
                        group lot by lot.Buyer into g
                        select new { Имя = g.Key.Name, Покупок = g.Count() }).ToList();
            };
            var form = new UniversalListWithDateRangeForm("Покупатели и кол-во покупок за срок", sort);
            form.ShowDialog();
        }
    }
}