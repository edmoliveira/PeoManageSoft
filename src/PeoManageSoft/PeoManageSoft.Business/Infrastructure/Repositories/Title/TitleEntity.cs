using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Mapping to the database Title table.
    /// </summary>
    internal class TitleEntity : IEntity
    {
        #region Properties

        /// <summary>
        /// Title identifier
        /// </summary>
        public long Id { get; private set; }
        /// <summary>
        /// Indicates whether the Title is active
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// Title name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Request id for all transaction in the platform.
        /// </summary>
        public string RequestId { get; private set; }
        /// <summary>
        /// Title who created the record
        /// </summary>
        public string CreationUser { get; private set; }
        /// <summary>
        /// Record creation date and time
        /// </summary>
        public DateTime? CreationDate { get; private set; }
        /// <summary>
        /// Title who updated the record
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
        /// Activates the Title
        /// </summary>
        public void Activate()
        {
            this.IsActive = true;
        }

        /// <summary>
        /// Deactivates the Title
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

        /// <summary>
        /// Get the parameters to the insert sql statement
        /// </summary>
        /// <param name="applicationContext"></param>
        /// <returns>Parameters</returns>
        object IEntity.GetInsertParameters(IApplicationContext applicationContext)
        {
            RequestId = applicationContext.RequestId;
            CreationUser = applicationContext.LoggedUser.User;
            CreationDate = DateTime.Now;

            return new
            {
                IsActive,
                Name,
                RequestId,
                CreationUser,
                CreationDate.Value
            };
        }

        /// <summary>
        /// Get the parameters to the update sql statement
        /// </summary>
        ///  <param name="applicationContext"></param>
        /// <returns>Parameters</returns>
        object IEntity.GetUpdateParameters(IApplicationContext applicationContext)
        {
            RequestId = applicationContext.RequestId;
            UpdatedUser = applicationContext.LoggedUser.User;
            UpdatedDate = DateTime.Now;

            return new
            {
                Id,
                IsActive,
                Name,
                RequestId,
                UpdatedUser,
                UpdatedDate.Value
            };
        }

        /// <summary>
        /// Get the parameters to the validate insert sql statement
        /// </summary>
        /// <returns>Parameters</returns>
        object IEntity.GetValidateInsertParameters()
        {
            return new
            {
                Name
            };
        }

        /// <summary>
        /// Get the parameters to the validate update sql statement
        /// </summary>
        /// <returns>Parameters</returns>
        object IEntity.GetValidateUpdateParameters()
        {
            return new
            {
                Id,
                Name
            };
        }

        #endregion

        #endregion
    }
}
