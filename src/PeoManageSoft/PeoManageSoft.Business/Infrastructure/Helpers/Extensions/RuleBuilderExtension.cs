using FluentValidation;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Extensions
{
    /// <summary>
    /// Provides a extension of the uleBuilder class.
    /// </summary>
    internal static class RuleBuilderExtension
    {
        #region Properties

        /// <summary>
        /// Password length error message.
        /// </summary>
        public static string PasswordLengthErrorMessage { get; set; } = "The password field must at least {minimumLength} characters long!";
        /// <summary>
        /// Password uppercase letter error message.
        /// </summary>
        public static string PasswordUppercaseLetterErrorMessage { get; set; } = "The password field must at least contain one uppercase letter!";
        /// <summary>
        /// Password lowercase letter error message.
        /// </summary>
        public static string PasswordLowercaseLetterErrorMessage { get; set; } = "The password field must at least contain one lowercase letter!";
        /// <summary>
        /// Password digit error message.
        /// </summary>
        public static string PasswordDigitErrorMessage { get; set; } = "The password field must at least contain one digit from 0 to 9!";
        /// <summary>
        /// Password special character error message.
        /// </summary>
        public static string PasswordSpecialCharacterErrorMessage { get; set; } = "The password field must at least contain one special character!";

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Defines a 'password' validator on the current rule builder.
        /// </summary>
        /// <typeparam name="T">Type of object being validated</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
        /// <param name="minimumLength">Minimum password length</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength)
        {
            var options = ruleBuilder
                .MinimumLength(minimumLength).WithMessage(PasswordLengthErrorMessage.Replace("{minimumLength}", minimumLength.ToString()))
                .Matches("[A-Z]").WithMessage(PasswordUppercaseLetterErrorMessage)
                .Matches("[a-z]").WithMessage(PasswordLowercaseLetterErrorMessage)
                .Matches("[0-9]").WithMessage(PasswordDigitErrorMessage)
                .Matches("[^a-zA-Z0-9]").WithMessage(PasswordSpecialCharacterErrorMessage);

            return options;
        }

        /// <summary>
        /// Defines a 'uri' validator on the current rule builder.
        /// </summary>
        /// <typeparam name="T">Type of object being validated</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> Uri<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .Must(x =>
                {
                    if (string.IsNullOrWhiteSpace(x))
                    {
                        return false;
                    }

                    return System.Uri.TryCreate(x, UriKind.Absolute, out var result)
                        && (result.Scheme == System.Uri.UriSchemeHttp || result.Scheme == System.Uri.UriSchemeHttps);
                });

            return options;
        }

        #endregion

        #endregion
    }
}
