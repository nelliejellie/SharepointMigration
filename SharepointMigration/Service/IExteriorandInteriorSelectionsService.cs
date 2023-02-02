using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IExteriorandInteriorSelectionsService
    {
        Task<ExteriorandInteriorSelectionsModel> Get(string ProjectNumber);
        Task<ExteriorandInteriorSelectionsModel> Update(string ProjectNumber, ExteriorandInteriorSelectionsModel data);
        void Create(string ProjectNumber, ExteriorandInteriorSelectionsModel data);
    }
}