using Auction.App.Database;
using Auction.App.Forms.Other;
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
    public partial class PlaceItemOnAuctionForm : Form
    {
        private DataContext context;
        public PlaceItemOnAuctionForm()
        {
            InitializeComponent();
            context = new DataContext();
            comboBox2.DataSource = context.Members.ToList().Select(x => new ComboboxItem { Text = x.Name, Value = x }).ToList();
            comboBox1.DataSource = context.Auctions.ToList().Select(x => new ComboboxItem { Text = $"{x.Address}: {x.Date}", Value = x }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && decimal.TryParse(textBox3.Text, out var price))
                {
                    context.Items.Add(new Item
                    {
                        Name = textBox1.Text,
                        Type = textBox2.Text,
                        Owner = (Member)(comboBox2.SelectedItem as ComboboxItem).Value
                    });
                    context.SaveChanges();
                    var item = context.Items.First(i => i.Name == textBox1.Text);
                    context.Lots.Add(new Lot
                    {
                        Id = item.Id,
                        Auction = (AuctionInfo)(comboBox1.SelectedItem as ComboboxItem).Value,
                        StartPrice = price,
                        Item = item
                    });
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
