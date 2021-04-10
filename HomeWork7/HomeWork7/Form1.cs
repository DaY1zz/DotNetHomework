using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7
{

    public partial class Form1 : Form
    {
        private int n = 1;
        private double leng = 1;
        private double perR = 1;
        private double perL = 1;
        private double thR = 1;
        private double thL = 1;

        private Graphics graphics;
        private Pen pen;



        public Form1()
        {
            InitializeComponent();
            pen = new Pen(button_color.BackColor);
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_color.BackColor = colorDialog1.Color;
                pen.Color = colorDialog1.Color;

            }
        } 

        private void button_color_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                this.graphics = this.panel_paint.CreateGraphics();          

            //获取用户指定的参数
            n = (int)control_n.Value;
            leng = (double)control_leng.Value;
            perR = (double)control_perR.Value;
            perL = (double)control_perL.Value;
            thR = (double)control_thR.Value * Math.PI / 180;
            thL = (double)control_thL.Value * Math.PI / 180;

            double x0 = panel_paint.Width / 2;
            double y0 = panel_paint.Height * 0.9;

            graphics.Clear(BackColor);

            drawCayleyTree(n, x0, y0, leng, -Math.PI / 2);
          

        }

        private void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, perR * leng, th + thR);
            drawCayleyTree(n - 1, x1, y1, perL * leng, th - thL);
        }

        private void drawLine(double x0, double y0, double x1, double y1) => graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);


    }
}
