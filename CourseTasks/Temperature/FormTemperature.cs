using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class FormTemperature : Form
    {
        private double initialTemperature;

        private int initalScale;

        private int resultScale;

        public FormTemperature()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            boxResultTemperature.Text = Temperature.TemperatureConverter(initialTemperature, initalScale, resultScale).ToString("##.###;##.###");
        }

        private void comboBoxInitialScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInitialScale.SelectedItem.ToString().Length > 0)
            {
                initalScale = comboBoxInitialScale.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Invalid initial temperature scale.");
                boxResultTemperature.Text = "";
            }
        }

        private void comboBoxInitialScale_DropDown(object sender, EventArgs e)
        {
            comboBoxInitialScale.Items.AddRange(Temperature.TemperatureScalesList);
        }

        private void comboBoxResultScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxResultScale.SelectedItem.ToString().Length > 0)
            {
                resultScale = comboBoxResultScale.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Invalid result temperature scale.");
                boxResultTemperature.Text = "";
            }
        }

        private void comboBoxResultScale_DropDown(object sender, EventArgs e)
        {
            comboBoxResultScale.Items.AddRange(Temperature.TemperatureScalesList);
        }

        private void boxInitialTemperature_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(boxInitialTemperature.Text, out initialTemperature))
            {
                MessageBox.Show("Invalid value of temperature.");
                boxResultTemperature.Text = "";
            }
        }
    }
}
