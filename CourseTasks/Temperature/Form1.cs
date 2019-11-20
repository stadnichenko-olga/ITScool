using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double temperatureInitial;

            var scaleInitial = comboBox1.SelectedIndex;
            var scaleResult = comboBox2.SelectedIndex;

            if (double.TryParse(textBox1.Text, out temperatureInitial))
            {
                textBox2.Text = $"{TemperatureConverter(temperatureInitial, scaleInitial, scaleResult)}";
            }
            else
            {
                MessageBox.Show("Invalid value of temperature.");
                textBox2.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private double TemperatureConverter(double temperatureInitial, int scaleInitial, int scaleResult)
        {



            if (scaleInitial == 0)
            {
                if (scaleResult == 1)
                {
                    return temperatureInitial * 9 / 5 + 32;
                }
                if (scaleResult == 2)
                {
                    return temperatureInitial + 273.15;
                }
            }
            if (scaleInitial == 1)
            {
                if (scaleResult == 0)
                {
                    return (temperatureInitial - 32) * 5 / 9;
                }
                if (scaleResult == 2)
                {
                    return (temperatureInitial + 459.67) * 5 / 9;
                }
            }
            if (scaleInitial == 2)
            {
                if (scaleResult == 0)
                {
                    return temperatureInitial - 273.15;
                }
                if (scaleResult == 1)
                {
                    return temperatureInitial * 9 / 5 - 459.67;
                }
            }

            return temperatureInitial;

        }
    }
}
