using Auction.App.Database;
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
    public partial class AuctionListWithSummaryForm : Form
    {
        private DataContext context;

        public AuctionListWithSummaryForm()
        {
            InitializeComponent();
            context = new DataContext();
            var lots = context.Lots.Include(l => l.Auction).ToList();
            var result = (from l in lots
                         group l by l.Auction into r
                         select new { Название = r.Key.Address, Итого = r.Sum(l => l.EndPrice) });
            dataGridView1.DataSource = result.ToList();
        }
    }
}
