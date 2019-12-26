namespace Temperature.ScalesClasses
{
    class Celsius : IScale
    {
        public double ConvertTemperatureFromCelsius(double temperature) => temperature;

        public double ConvertTemperatureToCelsius(double temperature) => temperature;

        public string GetScaleName() => "Celsius";
    }
}
