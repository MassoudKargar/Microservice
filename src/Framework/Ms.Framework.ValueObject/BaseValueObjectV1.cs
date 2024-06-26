﻿namespace Ms.Framework.ValueObject;

public abstract class BaseValueObjectV1<TValueObject> : IEquatable<TValueObject> where TValueObject : BaseValueObjectV1<TValueObject>
{
    public bool Equals(TValueObject? other) => this == other;

    protected abstract bool ObjectIsEqual(TValueObject? other);
    public override bool Equals(object? obj)
    {
        return (obj is TValueObject otherObject && ObjectIsEqual(otherObject));
    }

    protected abstract int ObjectGetHashCode();

    public override int GetHashCode() => ObjectGetHashCode();

    public static bool operator ==(BaseValueObjectV1<TValueObject>? left, BaseValueObjectV1<TValueObject>? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }
    public static bool operator !=(BaseValueObjectV1<TValueObject> left, BaseValueObjectV1<TValueObject> right) => !(left == right);
}