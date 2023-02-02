using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IPlanandElevationService
    {
        Task<List<PlanandElevationModel>> Get();
        Task<PlanandElevationModel> Get(string ProjectNumber);
        Task<PlanandElevationModel> Get(string ProjectNumber, string Elevation);
        Task<PlanandElevationModel> Update(string ProjectNumber, PlanandElevationModel data);
        void Create(string ProjectNumber, PlanandElevationModel data);
    }
}