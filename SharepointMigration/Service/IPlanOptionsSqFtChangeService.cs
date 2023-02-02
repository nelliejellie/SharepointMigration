using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IPlanOptionsSqFtChangeService
    {
        Task<List<PlanOptionSqFtChangeModel>> Get();
        Task<PlanOptionSqFtChangeModel> Get(string ProjectNumber);
        Task<PlanOptionSqFtChangeModel> Update(string ProjectNumber, PlanOptionSqFtChangeModel data);
        void Create(string ProjectNumber, PlanOptionSqFtChangeModel data);
    }
}