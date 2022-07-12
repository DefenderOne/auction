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
    public partial class UniversalListWithDateRangeForm : Form
    {
        public delegate object SortByDate(DateOnly from, DateOnly to);

        private SortByDate sort;

        public UniversalListWithDateRangeForm(string title, SortByDate sort)
        {
            InitializeComponent();
            Text = title;
            this.sort = sort;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sort(DateOnly.FromDateTime(dateTimePicker1.Value), DateOnly.FromDateTime(dateTimePicker2.Value));
        }
    }
}
