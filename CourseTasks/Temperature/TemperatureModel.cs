using Temperature.ScalesClasses;

namespace Temperature
{
    class TemperatureModel
    {
        private readonly IScale[] temperatureScalesList = new IScale[]
            {
                new Celsius(),
                new Farenheit(),
                new Kelvin()
            };

        public string[] GetScalesNames()
        {
            var scalesNames = new string[temperatureScalesList.Length];

            for (int i = 0; i < temperatureScalesList.Length; i++)
            {
                scalesNames[i] = temperatureScalesList[i].GetScaleName();
            }

            return scalesNames;
        }

        private double ConvertToCelsius(double initialTemperature, int initialScaleIndex) =>
            temperatureScalesList[initialScaleIndex].ConvertTemperatureToCelsius(initialTemperature);

        private double ConvertFromCelsius(double initialTemperature, int resultScaleIndex) =>
            temperatureScalesList[resultScaleIndex].ConvertTemperatureFromCelsius(initialTemperature);

        public double ConvertTemperature(double initialTemperature, int initialScaleIndex, int resultScaleIndex) =>
            ConvertFromCelsius(ConvertToCelsius(initialTemperature, initialScaleIndex), resultScaleIndex);
    }
}
