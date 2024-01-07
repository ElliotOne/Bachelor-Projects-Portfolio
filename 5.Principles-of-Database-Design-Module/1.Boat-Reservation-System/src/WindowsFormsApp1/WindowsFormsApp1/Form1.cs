using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFrmBoat_Click(object sender, EventArgs e)
        {
            FrmBoat frm = new FrmBoat();
            frm.ShowDialog();
        }

        private void btnFrmSailor_Click(object sender, EventArgs e)
        {
            FrmSailor frm = new FrmSailor();
            frm.ShowDialog();
        }

        private void btnFrmReserve_Click(object sender, EventArgs e)
        {
            FrmReserve frm = new FrmReserve();
            frm.ShowDialog();
        }
    }
}
