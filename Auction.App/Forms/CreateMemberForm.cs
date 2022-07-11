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
    public partial class CreateMemberForm : Form
    {
        public Member Result { get; private set; }

        public CreateMemberForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                Result = new Member { Name = textBox1.Text, PhoneNumber = textBox2.Text };
            }
        }
    }
}
