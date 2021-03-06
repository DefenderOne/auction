using Auction.App.Database;
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
    public partial class MembersForm : Form
    {
        private DataContext context;
        public MembersForm()
        {
            InitializeComponent();
            context = new DataContext();
            memberGrid.DataSource = context.Members.ToList();
            memberGrid.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var form = new CreateMemberForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                context.Members.Add(form.Result);
                context.SaveChanges();
                memberGrid.DataSource = context.Members.ToList();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var list = (List<Member>)memberGrid.DataSource;
            if (memberGrid.SelectedRows.Count != 0)
            {
                foreach (var row in memberGrid.SelectedRows)
                {
                    var index = ((DataGridViewRow)row).Index;
                    context.Members.Remove(list[index]);
                }
                context.SaveChanges();
                memberGrid.DataSource = context.Members.ToList();
            }
        }
    }
}
