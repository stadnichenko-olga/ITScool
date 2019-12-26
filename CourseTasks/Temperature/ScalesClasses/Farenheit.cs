namespace Temperature.ScalesClasses
{
    class Farenheit : IScale
    {        
        public double ConvertTemperatureFromCelsius(double temperature) => temperature * 9 / 5 + 32;

        public double ConvertTemperatureToCelsius(double temperature) => (temperature - 32) * 5 / 9;

        public string GetScaleName() => "Fahrenheit";
    }
}
