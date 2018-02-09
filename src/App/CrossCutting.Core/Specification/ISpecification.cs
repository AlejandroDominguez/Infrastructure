using System;
using System.Linq.Expressions;

namespace CrossCutting.Core.Specification
{

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfied();
    }
}
