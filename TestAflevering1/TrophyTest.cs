using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aflevering1;

namespace Aflevering1Test
{
    [TestClass]
    public class TrophyTests
    {
        ///Confirms that valid competition names are accepted.
        [DataTestMethod]
        [DataRow("Cup")]
        [DataRow("WorldCup")]
        [DataRow("League")]
        public void SetCompetition_Valid_ShouldPass(string validName)
        {
            var trophy = new Trophy { Competition = validName };
            Assert.AreEqual(validName, trophy.Competition);
        }

        ///Verifies that null competition throws ArgumentNullException.
        [TestMethod]
        public void SetCompetition_Null_ShouldThrow()
        {
            var trophy = new Trophy();
            Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);
        }

        ///Ensures that competition names shorter than 3 chars throw ArgumentException.
        [DataTestMethod]
        [DataRow("")]
        [DataRow("A")]
        [DataRow("AB")]
        public void SetCompetition_TooShort_ShouldThrow(string shortName)
        {
            var trophy = new Trophy();
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = shortName);
        }

        ///Confirms that valid years are accepted.
        [DataTestMethod]
        [DataRow(1970)]
        [DataRow(2000)]
        [DataRow(2025)]
        public void SetYear_Valid_ShouldPass(int validYear)
        {
            var trophy = new Trophy { Year = validYear };
            Assert.AreEqual(validYear, trophy.Year);
        }

        ///Verifies that years outside 1970–2025 throw ArgumentOutOfRangeException.
        [DataTestMethod]
        [DataRow(1969)]
        [DataRow(1800)]
        [DataRow(2026)]
        [DataRow(3000)]
        public void SetYear_Invalid_ShouldThrow(int invalidYear)
        {
            var trophy = new Trophy();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = invalidYear);
        }

        /// Ensures ToString returns the expected formatted string.
        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            var trophy = new Trophy
            {
                Id = 1,
                Competition = "WorldCup",
                Year = 2000
            };

            var result = trophy.ToString();

            StringAssert.Contains(result, "Id: 1");
            StringAssert.Contains(result, "Competition: WorldCup");
            StringAssert.Contains(result, "Year: 2000");
        }
    }
}
