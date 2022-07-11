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
    public partial class CreateAuctionForm : Form
    {
        public AuctionInfo Result { get; set; }

        public CreateAuctionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                Result = new AuctionInfo
                {
                    Address = textBox2.Text,
                    Date = DateOnly.FromDateTime(dateTimePicker1.Value),
                    Description = textBox1.Text
                };
            }
        }
    }
}
