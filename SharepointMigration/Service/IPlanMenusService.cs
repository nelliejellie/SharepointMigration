using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IPlanMenusService
    {
        Task<List<PlanMenusModel>> Get();
        Task<PlanMenusModel> Get(string ProjectNumber);
        Task<PlanMenusModel> Update(string ProjectNumber, PlanMenusModel data);
        void Create(string ProjectNumber, PlanMenusModel data);
    }
}