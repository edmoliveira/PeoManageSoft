namespace PeoManageSoft.Business.Domain.Queries.User.GetAll.Response
{
    /// <summary>
    /// Response for the get all title query.
    /// </summary>
    internal class GetAllTitleResponse
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

