using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface ILotInventoryDeveloperListService
    {
        Task<List<LotInventoryDeveloperListModel>> Get();
        Task<LotInventoryDeveloperListModel> Get(string ProjectNumber);
        Task<LotInventoryDeveloperListModel> Update(string ProjectNumber, LotInventoryDeveloperListModel data);
        void Create(string ProjectNumber, LotInventoryDeveloperListModel data);
    }
}