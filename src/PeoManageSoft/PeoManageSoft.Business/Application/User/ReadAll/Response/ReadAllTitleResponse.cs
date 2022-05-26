namespace PeoManageSoft.Business.Application.User.ReadAll.Response
{
    /// <summary>
    /// Response for the read all title query.
    /// </summary>
    public class ReadAllTitleResponse
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

