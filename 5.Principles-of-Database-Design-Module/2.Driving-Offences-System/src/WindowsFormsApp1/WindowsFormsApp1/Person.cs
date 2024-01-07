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
    public partial class Person : Form
    {
        private PersonTable table = new PersonTable();
        public Person()
        {
            InitializeComponent();
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                MessageBox.Show("Please insert all values");
            }
            else
            {
                table.Create(txtId.Text, txtFirstname.Text, txtLastname.Text);
                ClearInputs();

                UpdateTable();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHiddenId.Text))
            {
                MessageBox.Show("Please select an item from grid view.");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstname.Text) ||
                    string.IsNullOrWhiteSpace(txtLastname.Text))
                {
                    MessageBox.Show("Please insert all values");
                }
                else
                {
                    table.Update(txtId.Text, txtFirstname.Text, txtLastname.Text);

                    dataGridView1.ClearSelection();

                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    ClearInputs();

                    UpdateTable();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHiddenId.Text))
            {
                MessageBox.Show("Please select an item from grid view.");
            }
            else
            {
                table.Delete(txtId.Text);

                dataGridView1.ClearSelection();

                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

                ClearInputs();

                UpdateTable();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHiddenId.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            txtId.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtFirstname.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtLastname.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void Person_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            List<DB.Person> boats = table.ReadAll();


            foreach (var item in boats)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["Id"].Value = item.Id;
                row.Cells["Firstname"].Value = item.Firstname;
                row.Cells["Lastname"].Value = item.Lastname;
            }
        }
    }
}
