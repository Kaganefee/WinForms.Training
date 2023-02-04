using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonsolForm.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Text = "İlk windows form uygulaması";
            form.BackColor = Color.Black;

            Button btn = new Button();
            btn.Text = "TIKLA";
            btn.BackColor = Color.White;
            btn.Width = 200;
            btn.Height = 100;
            btn.Location = new Point(50,50);

            // delege - delegate
            btn.Click += Btn_Click;
            btn.Click += Btn_Click1;
            btn.Click += Btn_Click2;

            form.Controls.Add(btn);

            form.ShowDialog();

            Console.ReadKey();
        }

        private static void Btn_Click2(object sender, EventArgs e)
        {
            MessageBox.Show("Buton tıklandı");
        }

        private static void Btn_Click1(object sender, EventArgs e)
        {
            Console.WriteLine("İkinci Event Çalıştı");
        }

        private static void Btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Merhaba WinForm !!");
        }
    }
}
