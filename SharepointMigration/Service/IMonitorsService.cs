using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IMonitorsService
    {
        Task<MonitorsModel> Get(string ProjectNumber);
        Task<MonitorsModel> Update(string ProjectNumber, MonitorsModel data);
        void Create(string ProjectNumber, MonitorsModel data);
    }
}