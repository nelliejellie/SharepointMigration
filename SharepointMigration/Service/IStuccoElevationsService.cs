using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IStuccoElevationsService
    {
        Task<List<StuccoElevationsModel>> Get();
        Task<StuccoElevationsModel> Get(string PHS);
        Task<StuccoElevationsModel> Update(string PHS, StuccoElevationsModel data);
        void Create(string PHS, StuccoElevationsModel data);
    }
}