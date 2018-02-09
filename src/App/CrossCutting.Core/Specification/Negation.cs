using System;
using System.Linq.Expressions;

namespace CrossCutting.Core.Specification
{
    public class Negation<T> : ISpecification<T>
    {
        public Negation(ISpecification<T> specification)
        {
            Specification = specification;
        }

        public ISpecification<T> Specification { get; }

        public Expression<Func<T, bool>> IsSatisfied()
        {
            var expression = Specification.IsSatisfied();
            var parameter = expression.Parameters[0];
            var body = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
