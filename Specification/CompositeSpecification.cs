namespace Specification
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T o);

        public CompositeSpecification<T> And(CompositeSpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        public CompositeSpecification<T> Or(CompositeSpecification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public CompositeSpecification<T> Not(CompositeSpecification<T> specification)
        {
            return new NotSpecification<T>(this, specification);
        }
    }
}
