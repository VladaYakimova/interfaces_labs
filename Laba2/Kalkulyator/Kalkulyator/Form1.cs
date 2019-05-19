using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulyator
{
    public partial class Калькулятор : Form
    {
        double dija = 0;
        string old;
        double vidp;
        public Калькулятор()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dija = 1;
            old = textBox1.Text;
            textBox1.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dija = 2;
            old = textBox1.Text;
            textBox1.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dija = 3;
            old = textBox1.Text;
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dija = 4;
            old = textBox1.Text;
            textBox1.Text = "";
        }
        
        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            double vidp1 = Math.Sqrt(Convert.ToDouble(textBox1.Text));
            textBox1.Text = Convert.ToString(vidp1);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            dija = 5;
            old = textBox1.Text;
            textBox1.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (dija == 1)
            {
                vidp = (Convert.ToDouble(old) + Convert.ToDouble(textBox1.Text));
                textBox1.Text = Convert.ToString(vidp);
            }

            if (dija == 2)
            {
                vidp = (Convert.ToDouble(old) - Convert.ToDouble(textBox1.Text));
                textBox1.Text = Convert.ToString(vidp);
            }

            if (dija == 3)
            {
                try
                {
                    vidp = (Convert.ToDouble(old) / Convert.ToDouble(textBox1.Text));
                    textBox1.Text = Convert.ToString(vidp);
                } catch 
                {
                    textBox1.Text = "";
                }
            }

            if (dija == 4)
            {
                vidp = (Convert.ToDouble(old) * Convert.ToDouble(textBox1.Text));
                textBox1.Text = Convert.ToString(vidp);
            }

            if (dija == 5)
            {
                vidp = Math.Pow(Convert.ToDouble(old), Convert.ToDouble(textBox1.Text));
                textBox1.Text = Convert.ToString(vidp);
            }

            
        }


    }
}
