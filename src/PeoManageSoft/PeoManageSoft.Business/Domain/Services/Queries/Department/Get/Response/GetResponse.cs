namespace PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response
{
    /// <summary>
    /// Response for the department.
    /// </summary>
    internal sealed class GetResponse
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
