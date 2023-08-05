namespace ValueObjectCore.Tests;

public class ValueObjectTests
{
    [Fact]
    public void Equals_WhenCalledWithNull_ReturnsFalse()
    {
        // Arrange
        var valueObject = new SampleValueObject();

        // Act
        var result = valueObject.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenCalledWithSameInstance_ReturnsTrue()
    {
        // Arrange
        var valueObject = new SampleValueObject();

        // Act
        var result = valueObject.Equals(valueObject);

        // Assert
        Assert.True(result);
    }

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

    [Fact]
    public void Equals_WhenCalledWithDifferentValueObjects_ReturnsFalse()
    {
        // Arrange
        var valueObject1 = new SampleValueObject();
        var valueObject2 = new SampleValueObject { PropertyOne = "Different" };

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_WhenCalled_ReturnsHashCode()
    {
        // Arrange
        var valueObject = new SampleValueObject();

        // Act
        var result = valueObject.GetHashCode();

        // Assert
        Assert.Equal(valueObject.GetAtomicValues().Aggregate(0, (x, y) => HashCode.Combine(x, y)), result);
    }
}

internal sealed class SampleValueObject : ValueObject
{
    public string PropertyOne { get; set; } = "PropertyOne";

    public int PropertyTwo { get; set; } = 2;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return PropertyOne;
        yield return PropertyTwo;
    }
}
