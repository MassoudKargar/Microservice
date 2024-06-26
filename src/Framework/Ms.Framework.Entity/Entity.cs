﻿namespace Ms.Framework.Entity;

public class Entity : IEquatable<Entity>
{
    public long Id { get; set; }

    public bool Equals(Entity? other) => this == other;
    public override bool Equals(object? obj) => obj is Entity baseEntity && this.Id == baseEntity.Id;

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity? left, Entity? right)
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
    public static bool operator !=(Entity left, Entity right) => !(left == right);
}