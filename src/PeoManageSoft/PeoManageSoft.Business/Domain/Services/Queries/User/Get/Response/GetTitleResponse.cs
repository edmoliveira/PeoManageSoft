namespace PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response
{
    /// <summary>
    /// Response for the get title query.
    /// </summary>
    internal class GetTitleResponse
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

