using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using static PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentEntityConfig;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Department encapsulation of logic to access data sources.
    /// </summary>
    internal interface IDepartmentRepository : IBaseRepository<DepartmentEntity, EntityField>
    {

    }
}
