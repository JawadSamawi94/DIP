namespace DIP
{
    public static class DoubleExtensionModel
    {
        public static bool IsBetween(this double value, double lower, double higher)
        {
            return value < higher && lower < value;
        }
    }
}
