namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Add
{
    /// <summary>
    /// Request for the add department command.
    /// </summary>
    internal sealed class AddRequest
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
