﻿namespace PeoManageSoft.Business.Application.User.Read.Response
{
    /// <summary>
    /// Response for the read department query.
    /// </summary>
    public class ReadDepartmentResponse
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
