using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface ISalesNeedInputService
    {
        Task<SalesNeedInputModel> Get(string ProjectNumber);
        Task<SalesNeedInputModel> Update(string ProjectNumber, SalesNeedInputModel data);
        void Create(string ProjectNumber, SalesNeedInputModel data);
    }
}