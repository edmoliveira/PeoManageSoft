namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represent a view from a database.
    /// </summary>
    internal class View
    {
        #region Properties

        /// <summary>
        /// Table name.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.View class.
        /// </summary>
        /// <param name="name"></param>
        public View(string name)
        {
            Name = name;
        }

        #endregion
    }
}

