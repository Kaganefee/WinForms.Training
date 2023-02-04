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
    public partial class FrmKacanButon : Form
    {
        public FrmKacanButon()
        {
            InitializeComponent();
        }

        private Random rnd = new Random();
        private void btnYakala_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnYakala_MouseMove(object sender, MouseEventArgs e)
        {
            btnYakala.Location = new Point(rnd.Next(this.ClientSize.Width-btnYakala.Width), rnd.Next(this.ClientSize.Height-btnYakala.Height));
        }
    }
}
