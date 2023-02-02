using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IJobDataForLotFitRequestsService
    {
        Task<JobDataForLotFitRequestsServiceModel> Get(string ProjectNumber);
        Task<JobDataForLotFitRequestsServiceModel> Update(string ProjectNumber, JobDataForLotFitRequestsServiceModel data);
        void Create(string ProjectNumber, JobDataForLotFitRequestsServiceModel data);
    }
}