namespace Temperature
{
    class TemperatureModel
    {
        private object[] temperatureScalesList { get; }

        public object[] TemperatureScalesList
        {
            get => temperatureScalesList;
        }

        public TemperatureModel() => temperatureScalesList = new object[] { "Celsius", "Fahrenheit", "Kelvin" };

        public static double ConvertTemperature(double initialValue, int initialScaleValue, int resultScaleValue) => TemperatureConverterFromCelsius(TemperatureConverterToCelsius(initialValue)[initialScaleValue])[resultScaleValue];
        
        private static double[] TemperatureConverterFromCelsius(double initialTemperature) => new double[]{initialTemperature,
                                                                                                  initialTemperature * 9 / 5 + 32,
                                                                                                  initialTemperature + 273.15};

        private static double[] TemperatureConverterToCelsius(double initialTemperature) => new double[]{initialTemperature,
                                                                                                  (initialTemperature - 32) * 5 / 9,
                                                                                                  initialTemperature - 273.15 };
    }
}
