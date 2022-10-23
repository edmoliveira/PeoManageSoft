namespace PeoManageSoft.Business.Infrastructure.Helpers.Exceptions
{
    /// <summary>
    /// Represents errors that occur when base entity tries to get a parameter id.
    /// </summary>
    public class EntityIdNotFoundException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Salep.Domain.Infra.Exceptions.EntityIdNotFoundException class.
        /// </summary>
        public EntityIdNotFoundException() : base("Entity id not found")
        {

        }

        /// <summary>
        /// Initializes a new instance of the Salep.Domain.Infra.Exceptions.EntityIdNotFoundException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public EntityIdNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the Salep.Domain.Infra.Exceptions.EntityIdNotFoundException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public EntityIdNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

        #endregion
    }
}
