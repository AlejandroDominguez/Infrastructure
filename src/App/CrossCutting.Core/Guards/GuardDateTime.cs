using System;

namespace CrossCutting.Core.Guards
{
    public partial class Guard
    {
        public static void IsGreaterThan(IComparable input, IComparable otherValue, string message = "is equal or less than the other value")
        {
            CheckOrFail(input.CompareTo(otherValue) > 0, message);
        }

        public static void IsGreaterOrEqual(IComparable input, IComparable otherValue, string message = "is less than other value")
        {
            CheckOrFail(input.CompareTo(otherValue) >= 0, message);
        }

        public static void IsLowerThan(IComparable input, IComparable otherValue, string message = "is equal or greater than the other value")
        {
            CheckOrFail(input.CompareTo(otherValue) < 0, message);
        }

        public static void IsLowerOrEqual(IComparable input, IComparable otherValue, string message = "is greater than other value")
        {
            CheckOrFail(input.CompareTo(otherValue) <= 0, message);
        }

        public static void AreEqual(IComparable input, IComparable otherValue, string message = "are not equal")
        {
            CheckOrFail(input.CompareTo(otherValue) == 0, message);
        }

        public static void AreNotEqual(IComparable input, IComparable otherValue, string message = "are equal")
        {
            CheckOrFail(input.CompareTo(otherValue) != 0, message);
        }
    }
}
