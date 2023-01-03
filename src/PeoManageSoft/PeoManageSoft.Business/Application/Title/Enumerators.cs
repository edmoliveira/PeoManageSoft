using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Application.Title
{
    /// <summary>
    /// Title enumerators 
    /// </summary>
    public static class TitleEnumerators
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
        /// Transforms Fields to TitleEntityField.
        /// </summary>
        /// <param name="field">Entity fields</param>
        /// <returns>TitleEntityField</returns>
        internal static TitleEntityField ToEntityField(Fields field)
        {
            return field switch
            {
                Fields.Id => TitleEntityField.Id_Readonly,
                Fields.IsActive => TitleEntityField.IsActive,
                _ => TitleEntityField.Name
            };
        }
    }
}
