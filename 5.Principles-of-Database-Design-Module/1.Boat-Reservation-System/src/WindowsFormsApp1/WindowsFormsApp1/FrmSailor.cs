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
    public partial class FrmSailor : Form
    {
        public FrmSailor()
        {
            InitializeComponent();
        }

        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            SailorTable table = new SailorTable();
            List<Sailor> sailors = table.ReadAll();


            foreach (var item in sailors)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["sid"].Value = item.sid;
                row.Cells["sname"].Value = item.sname;
                row.Cells["srate"].Value = item.srate;
                row.Cells["sage"].Value = item.sage;
            }
        }
        private void FrmSailor_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SailorTable table = new SailorTable();
            table.Create(textBox1.Text, (int)numericUpDown1.Value,(int)numericUpDown2.Value);
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

                SailorTable table = new SailorTable();
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
                SailorTable table = new SailorTable();
                table.Update(int.Parse(txtboxHiddenID.Text), textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown1.Value);

                UpdateTable();


                txtboxHiddenID.Clear();
                textBox1.Clear();
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;

                dataGridView1.ClearSelection();

                btnEdit.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            SailorTable table = new SailorTable();
            List<Sailor> sailors = table.ReadLike(textBox2.Text);


            foreach (var item in sailors)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["sid"].Value = item.sid;
                row.Cells["sname"].Value = item.sname;
                row.Cells["srate"].Value = item.srate;
                row.Cells["sage"].Value = item.sage;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtboxHiddenID.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            numericUpDown1.Value = decimal.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
            numericUpDown2.Value = decimal.Parse(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString());

            btnEdit.Enabled = true;
        }
    }
}
