using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Temperature
{
    public partial class FormTemperature : Form
    {
        private double initialTemperature;

        private int initalScale = 0;

        private int resultScale = 0;

        private TemperatureModel temperatureModel = new TemperatureModel();

        private string inputErrors = "";

        private bool[] inputErrorsCheckList = new bool[3];

        public FormTemperature()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {           
            if (inputErrorsCheckList[0] == false)
            {
                inputErrors += "Invalid temperature value.";
            }

            if (inputErrorsCheckList[1] == false)
            {
                inputErrors += "Invalid initial temperature scale.";
            }

            if (inputErrorsCheckList[2] == false)
            {
                inputErrors += "Invalid result temperature scale.";
            }

            if (inputErrors.Length != 0)
            {
                MessageBox.Show(inputErrors);
                boxResultTemperature.Text = "";
            }
            else
            {
                boxResultTemperature.Text = TemperatureModel.ConvertTemperature(initialTemperature, initalScale - 1, resultScale - 1).ToString("F3");
            }

            inputErrors = "";
        }

        private void comboBoxInitialScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            initalScale = comboBoxInitialScale.SelectedIndex + 1;

            if (initalScale != 0)
            {
                inputErrorsCheckList[1] = true;
            }
        }

        private void comboBoxInitialScale_DropDown(object sender, EventArgs e)
        {
            comboBoxInitialScale.Items.Clear();
            comboBoxInitialScale.Items.AddRange(temperatureModel.TemperatureScalesList);
            inputErrorsCheckList[1] = false;
        }

        private void comboBoxResultScale_SelectedIndexChanged(object sender, EventArgs e)
        {            
            resultScale = comboBoxResultScale.SelectedIndex + 1;

            if (resultScale != 0)
            {
                inputErrorsCheckList[2] = true;
            }
        }

        private void comboBoxResultScale_DropDown(object sender, EventArgs e)
        {
            comboBoxResultScale.Items.Clear();
            comboBoxResultScale.Items.AddRange(temperatureModel.TemperatureScalesList);
            inputErrorsCheckList[2] = false;
        }

        private void boxInitialTemperature_TextChanged(object sender, EventArgs e)
        {
            inputErrorsCheckList[0] = double.TryParse(boxInitialTemperature.Text, out initialTemperature);
        }
    }
}
