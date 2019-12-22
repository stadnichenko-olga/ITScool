namespace Temperature.ScalesClasses
{
    class Kelvin : IScale
    {
        private readonly double temperature;

        public Kelvin(double initialTemperature)
        {
            temperature = initialTemperature;
        }

        public double ConvertTemperatureFromCelsius() => temperature + 273.15;

        public double ConvertTemperatureToCelsius() => temperature - 273.15;

        public string PrintScaleName() => "Kelvin";
    }
}
