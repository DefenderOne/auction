using Auction.App.Forms;

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
    }
}