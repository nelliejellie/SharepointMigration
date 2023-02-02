using SharePointMigration.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface IFinanceCSECreditAmountsService
    {
        Task<List<FinanceCSECreditAmountsModel>> Get();
        Task<FinanceCSECreditAmountsModel> Get(string ProjectNumber);
        Task<FinanceCSECreditAmountsModel> Update(string ProjectNumber, FinanceCSECreditAmountsModel data);
        void Create(string ProjectNumber, FinanceCSECreditAmountsModel data);
    }
}