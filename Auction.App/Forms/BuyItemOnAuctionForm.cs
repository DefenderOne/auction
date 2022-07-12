using Auction.App.Database;
using Auction.App.Forms.Other;
using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class BuyItemOnAuctionForm : Form
    {
        private DataContext context;

        public BuyItemOnAuctionForm()
        {
            InitializeComponent();
            context = new DataContext();
            var lots = context.Lots.Include(l => l.Item).Include(l => l.Auction).ToList();
            comboBox1.DataSource = lots.Where(l => !l.Item.IsSold).Select(x => new ComboboxItem
            {
                Text = $"Лот: {x.Item.Name}. Аукцион: {x.Auction.Address}",
                Value = x
            }).ToList();
            comboBox2.DataSource = context.Members.Select(x => new ComboboxItem
            {
                Text = x.Name,
                Value = x
            }).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is not null)
            {
                label2.Text = $"Максимальная ставка (Миниимальная ставка: {((comboBox1.SelectedItem as ComboboxItem).Value as Lot).StartPrice})";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lot = ((comboBox1.SelectedItem as ComboboxItem).Value as Lot);
                var buyer = ((comboBox2.SelectedItem as ComboboxItem).Value as Member);
                if (comboBox1.SelectedItem is not null &&
                    comboBox2.SelectedItem is not null &&
                    decimal.TryParse(textBox1.Text, out var endPrice) &&
                    endPrice >= lot.StartPrice)
                {
                    lot.EndPrice = endPrice;
                    lot.Buyer = buyer;
                    var item = context.Items.First(i => i.Id == lot.ItemId);
                    item.IsSold = true;
                    item.ReceivedAt = lot.Auction.Date;
                    context.Lots.Update(lot);
                    context.Items.Update(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
