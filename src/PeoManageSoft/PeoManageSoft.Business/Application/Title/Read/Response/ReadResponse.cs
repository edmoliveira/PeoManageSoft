namespace PeoManageSoft.Business.Application.Title.Read.Response
{
    /// <summary>
    /// Response data.
    /// </summary>
    public sealed class ReadResponse
    {
        #region Properties

        /// <summary>
        /// Title identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Indicates whether the title is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Title name
        /// </summary>
        public string Name { get; set; }

        #endregion 
    }
}