
namespace Discom.UP.Backend.UpDash.Rest.Interfaces
{
    /// <summary>
    /// User service
    /// </summary>
    public interface IUserService
    {
        IUser GetUser();

        void SetUser(string name, string domain);
    }
}
