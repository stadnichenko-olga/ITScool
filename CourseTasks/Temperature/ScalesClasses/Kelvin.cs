namespace Temperature.ScalesClasses
{
    class Kelvin : IScale
    {
        public double ConvertTemperatureFromCelsius(double temperature) => temperature + 273.15;

        public double ConvertTemperatureToCelsius(double temperature) => temperature - 273.15;

        public string GetScaleName() => "Kelvin";
    }
}
