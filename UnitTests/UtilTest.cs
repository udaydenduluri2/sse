using System;
using ExternalServices;
using NUnit.Framework;

namespace UnitTests
{
    public class UtilTest
    {
        private readonly IUtil _util = new Util();

        [Test]
        public void IsOver1YearTest()
        {
            var isOver1Year = _util.IsOver1Year(DateTime.Today.AddYears(-1).AddDays(-1));
            Assert.IsTrue(isOver1Year);

            isOver1Year = _util.IsOver1Year(DateTime.Today.AddYears(-1));
            Assert.IsTrue(isOver1Year);

            isOver1Year = _util.IsOver1Year(DateTime.Today.AddYears(-1).AddDays(1));
            Assert.IsFalse(isOver1Year);
        }

        [Test]
        public void IsOver2YearsTest()
        {
            var isOver2Year = _util.IsOver2Years(DateTime.Today.AddYears(-2).AddDays(-1));
            Assert.IsTrue(isOver2Year);

            isOver2Year = _util.IsOver2Years(DateTime.Today.AddYears(-2));
            Assert.IsTrue(isOver2Year);

            isOver2Year = _util.IsOver2Years(DateTime.Today.AddYears(-2).AddDays(1));
            Assert.IsFalse(isOver2Year);
        }

        [Test]
        public void IsOver3YearsTest()
        {
            var isOver3Year = _util.IsOver3Years(DateTime.Today.AddYears(-3).AddDays(-1));
            Assert.IsTrue(isOver3Year);

            isOver3Year = _util.IsOver3Years(DateTime.Today.AddYears(-3));
            Assert.IsTrue(isOver3Year);

            isOver3Year = _util.IsOver3Years(DateTime.Today.AddYears(-3).AddDays(1));
            Assert.IsFalse(isOver3Year);
        }

        [Test]
        public void SpendOver5KTest()
        {
            Assert.IsFalse(_util.SpendOver5K(5000));
            Assert.IsTrue(_util.SpendOver5K(5001));
            Assert.IsFalse(_util.SpendOver5K(4999));
        }

        [Test]
        public void Between2KAnd5KTest()
        {
            Assert.IsTrue(_util.Between2KAnd5K(4999));
            Assert.IsTrue(_util.Between2KAnd5K(5000));
            Assert.IsTrue(_util.Between2KAnd5K(2001));
            Assert.IsFalse(_util.Between2KAnd5K(2000));
        }

        [Test]
        public void Between1KAnd2KTest()
        {
            Assert.IsTrue(_util.Between1KAnd2K(2000));
            Assert.IsTrue(_util.Between1KAnd2K(1999));
            Assert.IsTrue(_util.Between1KAnd2K(1001));
            Assert.IsFalse(_util.Between1KAnd2K(1000));
        }

        [Test]
        public void Between500And1KTest()
        {
            Assert.IsTrue(_util.Between500And1K(1000));
            Assert.IsTrue(_util.Between500And1K(999));
            Assert.IsTrue(_util.Between500And1K(501));
            Assert.IsFalse(_util.Between500And1K(500));
        }
    }
}
