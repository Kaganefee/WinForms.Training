using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Ornekler
{
    public partial class FrmHesapMakinesi : Form
    {
        private double CurrentNumber;
        private bool IslemBasladi;
        public FrmHesapMakinesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text=="." && txtMain.Text.Contains("."))
            {
                return;
            }
            else
            {
                if (txtMain.Text == "0" && btn.Text != ".")
                    txtMain.Text = btn.Text;
                else
                {
                    if (!IslemBasladi)
                    {
                        txtMain.Text += btn.Text;
                    }
                }
            }
        }

        private void btnArti_Click(object sender, EventArgs e)
        {
            if (!IslemBasladi)
            {
                IslemBasladi = true;
            }
            if (CurrentNumber!=0)
            {
                txtMain.Text = (CurrentNumber + double.Parse(txtMain.Text)).ToString();
                CurrentNumber = double.Parse(txtMain.Text);
            }
            else
            {
                CurrentNumber = double.Parse(txtMain.Text);
                txtMain.Text = "0";
            }
        }

        private void FrmHesapMakinesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnArti.PerformClick();
        }

        private void FrmHesapMakinesi_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("pressed");
        }
    }
}
