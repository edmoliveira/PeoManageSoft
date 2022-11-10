namespace PeoManageSoft.Business.Application.User.ChangePassword
{
    /// <summary>
    /// Application layer to change password if the old password is valid. 
    /// </summary>
    internal interface IChangePasswordApplication : IApplicationAsync<ChangePasswordRequest>
    {
    }
}
