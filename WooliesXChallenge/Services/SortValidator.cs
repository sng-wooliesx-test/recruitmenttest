using System.Linq;

namespace WooliesXChallenge.Services
{
    public class SortValidator
    {
        private static string[] ValidSortOptions = {"Low", "High", "Ascending", "Descending", "Recommended"};

        public static (bool, string) Validate(string option)
        {
            if (!ValidSortOptions.Contains(option))
                return (false,
                    "Sort option must be either \"Low\", \"High\", \"Ascending\", \"Descending\", \"Recommended\" (case sensitive)");

            return (true, "");
        }
    }
}
