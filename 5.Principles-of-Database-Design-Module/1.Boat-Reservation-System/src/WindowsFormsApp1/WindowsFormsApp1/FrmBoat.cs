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
    public partial class FrmBoat : Form
    {
        public FrmBoat()
        {
            InitializeComponent();
        }

        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            BoatTable table = new BoatTable();
            List<Boat> boats = table.ReadAll();


            foreach (var item in boats)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["bid"].Value = item.bid;
                row.Cells["bname"].Value = item.bname;
                row.Cells["bcolor"].Value = item.bcolor;
            }
        }

        private void FrmBoat_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BoatTable table = new BoatTable();
            table.Create(textBox1.Text, textBox2.Text);
            UpdateTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("باید یک سطر از جدول را برای حذف کردن انتخاب کنید.");
            }
            else
            {
                int id = int.Parse(txtboxHiddenID.Text);

                BoatTable table = new BoatTable();
                table.Delete(id);

                UpdateTable();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxHiddenID.Text))
            {
                MessageBox.Show("باید یک سطر از جدول را برای ویرایش کردن انتخاب کنید.");
            }
            else
            {
                BoatTable table = new BoatTable();
                table.Update(int.Parse(txtboxHiddenID.Text), textBox1.Text, textBox2.Text);

                UpdateTable();


                txtboxHiddenID.Clear();
                textBox1.Clear();
                textBox2.Clear();
                dataGridView1.ClearSelection();

                btnEdit.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) && string.IsNullOrWhiteSpace(textBox4.Text))
            {
                UpdateTable();
                MessageBox.Show("حداقل یکی از دو مقدار نام یا رنگ را وارد کنید");
            }

            else
            {
                dataGridView1.Rows.Clear();

                BoatTable table = new BoatTable();
                List<Boat> boats = table.ReadLike(textBox3.Text, textBox4.Text);


                foreach (var item in boats)
                {
                    int rowId = dataGridView1.Rows.Add();


                    DataGridViewRow row = dataGridView1.Rows[rowId];

                    row.Cells["bid"].Value = item.bid;
                    row.Cells["bname"].Value = item.bname;
                    row.Cells["bcolor"].Value = item.bcolor;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtboxHiddenID.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();

            btnEdit.Enabled = true;
        }
    }
}
