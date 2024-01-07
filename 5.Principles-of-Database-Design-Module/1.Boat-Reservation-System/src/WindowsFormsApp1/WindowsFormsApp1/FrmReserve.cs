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
    public partial class FrmReserve : Form
    {
        public FrmReserve()
        {
            InitializeComponent();
        }

        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            ReserveTable table = new ReserveTable();
            List<Reserve> reserves = table.ReadAll();


            foreach (var item in reserves)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["rid"].Value = item.rid;
                row.Cells["sname"].Value = item.sname;
                row.Cells["bname"].Value = item.bname;
                row.Cells["sid"].Value = item.sid;
                row.Cells["bid"].Value = item.bid;
                row.Cells["rdate"].Value = item.rdate;
            }
        }
        private void FrmReserve_Load(object sender, EventArgs e)
        {
            //Get All Sailors
            SailorTable sailorTable = new SailorTable();
            List<Sailor> sailors = sailorTable.ReadAll();
            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            foreach (var item in sailors)
            {
                comboBox2.Items.Add(new { Text = item.sname, Value = item.sid });
            }


            //Get All Boats
            BoatTable boatTable = new BoatTable();
            List<Boat> boats = boatTable.ReadAll();
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            foreach (var item in boats)
            {
                comboBox1.Items.Add(new { Text = item.bname, Value = item.bid });

            }


            UpdateTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("نام قایق را انتخاب کنید");
            }
            else if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("نام قایقران را انتخاب کنید");
            }
            else
            {
                ReserveTable table = new ReserveTable();


                dynamic bid = comboBox1.Items[comboBox1.SelectedIndex];
                dynamic sid = comboBox2.Items[comboBox2.SelectedIndex];

                table.Create(sid.Value, bid.Value, dateTimePicker1.Value);

                UpdateTable();
            }
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

                ReserveTable table = new ReserveTable();
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
                ReserveTable table = new ReserveTable();

                dynamic bid = comboBox1.Items[comboBox1.SelectedIndex];
                dynamic sid = comboBox2.Items[comboBox2.SelectedIndex];

                table.Update(int.Parse(txtboxHiddenID.Text), sid.Value, bid.Value, dateTimePicker1.Value);

                UpdateTable();


                txtboxHiddenID.Clear();
                txtboxHiddenBID.Clear();
                txtboxHiddenSID.Clear();

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;

                dataGridView1.ClearSelection();

                btnEdit.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            //btnsearchbydate_click
            dataGridView1.Rows.Clear();


            ReserveTable table = new ReserveTable();
            List<Reserve> reserves;

            reserves = table.ReadLike(dateTimePicker2.Value);

            foreach (var item in reserves)
            {
                int rowid = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowid];

                row.Cells["rid"].Value = item.rid;
                row.Cells["bid"].Value = item.bid;
                row.Cells["sid"].Value = item.sid;
                row.Cells["bname"].Value= item.bname;
                row.Cells["sname"].Value = item.sname;
                row.Cells["rdate"].Value = item.rdate;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtboxHiddenID.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            txtboxHiddenSID.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtboxHiddenBID.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();

            dateTimePicker1.Value = DateTime.Parse(dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString());


            int selectedBoatIndex = 0;
            int countBoat = comboBox1.Items.Count;

            for (int i = 0; i <= (countBoat - 1); i++)
            {
                comboBox1.SelectedIndex = i;
                dynamic id = comboBox1.Items[comboBox1.SelectedIndex];
                if (id.Value == int.Parse(txtboxHiddenBID.Text))
                {
                    selectedBoatIndex = i;
                    break;
                }



            }
            comboBox1.SelectedIndex = selectedBoatIndex;




            int selectedSailorIndex = 0;
            int countSailor = comboBox2.Items.Count;

            for (int i = 0; i <= (countSailor - 1); i++)
            {
                comboBox2.SelectedIndex = i;
                dynamic id = comboBox2.Items[comboBox2.SelectedIndex];
                if (id.Value == int.Parse(txtboxHiddenSID.Text))
                {
                    selectedSailorIndex = i;
                    break;
                }



            }
            comboBox2.SelectedIndex = selectedSailorIndex;


            btnEdit.Enabled = true;
        }
    }
}
