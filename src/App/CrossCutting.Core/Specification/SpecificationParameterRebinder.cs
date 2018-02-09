using System.Linq.Expressions;

namespace CrossCutting.Core.Specification
{
    internal class SpecificationParameterRebinder : ExpressionVisitor
    {
        readonly ParameterExpression specificationParameter;

        SpecificationParameterRebinder(ParameterExpression specificationParameter)
        {
            this.specificationParameter = specificationParameter;
        }

        public static Expression ReplaceParameter(Expression expression, ParameterExpression parameter)
        {
            return new SpecificationParameterRebinder(parameter).Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            return p.Type == specificationParameter.Type ? base.VisitParameter(specificationParameter) : base.VisitParameter(p);
        }
    }
}
