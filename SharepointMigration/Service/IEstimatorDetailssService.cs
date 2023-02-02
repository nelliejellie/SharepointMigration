using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharePointMigration.Model;

namespace SharePointMigration.Service
{
    public interface IEstimatorDetailsService
    {
        Task<EstimatorDetailsModel> Get(string ProjectNumber);
        Task<EstimatorDetailsModel> Update(string ProjectNumber, EstimatorDetailsModel data);
        void Create(string ProjectNumber, EstimatorDetailsModel data);
    }
}