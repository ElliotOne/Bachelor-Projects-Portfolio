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
    public partial class Car : Form
    {
        private CarTable table = new CarTable();
        public Car()
        {
            InitializeComponent();
        }

        private void ClearInputs()
        {
            txtCarCode.Clear();
            txtType.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarCode.Text) ||
                string.IsNullOrWhiteSpace(txtType.Text) ||
                cmbPerson.SelectedIndex <= -1)
            {
                MessageBox.Show("Please insert all values");
            }
            else
            {
                dynamic personId = cmbPerson.Items[cmbPerson.SelectedIndex];
                table.Create(txtCarCode.Text, txtType.Text, dateTimePicker1.Value, personId.Value);
                ClearInputs();

                UpdateTable();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHiddenId.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            txtCarCode.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtType.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());

            string selectedValue = txtCarCode.Text;

            int selectedIndex = 0;
            int count = cmbPerson.Items.Count;

            for (int i = 0; i <= (count - 1); i++)
            {
                cmbPerson.SelectedIndex = i;
                dynamic id = cmbPerson.Items[cmbPerson.SelectedIndex];
                if (id.Value == selectedValue)
                {
                    selectedIndex = i;
                    break;
                }



            }
            cmbPerson.SelectedIndex = selectedIndex;


            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
        }

        private void Car_Load(object sender, EventArgs e)
        {
            PersonTable personTable = new PersonTable();
            List<DB.Person> persons = personTable.ReadAll();
            cmbPerson.DisplayMember = "Text";
            cmbPerson.ValueMember = "Value";


            foreach (var item in persons)
            {
                cmbPerson.Items.Add(new { Text = item.Firstname + " " + item.Lastname , Value = item.Id });
            }



            UpdateTable();
        }

        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            List<PersonWithCars> personWithCars = table.ReadAll();


            foreach (var item in personWithCars)
            {
                int rowId = dataGridView1.Rows.Add();


                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells["CarCode"].Value = item.CarCode;
                row.Cells["Type"].Value = item.Type;
                row.Cells["CreateDate"].Value = item.CreateDate;
                row.Cells["PersonId"].Value = item.PersonId;
                row.Cells["PersonFirstname"].Value = item.Firstname;
                row.Cells["PersonLastname"].Value = item.Lastname;
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHiddenId.Text))
            {
                MessageBox.Show("Please select an item from grid view.");
            }
            else
            {
                table.Delete(txtHiddenId.Text);

                dataGridView1.ClearSelection();

                btnAdd.Enabled = true;
                btnDelete.Enabled = false;

                ClearInputs();

                UpdateTable();
            }
        }
    }
}
