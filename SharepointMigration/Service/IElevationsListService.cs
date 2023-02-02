using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IElevationsListService
    {
        Task<List<ElevationsListModel>> Get();
        Task<ElevationsListModel> Get(string ProjectNumber, string key2);
        Task<ElevationsListModel> Update(string ProjectNumber, ElevationsListModel data);
        void Create(string ProjectNumber, ElevationsListModel data);
    }
}