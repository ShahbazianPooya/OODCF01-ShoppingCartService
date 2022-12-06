namespace CustomerBasketManagement.Domain.Common
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if(valueObject is null)
                return false;

            return EqualCore(valueObject);
        }

        protected abstract bool EqualCore(T obj);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> firstValueObject, ValueObject<T> seccondValueObject)
        {
            if (firstValueObject is null && seccondValueObject is null)
                return true;

            if (firstValueObject is null || seccondValueObject is null)
                return false;

            return firstValueObject.Equals(seccondValueObject);
        }

        public static bool operator !=(ValueObject<T> firstValueObject, ValueObject<T> seccondValueObject)
        {
            return !(firstValueObject == seccondValueObject);
        }
    }
}
