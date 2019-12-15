namespace Temperature.ScalesClasses
{
    class Farenheit : IScales
    {
        private readonly double temperature;

        public Farenheit(double initialTemperature)
        {
            temperature = initialTemperature;
        }

        public double TemperatureConverterFromCelsius() => temperature * 9 / 5 + 32;

        public double TemperatureConverterToCelsius() => (temperature - 32) * 5 / 9;

        public object ScaleName() => "Fahrenheit";
    }
}
