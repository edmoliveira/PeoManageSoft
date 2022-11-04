namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Application layer to validate if the password token is valid. 
    /// </summary>
    internal interface IValidatePasswordTokenApplication : IApplicationAsync<ValidatePasswordTokenRequest, ValidatePasswordTokenResponse>
    {
    }
}
