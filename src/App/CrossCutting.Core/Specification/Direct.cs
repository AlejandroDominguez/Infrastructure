using System;
using System.Linq.Expressions;

namespace CrossCutting.Core.Specification
{
    public class DirectSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T,bool>> Expression { get; }

        public DirectSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, bool>> IsSatisfied()
        {
            return Expression;
        }
    }
}
