using NUnit.Framework;

namespace NUnitFindNextBiggerNumberTest
{
    using System;

    using FindNextBiggerNumberLogic;

    using NUnit;

    [TestFixture]
    public class NUnitFindNextBiggerNumberTest
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(56, ExpectedResult = 65)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(12101, ExpectedResult = 12110)]
        [TestCase(120, ExpectedResult = 201)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(3456436, ExpectedResult = 3456463)]
        [TestCase(10, ExpectedResult = null)]
        [TestCase(20, ExpectedResult = null)]
        [TestCase(111, ExpectedResult = null)]
        [TestCase(4, ExpectedResult = null)]
        [TestCase(44444441, ExpectedResult = null)]
        public int? FindNextBiggerNumberTest(int a)
        {
            return FindNextBiggerNumberClass.FindNextBiggerNumber(a);
        }
    }
}
