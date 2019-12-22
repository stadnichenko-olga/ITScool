using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class FormTemperature : Form
    {
        private double initialTemperature;

        private int initalScale = 0;

        private int resultScale = 0;

        private TemperatureModel temperatureModel = new TemperatureModel(0);

        public FormTemperature()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            boxResultTemperature.Text = temperatureModel.ConvertTemperature(initalScale, resultScale).ToString("F3");
        }

        private void comboBoxInitialScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            initalScale = comboBoxInitialScale.SelectedIndex;
        }


        private void comboBoxResultScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultScale = comboBoxResultScale.SelectedIndex;
        }

        private void boxInitialTemperature_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(boxInitialTemperature.Text, out initialTemperature))
            {
                MessageBox.Show("Invalid temperature value.");
                boxResultTemperature.Text = "";
            }

            temperatureModel = new TemperatureModel(initialTemperature);
        }

        private void FormTemperature_Load(object sender, EventArgs e)
        {
            comboBoxInitialScale.Items.Clear();
            comboBoxInitialScale.Items.AddRange(temperatureModel.ScalesNames());
            comboBoxInitialScale.SelectedIndex = 0;

            comboBoxResultScale.Items.Clear();
            comboBoxResultScale.Items.AddRange(temperatureModel.ScalesNames());
            comboBoxResultScale.SelectedIndex = 0;
        }
    }
}
