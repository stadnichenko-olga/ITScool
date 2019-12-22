namespace Temperature.ScalesClasses
{
    class Celsius : IScale
    {
        private readonly double temperature;

        public Celsius(double initialTemperature)
        {
            temperature = initialTemperature;
        }

        public double ConvertTemperatureFromCelsius() => temperature;

        public double ConvertTemperatureToCelsius() => temperature;

        public string PrintScaleName() => "Celsius";
    }
}
