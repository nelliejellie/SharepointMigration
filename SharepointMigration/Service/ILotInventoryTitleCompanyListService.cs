using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface ILotInventoryTitleCompanyListService
    {
        Task<List<LotInventoryTitleCompanyListModel>> Get();
        Task<LotInventoryTitleCompanyListModel> Get(string ProjectNumber);
        Task<LotInventoryTitleCompanyListModel> Update(string ProjectNumber, LotInventoryTitleCompanyListModel data);
        void Create(string ProjectNumber, LotInventoryTitleCompanyListModel data);
    }
}