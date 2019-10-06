public static class UIScaleCalculator
{
    public static int TemperatureScale(int temperature)
    {
        int newScale;
        newScale = temperature / 10;
        newScale = CheckValue(newScale);
        return newScale;
    }

    private static int CheckValue(int checkingValue)
    {
        if (checkingValue >= 20)
        {
            checkingValue = 19;
        }
        if (checkingValue <= 0)
        {
            checkingValue = 0;
        }
        return checkingValue;
    }

    public static int WaterScale(int h20)
    {
        int newScale;
        newScale = h20 / 500;
        CheckValue(newScale);
        return newScale;
    }
    public static int OxygenScale(int o2)
    {
        int newScale;
        newScale = o2 / 5;
        CheckValue(newScale);
        return newScale;
    }
    public static int PressureScale(int pressure)
    {
        int newScale;
        newScale = pressure / 100;
        CheckValue(newScale);
        return newScale;
    }
}
