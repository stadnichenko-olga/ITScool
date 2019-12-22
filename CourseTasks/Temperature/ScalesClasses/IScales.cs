namespace Temperature.ScalesClasses
{
    public interface IScale
    {
        double ConvertTemperatureFromCelsius();

        double ConvertTemperatureToCelsius();

        string PrintScaleName();
    }
}
