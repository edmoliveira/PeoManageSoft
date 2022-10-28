using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using static PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleEntityConfig;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Department encapsulation of logic to access data sources.
    /// </summary>
    internal interface ITitleRepository : IBaseRepository<TitleEntity, EntityField>
    {

    }
}
