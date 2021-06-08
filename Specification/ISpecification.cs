namespace Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T o);
        CompositeSpecification<T> And(CompositeSpecification<T> specification);
        CompositeSpecification<T> Or(CompositeSpecification<T> specification);
        CompositeSpecification<T> Not(CompositeSpecification<T> specification);
    }
}
