using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IRealtorPresentationFormService
    {
        Task<List<RealtorPresentationFormModel>> Get();
        Task<RealtorPresentationFormModel> Get(string ProjectNumber);
        Task<RealtorPresentationFormModel> Update(string ProjectNumber, RealtorPresentationFormModel data);
        void Create(string ProjectNumber, RealtorPresentationFormModel data);
    }
}