namespace Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        CompositeSpecification<T> leftSpecification;
        CompositeSpecification<T> rightSpecification;

        public AndSpecification(CompositeSpecification<T> left, CompositeSpecification<T> right)
        {
            this.leftSpecification = left;
            this.rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.leftSpecification.IsSatisfiedBy(o)
                && this.rightSpecification.IsSatisfiedBy(o);
        }
    }
}