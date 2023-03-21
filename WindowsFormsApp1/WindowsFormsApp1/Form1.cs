using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Note", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Note"].Visible = false;
            dataGridView1.Columns["Title"].Width = dataGridView1.Width - 3;

        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtNote.Clear();

        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            
            

            if (dataGridView1.Rows.Count < 1 ) 
            {
                table.Rows.Add(txtTitle.Text, txtNote.Text);
            }
            else
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (table.Rows[index]["Title"].ToString() == txtTitle.Text)
                {
                    table.Rows.Remove(table.Rows[index]);
                    table.Rows.Add(txtTitle.Text, txtNote.Text);
                }
                else
                {
                    table.Rows.Add(txtTitle.Text, txtNote.Text);
                }
            }
            

            

            txtTitle.Clear();
            txtNote.Clear();
        }

        private void bttLoad_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;   
            
            if (index > -1)
            {
                txtTitle.Text = table.Rows[index]["Title"].ToString();
                txtNote.Text = table.Rows[index]["Note"].ToString();
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }
    }
}
