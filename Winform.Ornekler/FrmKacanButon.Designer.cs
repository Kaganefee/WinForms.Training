
namespace Winform.Ornekler
{
    partial class FrmKacanButon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnYakala = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYakala
            // 
            this.btnYakala.Location = new System.Drawing.Point(274, 171);
            this.btnYakala.Name = "btnYakala";
            this.btnYakala.Size = new System.Drawing.Size(115, 42);
            this.btnYakala.TabIndex = 0;
            this.btnYakala.Text = "Yakala";
            this.btnYakala.UseVisualStyleBackColor = true;
            this.btnYakala.MouseHover += new System.EventHandler(this.btnYakala_MouseHover);
            this.btnYakala.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnYakala_MouseMove);
            // 
            // FrmKacanButon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 433);
            this.Controls.Add(this.btnYakala);
            this.Name = "FrmKacanButon";
            this.Text = "Sıkıysa Yakala";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYakala;
    }
}