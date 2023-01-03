using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Application.Department
{
    /// <summary>
    /// Department enumerators 
    /// </summary>
    public static class DepartmentEnumerators
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
        /// Transforms Fields to DepartmentEntityField.
        /// </summary>
        /// <param name="field">Entity fields</param>
        /// <returns>DepartmentEntityField</returns>
        internal static DepartmentEntityField ToEntityField(Fields field)
        {
            return field switch
            {
                Fields.Id => DepartmentEntityField.Id_Readonly,
                Fields.IsActive => DepartmentEntityField.IsActive,
                _ => DepartmentEntityField.Name
            };
        }
    }
}
