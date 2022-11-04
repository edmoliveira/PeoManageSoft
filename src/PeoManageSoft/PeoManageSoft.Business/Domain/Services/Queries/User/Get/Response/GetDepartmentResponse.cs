namespace PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response
{
    /// <summary>
    /// Response for the department.
    /// </summary>
    internal sealed class GetDepartmentResponse
    {
        #region Properties

        /// <summary>
        /// Department identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Department name
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
