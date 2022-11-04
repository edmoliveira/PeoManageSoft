namespace PeoManageSoft.Business.Application.User.CreateNewPassword
{
    /// <summary>
    /// Application layer to create new password if the user token is valid. 
    /// </summary>
    internal interface ICreateNewPasswordApplication : IApplicationAsync<CreateNewPasswordRequest>
    {
    }
}
