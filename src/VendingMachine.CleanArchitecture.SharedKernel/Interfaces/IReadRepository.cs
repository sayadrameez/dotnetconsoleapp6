using Ardalis.Specification;

namespace VendingMachine.CleanArchitecture.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
