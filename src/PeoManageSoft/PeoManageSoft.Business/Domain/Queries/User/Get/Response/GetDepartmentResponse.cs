namespace PeoManageSoft.Business.Domain.Queries.User.Get.Response
{
    /// <summary>
    /// Response for the get department query.
    /// </summary>
    internal class GetDepartmentResponse
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
