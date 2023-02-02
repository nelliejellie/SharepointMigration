using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IDesignCenterDataService
    {
        Task<List<DesignCenterDataModel>> Get();
        Task<DesignCenterDataModel> Get(string ProjectNumber);
        Task<DesignCenterDataModel> Update(string ProjectNumber, DesignCenterDataModel data);
        void Create(string ProjectNumber, DesignCenterDataModel data);
    }
}