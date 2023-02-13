
namespace Discom.UP.Backend.UpDash.Rest.Interfaces
{
    /// <summary>
    /// Username and Groups Interface to enable configuration dependend Implementations
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Full Username include potential Domain or Machine Name
        /// </summary>
        /// <returns></returns>
        string FullUserName();
        /// <summary>
        /// UserName
        /// </summary>
        /// <returns></returns>
        string UserName();
        /// <summary>
        /// DomainName
        /// </summary>
        /// <returns></returns>
        string Domain();
        /// <summary>
        /// Set the User
        /// </summary>
        /// <param name="name"></param>
        /// <param name="domain"></param>
        void SetUser(string name, string domain);

        /// <summary>
        /// Checks if the user exists in the specifed group.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
    }
}
