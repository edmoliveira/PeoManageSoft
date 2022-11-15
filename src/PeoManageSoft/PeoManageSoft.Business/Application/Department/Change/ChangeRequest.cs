namespace PeoManageSoft.Business.Application.Department.Change
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ChangeRequest
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
