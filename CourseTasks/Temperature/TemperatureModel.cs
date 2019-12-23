using System.Linq;
using Temperature.ScalesClasses;

namespace Temperature
{
    class TemperatureModel
    {
        private IScale[] TemperatureScalesList { get; }

        public TemperatureModel(double initialTemperature) => TemperatureScalesList = new IScale[]
            {
                new Celsius(initialTemperature),
                new Farenheit(initialTemperature),
                new Kelvin(initialTemperature)
            };

        public string[] PrintScalesNames() => TemperatureScalesList.Select(x => x.PrintScaleName()).ToArray();

        public double ConvertTemperature(int initialScaleValue, int resultScaleValue)
        {
            return ConverterFromCelsius(ConverterToCelsius(initialScaleValue), resultScaleValue);
        }

        private double ConverterFromCelsius(double initialTemperature, int resultScaleValue)
        {
            var temperatureArray = new TemperatureModel(initialTemperature);
            return temperatureArray.TemperatureScalesList.Select(x => x.ConvertTemperatureFromCelsius()).ToArray()[resultScaleValue];
        }

        private double ConverterToCelsius(int initialScaleValue) =>
            TemperatureScalesList.Select(x => x.ConvertTemperatureToCelsius()).ToArray()[initialScaleValue];
    }
}
