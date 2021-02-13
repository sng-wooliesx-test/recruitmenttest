
namespace WooliesXChallenge.Dto
{
    /// <summary>
    /// Response for user endpoint
    /// </summary>
    public class UserResponse
    {
        public UserResponse(string name)
        {
            Name = name;
            Token = "6439e813-ccff-4a43-884c-c71d2a4a6f33"; // In a real app, this would be a config and not saved to source control
        }

        /// <summary>
        /// Name of the User
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Token of the exercise
        /// </summary>
        public string Token { get; }
    }
}
