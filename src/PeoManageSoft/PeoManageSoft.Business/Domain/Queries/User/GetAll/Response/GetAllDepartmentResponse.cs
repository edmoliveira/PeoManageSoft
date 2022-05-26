namespace PeoManageSoft.Business.Domain.Queries.User.GetAll.Response
{
    /// <summary>
    /// Response for the get all department query.
    /// </summary>
    internal class GetAllDepartmentResponse
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
