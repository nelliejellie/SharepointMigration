using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IStuccoColorsService
    {
        Task<List<StuccoColorsModel>> Get();
        Task<StuccoColorsModel> Get(string ProjectNumber);
        Task<StuccoColorsModel> Update(string ProjectNumber, StuccoColorsModel data);
        void Create(string ProjectNumber, StuccoColorsModel data);
    }
}