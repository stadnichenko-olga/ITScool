namespace Temperature
{
    public interface IScales
    {
        double TemperatureConverterFromCelsius();

        double TemperatureConverterToCelsius();

        object ScaleName();
    }
}
