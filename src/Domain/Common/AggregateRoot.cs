namespace CustomerBasketManagement.Domain.Common
{
    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
    {
    }

    public abstract class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
    {
    }
}
