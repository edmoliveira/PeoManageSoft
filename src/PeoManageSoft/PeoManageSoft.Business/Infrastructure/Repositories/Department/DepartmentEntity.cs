using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Mapping to the database department table.
    /// </summary>
    internal class DepartmentEntity : IEntity
    {
        #region Properties

        /// <summary>
        /// Department identifier
        /// </summary>
        public long Id { get; private set; }
        /// <summary>
        /// Indicates whether the department is active
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// Department name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Request id for all transaction in the platform.
        /// </summary>
        public string RequestId { get; private set; }
        /// <summary>
        /// Department who created the record
        /// </summary>
        public string CreationUser { get; private set; }
        /// <summary>
        /// Record creation date and time
        /// </summary>
        public DateTime? CreationDate { get; private set; }
        /// <summary>
        /// Department who updated the record
        /// </summary>
        public string UpdatedUser { get; private set; }
        /// <summary>
        /// Record update date and time
        /// </summary>
        public DateTime? UpdatedDate { get; private set; }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Activates the department
        /// </summary>
        public void Activate()
        {
            this.IsActive = true;
        }

        /// <summary>
        /// Deactivates the department
        /// </summary>
        public void Deactivate()
        {
            this.IsActive = false;
        }

        #endregion

        #region IEntity Members

        /// <summary>
        /// Sets the unique identifier
        /// </summary>
        /// <param name="id">The unique identifier</param>
        void IEntity.SetId(long id)
        {
            this.Id = id;
        }

        #endregion

        #endregion
    }
}
