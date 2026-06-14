using NUnit.Framework;
using PixelStruct;
using System;

namespace PixelStruct.UnitTests
{
    [TestFixture]
    public class PixelTests
    {
        [Test]
        public void ConstructorTest()
        {
            var pixel = new PixelCMYK(10, 20, 30, 40);

            Assert.That(pixel.C, Is.EqualTo(10));
            Assert.That(pixel.M, Is.EqualTo(20));
            Assert.That(pixel.Y, Is.EqualTo(30));
            Assert.That(pixel.K, Is.EqualTo(40));
        }

        [TestCase(-5)]
        [TestCase(256)]
        public void ChannelSet_InvalidValue_ArgumentException(int invalidValue)
        {
            var pixel = new PixelCMYK();

            Assert.That(() => pixel.C = invalidValue, Throws.ArgumentException);
            Assert.That(() => pixel.M = invalidValue, Throws.ArgumentException);
        }

        [TestCase(255, 0, 0, 0, 100.0)]
        [TestCase(255, 255, 255, 255, 400.0)]
        [TestCase(0, 0, 0, 0, 0.0)]
        public void TotalInkTest(int c, int m, int y, int k, double expected)
        {
            var pixel = new PixelCMYK(c, m, y, k);
            Assert.That(pixel.TotalInk, Is.EqualTo(expected).Within(1e-13));
        }

        [TestCase(255, 0, 127, 25, "Ñ:100,00% M: 0,00% Y: 49,80% K: 9,80%")]
        public void ToStringTest(int c, int m, int y, int k, string expected)
        {
            var pixel = new PixelCMYK(c, m, y, k);
            Assert.That(pixel.ToString(), Is.EqualTo(expected));
        }

        [TestCase(10, 10, 10, 10, 10, 10, 10, 10, true)]
        [TestCase(10, 10, 10, 10, 20, 10, 10, 10, false)]
        public void Equals_TwoPixels_ExpectedResult(int c1, int m1, int y1, int k1, int c2, int m2, int y2, int k2, bool expectedResult)
        {
            var p1 = new PixelCMYK(c1, m1, y1, k1);
            var p2 = new PixelCMYK(c2, m2, y2, k2);

            Assert.That(p1.Equals(p2), Is.EqualTo(expectedResult));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var pixel = new PixelCMYK();
            var smth = new object();

            Assert.That(() => pixel.Equals(smth), Throws.ArgumentException);
        }

        [TestCase(2.0, 100, 100, 100, 100, 200, 200, 200, 200)] 
        [TestCase(1.5, 200, 0, 0, 0, 255, 0, 0, 0)]             
        [TestCase(0.5, 255, 10, 0, 0, 128, 5, 0, 0)]            
        public void MultiplicationTest(double kFloat, int c1, int m1, int y1, int k1, int resC, int resM, int resY, int resK) 
        {
            var pixel = new PixelCMYK(c1, m1, y1, k1);
            var expected = new PixelCMYK(resC, resM, resY, resK);

            Assert.That(kFloat * pixel, Is.EqualTo(expected)); 
        }
    }
}