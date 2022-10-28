namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represent a table from a database.
    /// </summary>
    internal class Table
    {
        #region Properties

        /// <summary>
        /// Table name.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Table class.
        /// </summary>
        /// <param name="name"></param>
        public Table(string name)
        {
            Name = name;
        }

        #endregion
    }
}
