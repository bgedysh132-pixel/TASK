using NUnit.Framework;
using System;
using MusicStructures;

namespace MusicStructures.UnitTests
{
    [TestFixture]
    public class DurationTests
    {
        [Test]
        public void Constructor_WithValidValues_ShouldSetProperties()
        {
            var duration = new Duration(4, 20);
            Assert.That(duration.Minutes, Is.EqualTo(4));
            Assert.That(duration.Seconds, Is.EqualTo(20));
            Assert.That(duration.TotalSeconds, Is.EqualTo(260));
        }

        [Test]
        public void Constructor_WithInvalidValues_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Duration(-1, 30));
            Assert.Throws<ArgumentException>(() => new Duration(3, 65));
            Assert.Throws<ArgumentException>(() => new Duration(5, -10));
        }

        [Test]
        public void ToString_ShouldFormatCorrectly()
        {
            var d1 = new Duration(3, 5);
            var d2 = new Duration(12, 45);

            Assert.That(d1.ToString(), Is.EqualTo("03:05"));
            Assert.That(d2.ToString(), Is.EqualTo("12:45"));
        }

        [Test]
        public void OperatorPlus_ShouldAddCorrectly()
        {
            var d1 = new Duration(2, 45);
            var d2 = new Duration(1, 35);

            var result = d1 + d2;
            Assert.That(result.ToString(), Is.EqualTo("04:20"));
        }

        [Test]
        public void OperatorMinus_WithValidResult_ShouldSubtract()
        {
            var d1 = new Duration(5, 10);
            var d2 = new Duration(2, 30);

            var result = d1 - d2;
            Assert.That(result.ToString(), Is.EqualTo("02:40"));
        }

        [Test]
        public void OperatorMinus_WithNegativeResult_ShouldThrowException()
        {
            var d1 = new Duration(1, 15);
            var d2 = new Duration(2, 0);

            Assert.Throws<InvalidOperationException>(() => { var r = d1 - d2; });
        }

        [Test]
        public void OperatorMultiply_ShouldScaleCorrectly()
        {
            var d = new Duration(1, 15);

            var result = d * 3;
            Assert.That(result.ToString(), Is.EqualTo("03:45"));
        }
    }
}