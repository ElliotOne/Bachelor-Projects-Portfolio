using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGetFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = null;
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = "d:\\";
                    dialog.Filter = "txt files (*.txt)|*.txt";
                    dialog.RestoreDirectory = true;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        path = dialog.FileName;
                    }
                }

                if (path != null)
                {
                    rchInput.Clear();
                    rchInput.Text = File.ReadAllText(path);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.");
            }
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            var str = rchInput.Text;
            if (!String.IsNullOrWhiteSpace(str))
            {
                Scanner.MapData();
                rchResult.Text = new Scanner().Result(str);
            }
            else
            {
                MessageBox.Show("ابتدا کدها را وارد کنید");
            }
        }
    }
}
