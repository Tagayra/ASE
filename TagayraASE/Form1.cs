using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagayraASE
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1 = new Bitmap(400, 400);
        Bitmap bitmap2 = new Bitmap(400, 400);
        Pen pen = new Pen(Color.HotPink, 2);
        Graphics g;
        
        
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap1);
            g.Clear(Color.Gray);   

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g =e.Graphics;
            g.DrawImageUnscaled(bitmap1, 0, 0);
            g.DrawImageUnscaled(bitmap2 , 0, 0);
            g.DrawEllipse(pen,10,10,10,10);

        }
    }
}
