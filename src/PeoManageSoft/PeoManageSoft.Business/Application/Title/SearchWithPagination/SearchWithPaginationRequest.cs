namespace PeoManageSoft.Business.Application.Title.SearchWithPagination
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class SearchWithPaginationRequest
    {
        #region Properties

        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Quantity per page
        /// </summary>
        public int QuantityPerPage { get; set; }
        /// <summary>
        /// Fields for sorting
        /// </summary>
        public IEnumerable<TitleEnumerators.Fields> OrderByFields { get; set; }
        /// <summary>
        /// Indicates whether sorting is descending.
        /// </summary>
        public bool OrderByIsDesc { get; set; }
        /// <summary>
        /// Search field
        /// </summary>
        public TitleEnumerators.Fields SearchField { get; set; }
        /// <summary>
        /// Search field value
        /// </summary>
        public string SearchFieldValue { get; set; }

        #endregion
    }
}
