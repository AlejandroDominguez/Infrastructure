
namespace CrossCutting.Core.Guards
{
    public partial class Guard
    {
        public static void IsNull(object input, string message = "is not null")
        {
            CheckOrFail(input == null, message);
        }

        public static void IsNotNull(object input, string message = "is null")
        {
            CheckOrFail(input != null, message);
        }

        public static void HasValue<T>(T? input, string message = "the input has not value") where T : struct 
        {
            CheckOrFail(input.HasValue, message);
        }

        public static void HasNotValue<T>(T? input, string message = "the input has value") where T : struct
        {
            CheckOrFail(!input.HasValue, message);
        }
      
    }
}
