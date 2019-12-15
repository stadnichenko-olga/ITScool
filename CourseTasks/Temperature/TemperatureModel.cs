using System.Linq;
using Temperature.ScalesClasses;

namespace Temperature
{
    class TemperatureModel
    {
        internal IScales[] temperatureScalesList { get; }

        public TemperatureModel(double initialTemperature) => temperatureScalesList = new IScales[] 
            { 
                new Celsius(initialTemperature), 
                new Farenheit(initialTemperature), 
                new Kelvin(initialTemperature) 
            };

        public object[] ScalesNames() => temperatureScalesList.Select(x => x.ScaleName()).ToArray();

        public double ConvertTemperature(int initialScaleValue, int resultScaleValue)
        {
            return ConverterFromCelsius(ConverterToCelsius()[initialScaleValue])[resultScaleValue];
        }

        private double[] ConverterFromCelsius(double initialTemperature)
        {
            TemperatureModel temperatureArray = new TemperatureModel(initialTemperature);
            return temperatureArray.temperatureScalesList.Select(x => x.TemperatureConverterFromCelsius()).ToArray(); 
        }

        private double[] ConverterToCelsius() => temperatureScalesList.Select(x => x.TemperatureConverterToCelsius()).ToArray();
    }
}
