

namespace Temperature
{
    class Celsius : IScales
    {
        private readonly double temperature;

        public Celsius(double initialTemperature)
        {
            temperature = initialTemperature;
        }

        public double TemperatureConverterFromCelsius() => temperature;

        public double TemperatureConverterToCelsius() => temperature;

        public object ScaleName() => "Celsius";
    }
}
