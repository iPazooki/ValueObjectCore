![Nuget](https://img.shields.io/nuget/v/ValueObjectCore)
![GitHub](https://img.shields.io/github/license/ipazooki/ValueObjectCore)
![GitHub contributors](https://img.shields.io/github/contributors/ipazooki/valueobjectcore)
![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/ipazooki/ValueObjectCore/dotnet.yml)

## What is a value object?

A value object is a design pattern that represents an immutable object with equality based on its state, not its identity. This means that two value objects are equal if they have the same properties and values, regardless of their references. For example, two money objects with the same amount and currency are equal, even if they are different instances.

A value object has the following characteristics:

- It is immutable, meaning that its state cannot be changed after creation
- It has no identity, meaning that it does not have a unique identifier or a reference to another object
- It is self-contained, meaning that it does not depend on external resources or services
- It is comparable, meaning that it can be compared with other value objects of the same type

## Value object base class in C#

After referencing this project or using its Nuget package, you have the option to inherit from the **ValueObject** class, like:

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

### Contribution
👍 You are encouraged to contribute to this project by forking it or giving it a star if you find it valuable :)

### Social Media

[![Email](https://img.shields.io/badge/Email-gray?logo=gmail&style=flat-square)](mailto:ipazooki@gmail.com)
[![Stack Overflow](https://img.shields.io/badge/Stackoverflow-gray?logo=stackoverflow&style=flat-square)](https://stackoverflow.com/users/1424065/mrp)
[![Linkedin](https://img.shields.io/badge/-LinkedIn-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/pazooki)](https://www.linkedin.com/in/pazooki/)
![Twitter Follow](https://img.shields.io/twitter/follow/ipazooki)