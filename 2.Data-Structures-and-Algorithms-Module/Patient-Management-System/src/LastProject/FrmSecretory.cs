using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LastProject
{
    public partial class FrmSecretory : Form
    {
        public FrmSecretory()
        {
            InitializeComponent();
        }

        LinkedList<string> ptQueueNorm = new LinkedList<string>();
        LinkedList<string> ptQueueEm = new LinkedList<string>();

        int countNorm = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (String.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                errorProvider1.SetError(txtFirstname, "نام بیمار را وارد کنید");
            }
            else if (String.IsNullOrWhiteSpace(txtLastname.Text))
            {
                errorProvider1.SetError(txtLastname, "نام خانوادگی بیمار را وارد کنید");
            }
            else if (!(radEmergency.Checked) && !(radNormal.Checked))
            {
                errorProvider1.SetError(gpState, "وضعیت بیمار را مشخص کنید");
            }
            else if (radEmergency.Checked && (!radEmergency1.Checked && !radEmergency2.Checked))
            {
                errorProvider1.SetError(gpEmergencyType, "نوع اورژانسی بودن بیمار را مشخص کنید");
            }
            else if (cmbDoctorsList.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbDoctorsList, "پزشک مورد نظر را انتخاب کنید");
            }

            else
            {
                if (radNormal.Checked)
                {
                    ptQueueNorm.AddLast($"{txtFirstname.Text} {txtLastname.Text}");
                    lboxNormal.Items.Add(ptQueueNorm.ElementAt(countNorm));
                    countNorm++;
                }
                else
                {
                    if (radEmergency1.Checked)
                    {
                        ptQueueEm.AddFirst($"{txtFirstname.Text} {txtLastname.Text}");
                    }
                    else
                    {
                        ptQueueEm.AddLast($"{txtFirstname.Text} {txtLastname.Text}");
                    }

                    Print();
                }

                string selectedDoctor = "";

                StreamReader doctorReader = new StreamReader("login.txt");

                string currentLine = doctorReader.ReadLine();

                while (currentLine != null)
                {

                    string[] temp = currentLine.Split('|');

                    if (temp[0] == cmbDoctorsList.SelectedItem.ToString())
                    {
                        selectedDoctor = temp[2];
                    }

                    currentLine = doctorReader.ReadLine();
                }

                doctorReader.Close();

                if (File.Exists($"{selectedDoctor}.txt"))
                {
                    File.Delete($"{selectedDoctor}.txt");
                }

                StreamWriter sw = new StreamWriter($"{selectedDoctor}.txt", true);

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

                txtFirstname.Clear();
                txtLastname.Clear();
                radEmergency.Checked = false;
                radNormal.Checked = false;
                radEmergency1.Checked = false;
                radEmergency2.Checked = false;

                gpEmergencyType.Visible = false;
            }

            void Print()
            {
                lboxEmergency.Items.Clear();
                foreach (var item in ptQueueEm)
                {
                    lboxEmergency.Items.Add(item);
                }
            }

        }

        private void radEmergency_CheckedChanged(object sender, EventArgs e)
        {
            gpEmergencyType.Visible = true;
        }
        private void radNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (gpEmergencyType.Visible)
            {
                gpEmergencyType.Visible = false;
            }
        }

        private void FrmSecretory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cmbDoctorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxEmergency.Items.Clear();
            lboxNormal.Items.Clear();

            ptQueueEm.Clear();
            ptQueueNorm.Clear();

            StreamReader doctorReader = new StreamReader("login.txt");
            string currentLine = doctorReader.ReadLine();
            while (currentLine != null)
            {
                string[] temp = currentLine.Split('|');

                if (temp[0] == cmbDoctorsList.SelectedItem.ToString())
                {
                    if (File.Exists($"{temp[2]}.txt"))
                    {
                        StreamReader sr = new StreamReader($"{temp[2]}.txt");
                        string current = sr.ReadLine();

                        bool isEmergency = false;

                        while (current != null)
                        {
                            if (current != "***")
                            {
                                isEmergency = true;
                            }
                            else
                            {
                                isEmergency = false;
                                current = sr.ReadLine();
                            }

                            if (current == null)
                            {
                                break;
                            }

                            if (isEmergency)
                            {
                                ptQueueEm.AddFirst(current);
                                lboxEmergency.Items.Add(current);
                            }
                            else
                            {
                                ptQueueNorm.AddLast(current);
                                lboxNormal.Items.Add(current);
                            }
                            current = sr.ReadLine();
                        }
                        sr.Close();
                        break;
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    currentLine = doctorReader.ReadLine();
                }



            }

            doctorReader.Close();

        }

        private void FrmSecretory_Load(object sender, EventArgs e)
        {
            lblUsername.Text = FrmLogin.LoggedInSecrotoryName;

            List<string> DoctorsList = new List<string>();

            StreamReader sr = new StreamReader("login.txt");
            string currentLine = sr.ReadLine();
            while (currentLine != null)
            {
                string[] temp = currentLine.Split('|');

                if (temp[2] == FrmLogin.LoggedInSecrotoryName)
                {
                    for (int i = 4; i < temp.Length; i++)
                    {
                        DoctorsList.Add(temp[i]);
                    }
                }
                currentLine = sr.ReadLine();
            }
            sr.Close();

            StreamReader doctorReader = new StreamReader("login.txt");
            string line = doctorReader.ReadLine();
            while (line != null)
            {
                string[] tmp = line.Split('|');
                if (DoctorsList.Contains(tmp[2]))
                {
                    cmbDoctorsList.Items.Add(tmp[0]);
                }
                line = doctorReader.ReadLine();
            }
            doctorReader.Close();
        }
    }
}
