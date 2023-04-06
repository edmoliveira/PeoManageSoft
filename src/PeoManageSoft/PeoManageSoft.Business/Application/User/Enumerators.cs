using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// User enumerators 
    /// </summary>
    public static class UserEnumerators
    {
        /// <summary>
        /// Entity fields
        /// </summary>
        public enum Fields
        {
            /// <summary>
            /// Id
            /// </summary>
            Id,
            /// <summary>
            /// Active
            /// </summary>
            IsActive,
            /// <summary>
            /// Login
            /// </summary>
            Login,
            /// <summary>
            /// Role
            /// </summary>
            RoleId,
            /// <summary>
            /// Name
            /// </summary>
            Name,
            /// <summary>
            /// ShortName
            /// </summary>
            ShortName,
            /// <summary>
            /// Title id
            /// </summary>
            TitleId,
            /// <summary>
            /// Department id
            /// </summary>
            DepartmentId,
            /// <summary>
            /// Email
            /// </summary>
            Email,
            /// <summary>
            /// Bussiness phone
            /// </summary>
            BussinessPhone,
            /// <summary>
            /// Mobile phone
            /// </summary>
            MobilePhone,
            /// <summary>
            /// Location
            /// </summary>
            Location
        }

        /// <summary>
        /// Transforms Fields to UserEntityField.
        /// </summary>
        /// <param name="field">Entity fields</param>
        /// <returns>UserEntityField</returns>
        internal static UserEntityField ToEntityField(Fields field)
        {
            return field switch
            {
                Fields.Id => UserEntityField.Id_Readonly,
                Fields.IsActive => UserEntityField.IsActive,
                Fields.Login => UserEntityField.Login_Readonly,
                Fields.RoleId => UserEntityField.RoleId,
                Fields.Name => UserEntityField.Name,
                Fields.ShortName => UserEntityField.ShortName,
                Fields.TitleId => UserEntityField.TitleId,
                Fields.DepartmentId => UserEntityField.DepartmentId,
                Fields.Email => UserEntityField.Email,
                Fields.BussinessPhone => UserEntityField.BussinessPhone,
                Fields.MobilePhone => UserEntityField.MobilePhone,
                _ => UserEntityField.Location
            };
        }
    }
}
