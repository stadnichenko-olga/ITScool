using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class FormTemperature : Form
    {
        private double initialT;

        private int initalScale;

        private int resultScale;

        private TemperatureModel temperatureModel = new TemperatureModel();

        private string inputErrors = "";

        public FormTemperature()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (initalScale * resultScale == 0)
            {
                inputErrors += "Invalid temperature scale.";
            }

            if (inputErrors.Length != 0)
            {
                MessageBox.Show(inputErrors);
                boxResultTemperature.Text = "";
                inputErrors = "";
            }
            else
            {
                boxResultTemperature.Text = new TemperatureModel(initialT, initalScale, resultScale).resultT.ToString("F3");
            }
        }

        private void comboBoxInitialScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            initalScale = comboBoxInitialScale.SelectedIndex + 1;
        }

        private void comboBoxInitialScale_DropDown(object sender, EventArgs e)
        {
            comboBoxInitialScale.Items.Clear();
            comboBoxInitialScale.Items.AddRange(temperatureModel.TemperatureScalesList);
        }

        private void comboBoxResultScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultScale = comboBoxResultScale.SelectedIndex + 1;
        }

        private void comboBoxResultScale_DropDown(object sender, EventArgs e)
        {
            comboBoxResultScale.Items.Clear();
            comboBoxResultScale.Items.AddRange(temperatureModel.TemperatureScalesList);
        }

        private void boxInitialTemperature_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(boxInitialTemperature.Text, out initialT))
            {
                inputErrors += "Invalid value of temperature. \n";
            }
        }
    }
}
