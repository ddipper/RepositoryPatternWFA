using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepositoryPatternWFA.Models;
using RepositoryPatternWFA.Repository.ItemsRepository;

namespace RepositoryPatternWFA
{
    public partial class Form1 : Form
    {
        int updId = 2;

        MySqlItemsRepository rep = new MySqlItemsRepository("localhost", "test_db", "root", "root");


        public Form1()
        {
            InitializeComponent();
            Refresh();
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) )
            {
                update_btn.Enabled = false;
                insert_btn.Enabled = false;
            }
            else
            {
                update_btn.Enabled = true;
                insert_btn.Enabled = true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // проверяем, что клик произошел по ячейке с данными
            {
                updId = e.RowIndex + 1;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                update_btn.Enabled = true;
            }
        }
        public void Refresh()
        {
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = rep.GetAll();
        }

        private void read_btn_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            int rowsAffected = 0;
            string name = textBox1.Text;
            int price = int.Parse(textBox2.Text);
            rowsAffected = rep.Insert(new Items { Name = name, Price = price });
            MessageBox.Show($"Rows Affected {rowsAffected}");
            Refresh();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{updId}");
            rep.Update(updId, new Items { Name = textBox1.Text, Price = int.Parse(textBox2.Text) });
            Refresh();
        }
    }
}
