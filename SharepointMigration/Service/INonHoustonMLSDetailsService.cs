using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface INonHoustonMLSDetailsService
    {
        Task<NonHoustonMLSDetailsModel> Get(string ProjectNumber);
        Task<NonHoustonMLSDetailsModel> Update(string ProjectNumber, NonHoustonMLSDetailsModel data);
        void Create(string ProjectNumber, NonHoustonMLSDetailsModel data);
    }
}