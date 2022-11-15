namespace PeoManageSoft.Business.Application.Department.Read.Response
{
    /// <summary>
    /// Response data.
    /// </summary>
    public sealed class ReadResponse
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
        /// Department name
        /// </summary>
        public string Name { get; set; }

        #endregion 
    }
}