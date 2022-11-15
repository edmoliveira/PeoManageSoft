namespace PeoManageSoft.Business.Application.Department.New
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class NewRequest
    {
        #region Properties

        /// <summary>
        /// Indicates whether the department is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Full departmentname
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
