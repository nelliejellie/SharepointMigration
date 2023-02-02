using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IPlanListService
    {
        Task<PlanListModel> Get(string ProjectNumber);
        Task<PlanListModel> Update(string ProjectNumber, PlanListModel data);
        void Create(string ProjectNumber, PlanListModel data);
    }
}