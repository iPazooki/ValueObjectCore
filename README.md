## What is a value object?

A value object is a design pattern that represents an immutable object with equality based on its state, not its identity. This means that two value objects are equal if they have the same properties and values, regardless of their references. For example, two money objects with the same amount and currency are equal, even if they are different instances.

A value object has the following characteristics:

- It is immutable, meaning that its state cannot be changed after creation
- It has no identity, meaning that it does not have a unique identifier or a reference to another object
- It is self-contained, meaning that it does not depend on external resources or services
- It is comparable, meaning that it can be compared with other value objects of the same type

## How to implement a value object base class in C#?

One way to implement a value object in C# is to create a base class that overrides the `Equals` and `GetHashCode` methods, and provides a copy constructor. The `Equals` method compares two value objects by calling `GetAtomicValues` method to compare their values. The `GetHashCode` method returns a hash code based on the values of the public properties. 

Here is an example of a value object base class in C#:

```csharp
public abstract class ValueObject : IEquatable<ValueObject>
{    
    public abstract IEnumerable<object> GetAtomicValues();

    public bool Equals(ValueObject? other)
    {
        return other is not null && ValueObjectsAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null && obj is ValueObject other && ValueObjectsAreEqual(other);
    }    

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }

    private bool ValueObjectsAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
}
```
Now, you have the option to inherit from the **ValueObject** class, like:

```csharp
public sealed class SampleValueObject : ValueObject
{
    public string PropertyOne { get; set; } = "Value1";

    public int PropertyTwo { get; set; } = 2;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return PropertyOne;
        yield return PropertyTwo;
    }
}
```

After defining the **SampleValueObject** class, you can write a sample xUnit unit test for the preceding class:

```csharp
[Fact]
public void Equals_WhenCalledWithEqualValueObjects_ReturnsTrue()
  {
      // Arrange
      var valueObject1 = new SampleValueObject();
      var valueObject2 = new SampleValueObject();

      // Act
      var result = valueObject1.Equals(valueObject2);

      // Assert
      Assert.True(result);
  }
```