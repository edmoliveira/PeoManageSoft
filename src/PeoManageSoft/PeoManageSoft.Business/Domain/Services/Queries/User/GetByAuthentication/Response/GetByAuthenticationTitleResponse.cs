namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication.Response
{
    /// <summary>
    /// Response for the Get By Authentication title query.
    /// </summary>
    internal class GetByAuthenticationTitleResponse
    {
        #region Properties

        /// <summary>
        /// Title identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Title name
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}

