using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class TemperatureModel
    {
        public double initialT;

        public double resultT;

        public int initalScale;

        public int resultScale;

        public readonly object[] TemperatureScalesList;

        public TemperatureModel() => TemperatureScalesList = new object[] { "Celsius", "Fahrenheit", "Kelvin" };

        public TemperatureModel(double initialValue, int initialScaleValue, int resultScaleValue)
        {
            initialT = initialValue;
            initalScale = initialScaleValue;
            resultScale = resultScaleValue;
            resultT = TemperatureConverterFromCelsius(TemperatureConverterToCelsius(initialValue)[initialScaleValue])[resultScaleValue];
        }

        private double[] TemperatureConverterFromCelsius(double temperatureInitial) => new double[]{temperatureInitial,
                                                                                                  temperatureInitial * 9 / 5 + 32,
                                                                                                  temperatureInitial + 273.15};

        private double[] TemperatureConverterToCelsius(double temperatureInitial) => new double[]{temperatureInitial,
                                                                                                  (temperatureInitial - 32) * 5 / 9,
                                                                                                  temperatureInitial - 273.15 };
    }
}
