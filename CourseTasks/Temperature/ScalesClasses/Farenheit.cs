namespace Temperature.ScalesClasses
{
    class Farenheit : IScale
    {
        private readonly double temperature;

        public Farenheit(double initialTemperature)
        {
            temperature = initialTemperature;
        }

        public double ConvertTemperatureFromCelsius() => temperature * 9 / 5 + 32;

        public double ConvertTemperatureToCelsius() => (temperature - 32) * 5 / 9;

        public string PrintScaleName() => "Fahrenheit";
    }
}
