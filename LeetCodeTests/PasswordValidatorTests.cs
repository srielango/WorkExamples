using FluentAssertions;
using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [TestMethod]
        [DataRow("IloveLe3tcode!", true)]

        public void ValidPassword_ReturnsTrue(string password, bool expected)
        {
            var _sut = new PasswordValidator();
            var actual = _sut.StrongPasswordChecker(password);
            actual.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("aab@3IsBad", false)]
        [DataRow("@3IsBadAA", false)]
        public void PasswordWithSameCharsInAdjacentPosition_ReturnsFalse(string password, bool expected)
        {
            var _sut = new PasswordValidator();
            var actual = _sut.StrongPasswordChecker(password);
            actual.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("Me+You--IsMyDream", false)]
        [DataRow("1aB!", false)]
        [DataRow("noupper@pass1", false)]
        [DataRow("NOLOWER@PASS2", false)]
        [DataRow("NothingSpecialInPass3", false)]
        public void InvalidPassword_ReturnsFalse(string password, bool expected)
        {
            var _sut = new PasswordValidator();
            var actual = _sut.StrongPasswordChecker(password);
            actual.Should().Be(expected);
        }
    }
}
