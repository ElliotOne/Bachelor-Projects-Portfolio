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
    public partial class Offense : Form
    {
        private OffenseTable table = new OffenseTable();
        public Offense()
        {
            InitializeComponent();
        }
        private void ClearInputs()
        {
            txtType.Clear();
            txtPrice.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbPerson.SelectedIndex <= -1 ||
                cmbCar.SelectedIndex <= -1)
            {
                MessageBox.Show("Please insert all values");
            }
            else
            {
                dynamic personId = cmbPerson.Items[cmbPerson.SelectedIndex];
                dynamic carCode = cmbCar.Items[cmbCar.SelectedIndex];
                table.Create(personId.Value, carCode.Value, DateTime.Now, txtType.Text, double.Parse(txtPrice.Text));
                ClearInputs();

                UpdateTable();
            }
        }

        private void Offense_Load(object sender, EventArgs e)
        {
            PersonTable personTable = new PersonTable();
            List<DB.Person> persons = personTable.ReadAll();
            cmbPerson.DisplayMember = "Text";
            cmbPerson.ValueMember = "Value";


            foreach (var item in persons)
            {
                cmbPerson.Items.Add(new { Text = item.Firstname + " " + item.Lastname, Value = item.Id });
            }


            CarTable carTable = new CarTable();
            List<DB.Car> cars = carTable.ReadAllCars();
            cmbCar.DisplayMember = "Text";
            cmbCar.ValueMember = "Value";


            foreach (var item in cars)
            {
                cmbCar.Items.Add(new { Text = item.CarCode, Value = item.CarCode });
            }



            UpdateTable();
        }
        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();

            List<OffenseWithDetails> personWithCars = table.ReadAll();


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
                row.Cells["PersonLastname"].Value = item.Lastname;
                row.Cells["Price"].Value = item.Price;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
