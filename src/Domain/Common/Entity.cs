namespace CustomerBasketManagement.Domain.Common
{
    public interface IEntity<TPrimaryKey>
    {
        DateTime CreateAt { get; }
    }

    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public DateTime CreateAt { get; protected set; }

        public TPrimaryKey Id { get; protected set; }

        public Entity()
        {
            CreateAt = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<TPrimaryKey>;

            return other is not null
                   && EqualityComparer<TPrimaryKey>.Default.Equals(Id, other.Id)
                   && GetType() == other.GetType();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }

        public static bool operator ==(Entity<TPrimaryKey> firstEntity, Entity<TPrimaryKey> seccondEntity)
        {
            if (firstEntity is null && seccondEntity is null)
                return true;

            if (firstEntity is null || seccondEntity is null)
                return false;

            return firstEntity.Equals(seccondEntity);
        }

        public static bool operator !=(Entity<TPrimaryKey> firstEntity, Entity<TPrimaryKey> seccondEntity)
        {
            return !(firstEntity == seccondEntity);
        }
    }
}
