using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Application.Role
{
    /// <summary>
    /// Role enumerators 
    /// </summary>
    public static class RoleEnumerators
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
            /// Name
            /// </summary>
            Name,
        }

        /// <summary>
        /// Transforms Fields to RoleEntityField.
        /// </summary>
        /// <param name="field">Entity fields</param>
        /// <returns>RoleEntityField</returns>
        internal static RoleEntityField ToEntityField(Fields field)
        {
            return field switch
            {
                Fields.Id => RoleEntityField.Id_Readonly,
                Fields.IsActive => RoleEntityField.IsActive,
                _ => RoleEntityField.Name
            };
        }
    }
}
