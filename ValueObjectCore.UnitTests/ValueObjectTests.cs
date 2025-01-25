namespace ValueObjectCore.UnitTests
{
    public class ValueObjectTests
    {
        private class TestValueObject(IEnumerable<object?> values) : ValueObject
        {
            public override IEnumerable<object?> GetAtomicValues()
            {
                return values;
            }
        }

        [Fact]
        public void Equals_ReturnsTrue_ForEqualValueObjects()
        {
            var valueObject1 = new TestValueObject([1, "test", null]);
            var valueObject2 = new TestValueObject([1, "test", null]);

            Assert.True(valueObject1.Equals(valueObject2));
        }

        [Fact]
        public void Equals_ReturnsFalse_ForDifferentValueObjects()
        {
            var valueObject1 = new TestValueObject([1, "test", null]);
            var valueObject2 = new TestValueObject([2, "test", null]);

            Assert.False(valueObject1.Equals(valueObject2));
        }

        [Fact]
        public void Equals_ReturnsFalse_WhenOtherIsNull()
        {
            var valueObject = new TestValueObject([1, "test", null]);

            Assert.False(valueObject.Equals(null));
        }

        [Fact]
        public void GetHashCode_ReturnsSameHashCode_ForEqualValueObjects()
        {
            var valueObject1 = new TestValueObject([1, "test", null]);
            var valueObject2 = new TestValueObject([1, "test", null]);

            Assert.Equal(valueObject1.GetHashCode(), valueObject2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_ReturnsDifferentHashCode_ForDifferentValueObjects()
        {
            var valueObject1 = new TestValueObject([1, "test", null]);
            var valueObject2 = new TestValueObject([2, "test", null]);

            Assert.NotEqual(valueObject1.GetHashCode(), valueObject2.GetHashCode());
        }

        [Fact]
        public void Equals_ReturnsFalse_ForDifferentTypes()
        {
            var valueObject = new TestValueObject([1, "test", null]);
            var differentTypeObject = new object();

            Assert.False(valueObject.Equals(differentTypeObject));
        }
    }
}