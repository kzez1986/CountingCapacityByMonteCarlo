using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonteCarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public double WyznaczanieSześcianu()
        {
            double r = double.Parse(textBox1.Text);
            return r * 2;
        }

        public bool CzyNależyDoKuli(double x, double y, double z)
        {
            double prawa = double.Parse(textBox1.Text) * double.Parse(textBox1.Text);
            double lewa = x * x + y * y + z * z;
            if (lewa <= prawa) return true;
            else return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double promień = double.Parse(textBox1.Text);
            listBox1.Items.Add("Powinno wyjść: " + 4.0/3.0 * Math.PI * promień * promień * promień);
            double krawędź_sześcianu = WyznaczanieSześcianu();
            long ilość_dobrych = 0;
            long ilość_wszystkich = 0;
            Random los = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double x = los.NextDouble() * krawędź_sześcianu - 1;
                double y = los.NextDouble() * krawędź_sześcianu - 1;
                double z = los.NextDouble() * krawędź_sześcianu - 1;
                if (CzyNależyDoKuli(x, y, z))
                    ilość_dobrych++;
                //ilość_wszystkich++;
            }
            double objętoś_sześcianu = krawędź_sześcianu * krawędź_sześcianu * krawędź_sześcianu;
            double objętość = (double)ilość_dobrych / 10000.0 * objętoś_sześcianu;
            listBox1.Items.Add(objętość.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double krawędź = double.Parse(textBox1.Text);
            listBox1.Items.Add("Powinno wyjść: " + krawędź * krawędź * krawędź * 0.5);
            //krawędź sześcianu = krawędź
            Random los = new Random();
            int ile_operacji = 1000000;
            long ilość_dobrych = 0;
            for (int i = 0; i < ile_operacji; i++)
            {
                double x = los.NextDouble() * krawędź;
                double z = los.NextDouble() * krawędź;
                if (CzyNależyDoSześcianu(x, z, krawędź))
                    ilość_dobrych++;
            }
            double objętość_sześcianu = krawędź * krawędź * krawędź;
            double objętość = (double)ilość_dobrych / (double)ile_operacji * objętość_sześcianu;
            listBox1.Items.Add(objętość.ToString());
        }

        public bool CzyNależyDoSześcianu(double x, double z, double krawędź)
        {
            if (x + z <= krawędź)
                return true;
            else
                return false;
        }
    }
}
