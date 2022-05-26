namespace PeoManageSoft.Business.Application.User.ReadAll.Response
{
    /// <summary>
    /// Response for the read all department query.
    /// </summary>
    public class ReadAllDepartmentResponse
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
