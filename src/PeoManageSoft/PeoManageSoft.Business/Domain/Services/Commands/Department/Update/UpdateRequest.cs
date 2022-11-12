namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Update
{
    /// <summary>
    /// Request for the update department command.
    /// </summary>
    internal sealed class UpdateRequest
    {
        #region Properties

        /// <summary>
        /// Department identifier
        /// </summary>
        public long Id { get; set; }
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
