using Auction.App.Database;
using Auction.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auction.App.Forms
{
    public partial class AuctionsForm : Form
    {
        private DataContext context;
        public AuctionsForm()
        {
            InitializeComponent();
            context = new DataContext();
            auctionGrid.DataSource = context.Auctions.ToList();
            auctionGrid.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var form = new CreateAuctionForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                context.Auctions.Add(form.Result);
                context.SaveChanges();
                auctionGrid.DataSource = context.Auctions.ToList();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var list = (List<AuctionInfo>)auctionGrid.DataSource;
            if (auctionGrid.SelectedRows.Count != 0)
            {
                foreach (var row in auctionGrid.SelectedRows)
                {
                    var index = ((DataGridViewRow)row).Index;
                    context.Auctions.Remove(list[index]);
                }
                context.SaveChanges();
                auctionGrid.DataSource = context.Auctions.ToList();
            }
        }
    }
}
