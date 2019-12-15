namespace Temperature.ScalesClasses
{
    class Kelvin : IScales
    {
        private readonly double temperature;

        public Kelvin(double initialTemperature)
        {
            temperature = initialTemperature;
        }

        public double TemperatureConverterFromCelsius() => temperature + 273.15;

        public double TemperatureConverterToCelsius() => temperature - 273.15;

        public object ScaleName() => "Kelvin";
    }
}
