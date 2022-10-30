namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represent a procedure from a database.
    /// </summary>
    internal class Procedure
    {
        #region Properties

        /// <summary>
        /// Procedure name.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Procedure class.
        /// </summary>
        /// <param name="name"></param>
        public Procedure(string name)
        {
            Name = name;
        }

        #endregion
    }
}
