namespace CrossCutting.Core.Guards
{
    public partial class Guard
    {
        static void CheckOrFail(bool condition, string message)
        {
            if (!condition)
                throw new GuardValidationException(message);
        }
    }
}
