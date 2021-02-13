using WooliesXChallenge.Services;
using Xunit;

namespace WooliesXChallenge.UnitTests.Services
{
    public class SortValidatorTests
    {
        [Theory]
        [InlineData("Low")]
        [InlineData("High")]
        [InlineData("Ascending")]
        [InlineData("Descending")]
        [InlineData("Recommended")]
        public void SortValidator_Should_Return_True_With_Valid_Sort_Options(string testValue)
        {
            (bool validation, string error) result = SortValidator.Validate(testValue);

            Assert.True(result.validation);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ascending")]
        [InlineData("invalid")]
        public void SortValidator_Should_Return_False_And_Error_With_Inalid_Sort_Options(string testValue)
        {
            (bool validation, string error) result = SortValidator.Validate(testValue);

            Assert.False(result.validation);
            Assert.Equal("Sort option must be either \"Low\", \"High\", \"Ascending\", \"Descending\", \"Recommended\" (case sensitive)", result.error);
        }
    }
}
