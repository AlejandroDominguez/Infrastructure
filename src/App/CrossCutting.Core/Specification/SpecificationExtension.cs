namespace CrossCutting.Core.Specification
{
    public static class SpecificationExtension
    {
        public static ISpecification<T> And<T>(this ISpecification<T> specification, ISpecification<T> right)
        {
            return new And<T>(specification, right);
        }

        public static ISpecification<T> Or<T>(this ISpecification<T> specification, ISpecification<T> right)
        {
            return new Or<T>(specification, right);
        }

        public static ISpecification<T> Not<T>(this ISpecification<T> specification)
        {
            return new Negation<T>(specification);
        }
    }
}
