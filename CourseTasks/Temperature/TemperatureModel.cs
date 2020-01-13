using System.Linq;
using Temperature.ScalesClasses;

namespace Temperature
{
    class TemperatureModel
    {
        private readonly IScale[] temperatureScalesList = 
            {
                new Celsius(),
                new Farenheit(),
                new Kelvin()
            };

        public string[] GetScalesNames() => temperatureScalesList.Select(x => x.GetScaleName()).ToArray();

        private double ConvertToCelsius(double initialTemperature, int initialScaleIndex) =>
            temperatureScalesList[initialScaleIndex].ConvertTemperatureToCelsius(initialTemperature);

        private double ConvertFromCelsius(double initialTemperature, int resultScaleIndex) =>
            temperatureScalesList[resultScaleIndex].ConvertTemperatureFromCelsius(initialTemperature);

        public double ConvertTemperature(double initialTemperature, int initialScaleIndex, int resultScaleIndex) =>
            ConvertFromCelsius(ConvertToCelsius(initialTemperature, initialScaleIndex), resultScaleIndex);
    }
}
