using Auction.App.Database;
using Auction.App.Forms.Other;
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
    public partial class AuctionListForm : Form
    {
        private DataContext context;
        public AuctionListForm()
        {
            InitializeComponent();
            context = new DataContext();
            //comboBox1.DataSource = (from auction in context.Auctions
            //                        group auction by auction.Address into g
            //                        select new ComboboxItem { Text = g.Key, Value = g }).ToList();
            comboBox1.DataSource = context.Auctions.GroupBy(a => a.Address).Select(g => g.Key).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = context.Auctions.Where(a => a.Address == (string)comboBox1.SelectedValue).Select(a => a.Date.ToString()).ToList();
        }
    }
}
