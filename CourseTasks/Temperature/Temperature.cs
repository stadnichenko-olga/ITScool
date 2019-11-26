using System;
using System.Windows.Forms;

namespace Temperature
{
    static class Temperature
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTemperature());
        }

        public static double TemperatureConverter(double temperatureInitial, int scaleInitial, int scaleResult)
        {
            double[,] temperatureConverter =
                { {temperatureInitial,              temperatureInitial * 9 / 5 + 32,     temperatureInitial + 273.15},
                {(temperatureInitial - 32) * 5 / 9, temperatureInitial,                  (temperatureInitial + 459.67) * 5 / 9 },
                {temperatureInitial - 273.15,       temperatureInitial * 9 / 5 - 459.67, temperatureInitial } };

            return temperatureConverter[scaleInitial, scaleResult];
        }

        public static readonly object[] TemperatureScalesList = new object[] {
            "Celsius",
            "Fahrenheit",
            "Kelvin"};
    }
}
