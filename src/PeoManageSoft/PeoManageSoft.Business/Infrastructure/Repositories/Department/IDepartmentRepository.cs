using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    internal interface IDepartmentRepository : IBaseRepository<DepartmentEntity, DepartmentEntityField>
    {
    }
}
