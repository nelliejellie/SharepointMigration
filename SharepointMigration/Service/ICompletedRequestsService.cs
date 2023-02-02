using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface ICompletedRequestsService
    {
        Task<List<CompletedRequestsModel>> Get();
        Task<CompletedRequestsModel> Get(string ProjectNumber);
        Task<CompletedRequestsModel> Update(string ProjectNumber, CompletedRequestsModel data);
        void Create(string ProjectNumber, CompletedRequestsModel data);
    }
}