namespace learndotnetfast_web_services.Repositories.Tutorial
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using learndotnetfast_web_services.Entities;

    public interface ITutorialRepository
    {
        Task<List<Tutorial>> GetTutorialsByModuleIdAsync(int moduleId);
        Task<Tutorial> SaveAsync(Tutorial tutorial);
        Task<List<Tutorial>> SaveRangeAsync(List<Tutorial> tutorials);
        Task DeleteByIdAsync(int id);
        Task<Tutorial> FindByIdAsync(int id);
    }

}
