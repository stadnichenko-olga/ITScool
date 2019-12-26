namespace Temperature.ScalesClasses
{
    public interface IScale
    {
        double ConvertTemperatureFromCelsius(double temperature);

        double ConvertTemperatureToCelsius(double temperature);

        string GetScaleName();
    }
}
