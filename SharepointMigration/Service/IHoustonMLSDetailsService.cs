using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IHoustonMLSDetailsService
    {
        Task<HoustonMLSDetailsModel> Get(string ProjectNumber);
        Task<HoustonMLSDetailsModel> Update(string ProjectNumber, HoustonMLSDetailsModel data);
        void Create(string ProjectNumber, HoustonMLSDetailsModel data);
    }
}