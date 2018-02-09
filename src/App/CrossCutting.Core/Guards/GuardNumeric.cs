namespace CrossCutting.Core.Guards
{
    public partial class Guard
    {
        public static void IsPositive(int input, string message = "the integer is not positive")
        {
            CheckOrFail(input > 0,message);
        }

        public static void IsNegative(int input, string message = "the integer is not negative")
        {
            CheckOrFail(input < 0, message);
        }

        public static void IsNegativeOrCero(int input, string message = "the integer is positive")
        {
            CheckOrFail(input <= 0, message);
        }

        public static void IsPositiveOrCero(int input, string message = "the integer is negative")
        {
            CheckOrFail(input >= 0, message);
        }

        public static void IsCero(int input, string message = "the integer is not positive")
        {
            CheckOrFail(input == 0, message);
        }

        public static void IsGreaterThan(int input,int otherValue, string message = "is equal or less than the other value")
        {
            CheckOrFail(input > otherValue, message);
        }

        public static void IsGreaterOrEqual(int input, int otherValue, string message = "is less than other value")
        {
            CheckOrFail(input >= otherValue, message);
        }

        public static void IsLowerThan(int input, int otherValue, string message = "is equal or greater than the other value")
        {
            CheckOrFail(input < otherValue, message);
        }

        public static void IsLowerOrEqual(int input, int otherValue, string message = "is greater than other value")
        {
            CheckOrFail(input <= otherValue, message);
        }
    }
}
