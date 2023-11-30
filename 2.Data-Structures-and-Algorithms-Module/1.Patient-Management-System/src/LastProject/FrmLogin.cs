using System;
using System.IO;
using System.Windows.Forms;

namespace LastProject
{
    public partial class FrmLogin : Form
    {
        public static string DoctorName = "";
        public static string LoggedInSecrotoryName = "";
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isFound = false;
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "نام کاربری را وارد کنید");
            }
            else if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "رمز عبور را وارد کنید");
            }
            else
            {
                errorProvider1.Clear();

                try
                {
                    StreamReader sr = new StreamReader("login.txt");
                    string currentLine = sr.ReadLine();

                    while (currentLine != null)
                    {
                        string[] temp = currentLine.Split('|');
                        if (txtUsername.Text == temp[2])
                        {
                            isFound = true;

                            if (txtPassword.Text == temp[3])
                            {
                                if (temp[1] == "secretory")
                                {
                                    LoggedInSecrotoryName = temp[2];

                                    FrmSecretory secretory = new FrmSecretory();
                                    secretory.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    DoctorName = temp[2];
                                    FrmDoctor doctor = new FrmDoctor();
                                    doctor.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txtPassword, "رمز عبور نادرست می باشد");
                            }

                            break;
                        }
                        else
                        {
                            currentLine = sr.ReadLine();
                        }
                    }

                    sr.Close();

                    if (!isFound)
                    {
                        MessageBox.Show("کاربر مورد نظر یافت نشد");
                        txtUsername.Clear();
                        txtPassword.Clear();
                    }

                    sr.Close();
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }
    }
}
