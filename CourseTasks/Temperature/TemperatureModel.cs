using Temperature.ScalesClasses;

namespace Temperature
{
    class TemperatureModel
    {
        private IScale[] temperatureScalesList { get; }

        public TemperatureModel()
        {
            temperatureScalesList = new IScale[]
            {
                new Celsius(),
                new Farenheit(),
                new Kelvin()
            };
        }

        public string[] ScalesNames { get; } = new string[]
            {
                new Celsius().GetScaleName(),
                new Farenheit().GetScaleName(),
                new Kelvin().GetScaleName()
            };

        private double ConverterToCelsius(double initialTemperature, int initialScaleIndex) =>
            temperatureScalesList[initialScaleIndex].ConvertTemperatureToCelsius(initialTemperature);

        private double ConverterFromCelsius(double initialTemperature, int resultScaleIndex) =>
            temperatureScalesList[resultScaleIndex].ConvertTemperatureFromCelsius(initialTemperature);

        public double TemperatureConverter(double initialTemperature, int initialScaleIndex, int resultScaleIndex) =>
            ConverterFromCelsius(ConverterToCelsius(initialTemperature, initialScaleIndex), resultScaleIndex);
    }
}
