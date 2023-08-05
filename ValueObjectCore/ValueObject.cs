namespace ValueObjectCore;

/// <summary>
/// An abstract base class for implementing value objects. 
/// Value objects are objects whose equality is determined by the values they hold 
/// rather than by their reference identity.
/// See <see href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects">Value Object</see> for more information.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the atomic values that define the state of the value object.
    /// </summary>
    /// <returns>An IEnumerable containing the atomic values of the value object.</returns>
    public abstract IEnumerable<object> GetAtomicValues();

    /// <summary>
    /// Determines whether this value object is equal to another value object.
    /// </summary>
    /// <param name="other">The other value object to compare with.</param>
    /// <returns>True if the value objects are equal; otherwise, false.</returns>
    public bool Equals(ValueObject? other)
    {
        return other is not null && ValueObjectsAreEqual(other);
    }

    /// <summary>
    /// Determines whether this value object is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns>True if the object is a value object and they are equal; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is not null && obj is ValueObject other && ValueObjectsAreEqual(other);
    }    

    // <summary>
    /// Calculates the hash code for this value object.
    /// </summary>
    /// <returns>The hash code for the value object.</returns>
    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }

    /// <summary>
    /// Compares the atomic values of this value object with another value object.
    /// </summary>
    /// <param name="other">The other value object to compare with.</param>
    /// <returns>True if the atomic values of both value objects are equal; otherwise, false.</returns>
    private bool ValueObjectsAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
}