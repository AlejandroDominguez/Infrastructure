using System;
using System.Linq;
using System.Linq.Expressions;

namespace CrossCutting.Core.Specification
{
    public class And<T> : ISpecification<T>
    {
        public And(ISpecification<T> left, ISpecification<T> right)
        {
            Right = right;
            Left = left;
        }

        public ISpecification<T> Left { get; }

        public ISpecification<T> Right { get; }

        public Expression<Func<T, bool>> IsSatisfied()
        {
            var leftExpression = Left.IsSatisfied();
            var rightExpression = Right.IsSatisfied();

            var parameter = leftExpression.Parameters.Single();
            var body = Expression.AndAlso(leftExpression.Body, SpecificationParameterRebinder.ReplaceParameter(rightExpression.Body, parameter));

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
