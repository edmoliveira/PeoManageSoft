namespace PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication.Response
{
    /// <summary>
    /// Response for the Get By Authentication department query.
    /// </summary>
    internal class GetByAuthenticationDepartmentResponse
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
