using System;
using System.IO;
using System.Windows.Forms;

namespace LastProject
{
    public partial class FrmDoctor : Form
    {
        public FrmDoctor()
        {
            InitializeComponent();
        }

        private void btnPaitentEnterance_Click(object sender, EventArgs e)
        {
            if (lboxEmergency.Items.Count != 0)
            {
                lboxEmergency.Items.RemoveAt(0);
            }
            else if (lboxNormal.Items.Count != 0)
            {
                lboxNormal.Items.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("هیچ بیماری در صف انتظار نمی باشد");
            }

        }

        private void FrmDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmDoctor_Load(object sender, EventArgs e)
        {
            lblUsername.Text = FrmLogin.DoctorName;

            StreamReader doctorReader = new StreamReader($"{FrmLogin.DoctorName}.txt");
            string currentLine = doctorReader.ReadLine();
            bool isEmergency = false;
            while (currentLine != null)
            {
                if (currentLine != "***")
                {
                    isEmergency = true;
                }
                else
                {
                    isEmergency = false;
                    currentLine = doctorReader.ReadLine();
                }
                if (currentLine == null)
                {
                    break;
                }
                if (isEmergency)
                {
                    lboxEmergency.Items.Add(currentLine);
                }
                else
                {
                    lboxNormal.Items.Add(currentLine);
                }
                currentLine = doctorReader.ReadLine();
            }
            doctorReader.Close();
        }

        private void FrmDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {

            StreamWriter sw = new StreamWriter($"{FrmLogin.DoctorName}.txt");
            foreach (var item in lboxEmergency.Items)
            {
                sw.WriteLine(item);
            }
            sw.WriteLine("***");
            foreach (var item in lboxNormal.Items)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }
    }
}
