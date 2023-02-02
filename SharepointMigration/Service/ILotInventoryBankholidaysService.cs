using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface ILotInventoryBankholidaysService
    {
        Task<List<LotInventoryBankholidaysModel>> Get();
        Task<LotInventoryBankholidaysModel> Get(string ProjectNumber);
        Task<LotInventoryBankholidaysModel> Update(string ProjectNumber, LotInventoryBankholidaysModel data);
        void Create(string ProjectNumber, LotInventoryBankholidaysModel data);
    }
}