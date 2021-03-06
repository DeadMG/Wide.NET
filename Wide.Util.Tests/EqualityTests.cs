﻿using NUnit.Framework;

namespace Wide.Util.Tests
{
    [TestFixture]
    public class EqualityTests
    {
        private class ShallowPropertiesTest
        {
            public int var = 1;
        }

        private class DeepPropertiesTest
        {
            public ShallowPropertiesTest test = new ShallowPropertiesTest();
        }

        private class ReferenceComparisonOnly : Equality.ReferenceEqual
        {
            public int var = 1;
        }

        [Test]
        public void CheckDeepEqualsComparesShallowProperties()
        {
            Assert.That(Equality.DeepEqual(new ShallowPropertiesTest(), new ShallowPropertiesTest()));
        }

        [Test]
        public void CheckDeepEqualsComparesDeepProperties()
        {
            Assert.That(Equality.DeepEqual(new DeepPropertiesTest(), new DeepPropertiesTest()));
        }

        [Test]
        public void CheckReferenceTestForReferenceMarkedTypes()
        {
            Assert.That(!Equality.DeepEqual(new ReferenceComparisonOnly(), new ReferenceComparisonOnly()));
            var testInstance = new ReferenceComparisonOnly();
            Assert.That(Equality.DeepEqual(testInstance, testInstance));
        }
    }
}
