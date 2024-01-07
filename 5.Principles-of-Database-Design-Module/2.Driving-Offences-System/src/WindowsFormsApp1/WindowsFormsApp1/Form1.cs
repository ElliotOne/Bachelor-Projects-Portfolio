using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SearchTable table = new SearchTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person frm = new Person();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Car frm = new Car();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Offense frm = new Offense();
            frm.ShowDialog();
        }

        private void btnSearchByPerson_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            List<SearchResult> results = table.Search1(txtPersonId_1.Text);

            foreach (var item in results)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["PriceSum"].Value = item.PriceSum;
                row.Cells["CarCode"].Value = item.CarCode;
                row.Cells["PersonId"].Value = item.PersonId;
            }
        }

        private void btnSearchByPersonAndDates_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            List<SearchResult> results = table.Search2(txtPersonId_2.Text, dateTimePicker1.Value);

            foreach (var item in results)
            {
                int rowId = dataGridView2.Rows.Add();


                DataGridViewRow row = dataGridView2.Rows[rowId];

                row.Cells["PersonId_2"].Value = item.PersonId;
                row.Cells["CarCode_2"].Value = item.CarCode;
                row.Cells["CreateDate"].Value = item.CreateDate;
            }
        }

        private void btnSearchByPersonAndCarCode_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();

            List<SearchResult> results = table.Search3(txtCardCode.Text);

            foreach (var item in results)
            {
                int rowId = dataGridView3.Rows.Add();


                DataGridViewRow row = dataGridView3.Rows[rowId];

                row.Cells["CarCode_3"].Value = item.CarCode;
                row.Cells["PriceSum_2"].Value = item.PriceSum;
                row.Cells["PersonId_1"].Value = item.PersonId;
                row.Cells["Firstname"].Value = item.Firstname;
                row.Cells["Lastname"].Value = item.Lastname;
            }
        }
    }
}
