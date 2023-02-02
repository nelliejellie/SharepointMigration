using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IBPSProjectDifferentialsService
    {
        Task<List<BPSProjectDifferentialsModel>> Get();
        Task<BPSProjectDifferentialsModel> Get(string ProjectNumber);
        Task<BPSProjectDifferentialsModel> Update(string ProjectNumber, BPSProjectDifferentialsModel data);
        void Create(string ProjectNumber, BPSProjectDifferentialsModel data);
    }
}