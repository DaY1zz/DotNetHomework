using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Winform
{
    public partial class Form1 : Form
    {
        private double a = 0;
        private double b = 0;
        private int operate = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operate = 1;
            operate_label.Text = "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operate = 2;
            operate_label.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operate = 3;
            operate_label.Text = "*";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operate = 4;
            operate_label.Text = "/";

        }

        private void op2_box_TextChanged(object sender, EventArgs e)
        {
            if(op2_box.Text!="")
                b = Double.Parse(op2_box.Text);
        }

        private void op1_box_TextChanged(object sender, EventArgs e)
        {
            if(op1_box.Text!="")
                a = Double.Parse(op1_box.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (operate)
            {
                case 1: 
                    result.Text = (a + b).ToString();
                    break;
                case 2:
                    result.Text = (a - b).ToString();
                    break;
                case 3:
                    result.Text = (a * b).ToString();
                    break;
                case 4:
                    if (b == 0)
                        result.Text = "Error!";
                    else
                        result.Text = (a / b).ToString();
                    break;
            }

        }
    }
}
